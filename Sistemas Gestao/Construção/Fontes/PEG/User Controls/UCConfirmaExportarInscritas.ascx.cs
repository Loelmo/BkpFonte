using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Web.UI.HtmlControls;
using Sistema_de_Gestão_de_Treinamento.User_Control;
using Vinit.SG.Common;
using System.IO.Compression;
using Ionic.Zip;


namespace PEG.User_Controls
{
    public partial class UCConfirmaExportarInscritas : UCBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void ExportarExcel(Boolean compactado)
        {
            this.Clear();
            this.HddnTipoArquivo.Value = "xls";
            this.divUserControl.Visible = true;

            ViewState["NomeArquivo"] = "Inscritas_" + DateTime.Now.Ticks;
            String nome = ObjectUtils.ToString(ViewState["NomeArquivo"]);
            String extensao = "xls";
            Export(this.grdEmpresasExport, nome, extensao);

            System.Threading.Thread.Sleep(5000);

            if (compactado)
            {
                this.compactaArquivo(GetMapPathFull(PathDownloadInscritas), nome, extensao);
                extensao = "zip";
            }

            String valor = "window.open('" + this.Request.Url.ToString().Substring(0, this.Request.Url.ToString().IndexOf("//") + 2) + this.Request.Url.Authority + "/" + PathDownloadInscritas.Replace("\\", "") + "/" + nome + "." + extensao + "');";
            this.ImgBttnExportar.Attributes.Add("onclick", valor);
        }

        public void ExportarOpenDocument(bool compactado)
        {
            this.Clear();
            this.HddnTipoArquivo.Value = "ods";
            this.divUserControl.Visible = true;

            ViewState["NomeArquivo"] = "Inscritas_" + DateTime.Now.Ticks;
            String nome = ObjectUtils.ToString(ViewState["NomeArquivo"]);
            String extensao = "ods";
            Export(this.grdEmpresasExport, nome, extensao);

            if (compactado)
            {
                this.compactaArquivo(GetMapPathFull(PathDownloadInscritas), nome, extensao);
                extensao = "zip";
            }

            String valor = "window.open('" + this.Request.Url.ToString().Substring(0, this.Request.Url.ToString().IndexOf("//") + 2) + this.Request.Url.Authority + "/" + PathDownloadInscritas.Replace("\\", "") + "/" + nome + "." + extensao + "');";
            this.ImgBttnExportar.Attributes.Add("onclick", valor);
        }

