using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Sistema_de_Gestão_de_Treinamento.User_Control;
using Vinit.SG.Common;
using System.IO;
using Ionic.Zip;

namespace PEG.User_Controls 
{
    public partial class UCExportarCandidataEstadual : UCBase
    {
        public String URL = "";
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private void Show()
        {
            this.divUserControl.Visible = true;
        }

        private void Close()
        {
            this.divUserControl.Visible = false;
        }

        public void Exportar()
        {
            this.Clear();
            this.Show();
        }

        private void Clear()
        {
            ClearControl(this.PnlFundo.Controls);
        }

        private void ExportarExcel(Boolean bZIP)
        {
            //this.UCUCConfirmaExportarInscritas1.ExportarExcel(this.chkZip.Checked);

            grdCanditadaEstadual.DataSource = ListaGrid;
            grdCanditadaEstadual.DataBind();

            this.HddnTipoArquivo.Value = "xls";
            this.divUserControl.Visible = true;

            ViewState["NomeArquivo"] = "Ranking_Candidatas_" + DateTime.Now.Ticks;
            String nome = ObjectUtils.ToString(ViewState["NomeArquivo"]);
            String extensao = "xls";
            Export(this.grdCanditadaEstadual, nome, extensao);

            System.Threading.Thread.Sleep(5000);

            if (bZIP)
            {
                this.compactaArquivo(GetMapPathFull(PathDownloadInscritas), nome, extensao);
                extensao = "zip";
            }

         //   URL = this.Request.Url.ToString().Substring(0, this.Request.Url.ToString().IndexOf("//") + 2) + this.Request.Url.Authority + "/" + PathDownloadInscritas.Replace("\\", "") + "/" + nome + "." + extensao;

            //NovaJanela(this.Page, this.Request.Url.ToString().Substring(0, this.Request.Url.ToString().IndexOf("//") + 2) + this.Request.Url.Authority + "/" + PathDownloadInscritas.Replace("\\", "") + "/" + nome + "." + extensao);

            String valor = "window.open('" + this.Request.Url.ToString().Substring(0, this.Request.Url.ToString().IndexOf("//") + 2) + this.Request.Url.Authority + "/" + PathDownloadInscritas.Replace("\\", "") + "/" + nome + "." + extensao + "');";
            this.ImgBttnExportar.Attributes.Add("onclick", valor);
        }

        private void ExportarOpenDocument()
        {
            //this.UCUCConfirmaExportarInscritas1.ExportarOpenDocument(this.chkZip.Checked);


            grdCanditadaEstadual.DataSource = ListaGrid;
            grdCanditadaEstadual.DataBind();

            this.HddnTipoArquivo.Value = "ods";
            this.divUserControl.Visible = true;

            ViewState["NomeArquivo"] = "Ranking_Candidatas_" + DateTime.Now.Ticks;
            String nome = ObjectUtils.ToString(ViewState["NomeArquivo"]);
            String extensao = "ods";
            Export(this.grdCanditadaEstadual, nome, extensao);

            this.compactaArquivo(GetMapPathFull(PathDownloadInscritas), nome, extensao);
            extensao = "zip";

            String valor = "window.open('" + this.Request.Url.ToString().Substring(0, this.Request.Url.ToString().IndexOf("//") + 2) + this.Request.Url.Authority + "/" + PathDownloadInscritas.Replace("\\", "") + "/" + nome + "." + extensao + "');";
            this.ImgBttnExportar.Attributes.Add("onclick", valor);
        }

        protected void rdList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rdList.SelectedValue == "OpenDocument")
            {
                chkZip.Checked = true;
                chkZip.Enabled = false;

                ExportarOpenDocument();
            }
            else
            {
                chkZip.Enabled = true;

                ExportarExcel(chkZip.Checked);
            }
        }

        protected void ImgBttnExportar_Click(object sender, ImageClickEventArgs e)
        {
            //NovaJanela(this.Page, URL);
        }

        protected void ImgBttnCancelar_Click(object sender, ImageClickEventArgs e)
        {
            this.Clear();
            this.Close();
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

                    //Verifica se existe dados no grid
                    if (gv.Rows.Count > 0)
                    {
                        //Varre linhas do grid
                        for (int i = 0; i < gv.Rows.Count + 1; i++)
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
                                    if (i == 0)
                                    {
                                        Conteudo = gv.Columns[j].HeaderText;
                                    }
                                    else // Linha
                                    {
                                        Conteudo = ((Label)gv.Rows[i - 1].Cells[j].FindControl("Label" + j)).Text;
                                    }

                                    Celula.Text = Conteudo;

                                    Linha.Cells.Add(Celula);
                                }
                            }

                            Table.Rows.Add(Linha);

                            //Cabeçalho - Coloca estilo
                            if (i == 0)
                            {
                                Table.Rows[0].BackColor = System.Drawing.Color.DarkBlue;
                                Table.Rows[0].ForeColor = System.Drawing.Color.White;
                                Table.Rows[0].Font.Bold = true;
                            }
                            else //Linha - Coloca Estilo
                            {
                                Table.Rows[i].BackColor = System.Drawing.Color.LightBlue;
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

        public void compactaArquivo(String caminhoArquivo, String nomeArquivo, String extensao)
        {
            using (ZipFile zip = new ZipFile())
            {
                zip.AddFile(caminhoArquivo + "\\" + nomeArquivo + "." + extensao, "");
                zip.Save(caminhoArquivo + "\\" + nomeArquivo + ".zip");
            }
        }

        protected void chkZip_CheckedChanged(object sender, EventArgs e)
        {
            if (rdList.SelectedIndex > -1)
            {
                ExportarExcel(chkZip.Checked);
            }
        }


    }
}