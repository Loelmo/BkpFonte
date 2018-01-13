using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using PEG.Pagina_Base;

namespace PEG.Paginas
{
    public partial class PaginaDownload : PaginaBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string nomeXLS = Request["nome"];
            string extensao = Request["extensao"];
            this.Download(nomeXLS, extensao);
        }

        private void Download(string nomeXLS, string extensao)
        {
            try
            {
                DirectoryInfo diretorio = new DirectoryInfo(GetMapPathFull(PathDownloadInscritas));
                string nomeArquivo = nomeXLS + "." + extensao;
                FileInfo arquivo = new FileInfo(nomeArquivo);

                //'Limpa o conteúdo de saída atual do buffer
                Response.Clear();
                //'Adiciona um cabeçalho que especifica o nome default para a caixa de diálogos Salvar Como...
                Response.ContentType = "application/octet-stream";
                Response.AddHeader("Content-Disposition", "attachment; filename=" + arquivo.Name);
                //'Adiciona ao cabeçalho o tamanho do arquivo para que o browser possa exibir o progresso do download
                Response.AddHeader("Content-Length", arquivo.Length.ToString());
                Response.Flush();
                Response.WriteFile(arquivo.FullName);

            }
            catch (Exception ex)
            {

            }
        }
    }
}