        private void Close()
        {
            this.divUserControl.Visible = false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="gv"></param>
        public void Export(GridView gv, String fileName, String extensao)
        {
            String path_completo = GetMapPathFull(PathDownloadInscritas) + fileName + "." + extensao;
            System.Text.Encoding encode = System.Text.Encoding.GetEncoding("ISO-8859-1");
            String attachment = "attachment; filename=" + fileName + "." + extensao;
            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.AddHeader(
             "content-disposition", attachment);

            HttpContext.Current.Response.ContentType = "application/x-msdownload";

            using (StringWriter strw = new StringWriter())
            {
                using (HtmlTextWriter htw = new HtmlTextWriter(strw))
                {
                    // Cria table conforme grid
                    Table Table = new Table();

                    Table.BorderWidth = 2;
                    Table.BorderStyle = BorderStyle.Inset;
                    Table.BorderColor = System.Drawing.Color.Black;

                    Table.CellPadding = 1;
                    Table.CellSpacing = 1;
                    Table.GridLines = GridLines.Both;

                    Boolean CabecalhoFormatado = false;
                    //Verifica se existe dados no grid
                    if (gv.Rows.Count > 0)
                    {
                        //Varre linhas do grid
                        for (int i = -1; i < gv.Rows.Count; i++)
                        {
                            TableRow Linha = new TableRow();

                            //Varre colunas do grid
                            for (int j = 0; j < gv.Columns.Count - 1; j++)
                            {
                                //Verifica as colunas selecionadas
                                if (gv.Columns[j].Visible)
                                {
                                    TableCell Celula = new TableCell();
                                    String Conteudo;

                                    // Cabeçalho
                                    if (i == -1)
                                    {
                                        Conteudo = gv.Columns[j].HeaderText;
                                    }
                                    else // Linha
                                    {
                                        Conteudo = ((Label)gv.Rows[i].Cells[j].FindControl("Label" + j)).Text;
                                    }

                                    Celula.Text = Conteudo;

                                    Linha.Cells.Add(Celula);
                                }
                            }

                            Table.Rows.Add(Linha);

                            //Cabeçalho - Coloca estilo
                            if (!CabecalhoFormatado)
                            {
                                Table.Rows[0].BackColor = System.Drawing.Color.DarkBlue;
                                Table.Rows[0].ForeColor = System.Drawing.Color.White;
                                Table.Rows[0].Font.Bold = true;
                            }
                            else //Linha - Coloca Estilo
                            {
                                Table.Rows[i + 1].BackColor = System.Drawing.Color.LightBlue;
                            }
                        }
                    }

                    // render the table into the htmlwriter
                    Table.RenderControl(htw);

                    StreamWriter sw = new StreamWriter(path_completo, true, encode);
                    sw.WriteLine(strw.ToString());
                    sw.Close();

                    FileInfo arquivo = ObterArquivo(fileName, extensao);
                    //1 Byte = 8 Bit
                    //1 Kilobyte = 1024 Bytes
                    Int32 k = StringUtils.ToInt(arquivo.Length.ToString());
                    Double valorKb = (Double)(k / 1024f);
                    this.lblTamanhoValor.Text = Math.Round(valorKb, 2) + "  Kb";

                    Double TempoDiscada = (valorKb / 56) / 60;
                    this.lblDiscada.Text = Math.Round(TempoDiscada, 2) + "  min com Discada (56kb/s)";

                    Double TempoBandaLarga = valorKb / 200 / 60;
                    this.lblBandaLarga.Text = Math.Round(TempoBandaLarga, 2) + "  min com Banda Larga (200kb/s)";
                }
            }
        }

        /// <summary>
        /// Replace any of the contained controls with literals
        /// </summary>
        /// <param name="control"></param>
        private static void PrepareControlForExport(Control control)
        {
            for (int i = 0; i < control.Controls.Count; i++)
            {
                Control current = control.Controls[i];
                if (current is LinkButton)
                {
                    control.Controls.Remove(current);
                    control.Controls.AddAt(i, new LiteralControl((current as LinkButton).Text));
                }
                else if (current is ImageButton)
                {
                    control.Controls.Remove(current);
                    control.Controls.AddAt(i, new LiteralControl((current as ImageButton).AlternateText));
                }
                else if (current is HyperLink)
                {
                    control.Controls.Remove(current);
                    control.Controls.AddAt(i, new LiteralControl((current as HyperLink).Text));
                }
                else if (current is DropDownList)
                {
                    control.Controls.Remove(current);
                    control.Controls.AddAt(i, new LiteralControl((current as DropDownList).SelectedItem.Text));
                }
                else if (current is CheckBox)
                {
                    control.Controls.Remove(current);
                    control.Controls.AddAt(i, new LiteralControl((current as CheckBox).Checked ? "True" : "False"));
                }

                if (current.HasControls())
                {
                    PrepareControlForExport(current);
                }
            }
        }

        private FileInfo ObterArquivo(String nomeXLS, String extensao)
        {
            //'Obtêm o nome compleo do arquivo selecionado
            String nomeArquivo = GetMapPathFull(PathDownloadInscritas) + nomeXLS + "." + extensao;
            //'Obtêm os dados do arquivo pois o tamanho é requerido para efetuar o download
            FileInfo arquivo = new FileInfo(nomeArquivo);
            return arquivo;
        }

        private void Clear()
        {
            ClearControl(this.PnlFundo.Controls);
        }

        protected void ImgBttnCancelar_Click(object sender, ImageClickEventArgs e)
        {
            this.Clear();
            this.Close();
        }

        public void compactaArquivo(String caminhoArquivo, String nomeArquivo, String extensao)
        {
            using (ZipFile zip = new ZipFile())
            {
                zip.AddFile(caminhoArquivo + "\\" + nomeArquivo + "." + extensao, "");
                zip.Save(caminhoArquivo + "\\" + nomeArquivo + ".zip");
            }
        }

        protected void grdEmpresasExport_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            /*if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblCodigoAE = (Label)e.Row.FindControl("lblCodigoAE");
                Label lblAE = (Label)e.Row.FindControl("lblAE");
                Label lblAtividadeEconomica = (Label)e.Row.FindControl("lblAtividadeEconomica");
                lblAtividadeEconomica.Text = lblCodigoAE.Text + " - " + lblAE.Text;
            }*/
        }
    }
}