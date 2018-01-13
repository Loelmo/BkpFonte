using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vinit.SG.DAL;
using Vinit.SG.Ent;
using Vinit.SG.Common;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;

namespace Vinit.SG.BLL
{
    /// <summary>
    /// Classe de Dados que representa um Turma
    /// </summary>
    public class BllQuestionarioEmpresaCalculoPontuacao : BllBase
    {
        public String CalculaPontuacoesByEtapa(Int32 IdTurma, Int32 IdEtapa, Int32 IdEmpresaCadastro, Boolean isAvaliador, String conclusaoAvaliacao)
        {
            EntTurma Turma = new BllTurma().ObterPorId(IdTurma);
            String Protocolo = "2011-" + IdTurma + "-" + IdEmpresaCadastro + "-" + new Random().Next(100000, 999999);

            List<EntQuestionario> listaQuestionarios = new BllQuestionario().ObterEnviadosPorIdEtapaIdEmpresa(IdEtapa, IdEmpresaCadastro);

            ProcessaQuestionariosAvaliacao(listaQuestionarios, IdEmpresaCadastro, IdEtapa, Protocolo, conclusaoAvaliacao);

            return Protocolo;
        }

        public String CalculaPontuacoes(Int32 IdTurma, Int32 IdEmpresaCadastro, Int32 IdUsuario)
        {
            EntTurma Turma = new BllTurma().ObterPorId(IdTurma);
            String Protocolo = "2011-" + IdTurma + "-" + IdEmpresaCadastro + "-" + new Random().Next(100000, 999999);

            List<EntQuestionario> listaQuestionarios = new BllQuestionario().ObterAbertosPorIdTurmaIdEmpresa(IdTurma, IdEmpresaCadastro);

            ProcessaQuestionarios(listaQuestionarios, IdEmpresaCadastro, IdTurma, Protocolo);

            if (IdUsuario > 0)
            {
                new BllLogAcao().Inserir(IdTurma, IdEmpresaCadastro, IdUsuario, EntTipoAcao.TIPO_ACAO_ENVIO_QUESTIONARIO_EMPRESA);
            }

            return Protocolo;
        }

        private void ProcessaQuestionarios(List<EntQuestionario> listaQuestionarios, Int32 IdEmpresaCadastro, Int32 IdTurma, String Protocolo)
        {
            foreach (EntQuestionario questionario in listaQuestionarios)
            {
                if (questionario.EmpresaParticipa)
                {
                    EntQuestionarioEmpresa questionarioEmpresa = new BllQuestionarioEmpresa().ObterQuestionarioAberto(questionario.IdQuestionario, IdEmpresaCadastro, IdTurma);
                    switch (questionario.IdQuestionario)
                    {
                        case EntQuestionario.QUESTIONARIO_GESTAO_2009:
                            questionarioEmpresa = this.CalculaPontuacaoGestao2009(questionarioEmpresa);
                            break;
                        case EntQuestionario.QUESTIONARIO_GESTAO_2011:
                            questionarioEmpresa = this.CalculaPontuacaoGestao2011(questionarioEmpresa);
                            break;
                        case EntQuestionario.QUESTIONARIO_INOVACAO_2011:
                            questionarioEmpresa = this.CalculaPontuacaoInovacao2011(questionarioEmpresa);
                            break;
                        case EntQuestionario.QUESTIONARIO_EMPREENDEDORISMO_2009:
                            questionarioEmpresa = this.CalculaPontuacaoEmpreendedorismo2009(questionarioEmpresa);
                            break;
                        case EntQuestionario.QUESTIONARIO_EMPREENDEDORISMO_2011:
                            questionarioEmpresa = this.CalculaPontuacaoEmpreendedorismo2011(questionarioEmpresa);
                            break;
                        case EntQuestionario.QUESTIONARIO_RESPONSABILIDADE_2009:
                            questionarioEmpresa = this.CalculaPontuacaoResponsabilidadeSocial2009(questionarioEmpresa);
                            break;
                        case EntQuestionario.QUESTIONARIO_RESPONSABILIDADE_2011:
                            questionarioEmpresa = this.CalculaPontuacaoResponsabilidadeSocial2011(questionarioEmpresa);
                            break;
                    }
                    questionarioEmpresa = this.FechaQuestionarioEmpresa(questionarioEmpresa, Protocolo, false);
                    questionarioEmpresa = this.ArmazenarPontuacao(questionarioEmpresa);
                    this.GeraProximosQuestionarios(questionarioEmpresa, Protocolo, true);
                }
            }
        }

        private void ProcessaQuestionariosAvaliacao(List<EntQuestionario> listaQuestionarios, Int32 IdEmpresaCadastro, Int32 IdEtapa, String Protocolo, String conclusaoAvaliacao)
        {
            foreach (EntQuestionario questionario in listaQuestionarios)
            {
                if (questionario.EmpresaParticipa)
                {
                    EntQuestionarioEmpresa questionarioEmpresa = new BllQuestionarioEmpresa().ObterQuestionarioAtivoPorEtapa(questionario.IdQuestionario, IdEmpresaCadastro, IdEtapa);
                    switch (questionario.IdQuestionario)
                    {
                        case EntQuestionario.QUESTIONARIO_GESTAO_2009:
                            questionarioEmpresa = this.CalculaPontuacaoGestao2009(questionarioEmpresa);
                            break;
                        case EntQuestionario.QUESTIONARIO_GESTAO_2011:
                            questionarioEmpresa = this.CalculaPontuacaoGestao2011(questionarioEmpresa);
                            break;
                        case EntQuestionario.QUESTIONARIO_INOVACAO_2011:
                            questionarioEmpresa = this.CalculaPontuacaoInovacao2011(questionarioEmpresa);
                            break;
                        case EntQuestionario.QUESTIONARIO_EMPREENDEDORISMO_2009:
                            questionarioEmpresa = this.CalculaPontuacaoEmpreendedorismo2009(questionarioEmpresa);
                            break;
                        case EntQuestionario.QUESTIONARIO_EMPREENDEDORISMO_2011:
                            questionarioEmpresa = this.CalculaPontuacaoEmpreendedorismo2011(questionarioEmpresa);
                            break;
                        case EntQuestionario.QUESTIONARIO_RESPONSABILIDADE_2009:
                            questionarioEmpresa = this.CalculaPontuacaoResponsabilidadeSocial2009(questionarioEmpresa);
                            break;
                        case EntQuestionario.QUESTIONARIO_RESPONSABILIDADE_2011:
                            questionarioEmpresa = this.CalculaPontuacaoResponsabilidadeSocial2011(questionarioEmpresa);
                            break;
                    }
                    questionarioEmpresa.ListQuestionarioEmpresaAvaliador[0].Banca = conclusaoAvaliacao;
                    questionarioEmpresa.ListQuestionarioEmpresaAvaliador[0].Avaliado = true;
                    questionarioEmpresa.EnviaQuestionario = false;
                    new BllQuestionarioEmpresaAvaliador().Alterar(questionarioEmpresa.ListQuestionarioEmpresaAvaliador[0]);
                    questionarioEmpresa = this.FechaQuestionarioEmpresa(questionarioEmpresa, Protocolo, true);
                    questionarioEmpresa = this.ArmazenarPontuacao(questionarioEmpresa);
//                    this.GeraProximosQuestionarios(questionarioEmpresa, Protocolo, false);
                }
            }
        }

        public void RemoveAvaliador(Int32 IdTurma, Int32 IdEtapa, Int32 IdEmpresaCadastro, String txResumo)
        {
            List<EntQuestionario> listaQuestionarios = new BllQuestionario().ObterEnviadosPorIdEtapaIdEmpresa(IdEtapa, IdEmpresaCadastro);
            foreach (EntQuestionario questionario in listaQuestionarios)
            {
                if (questionario.EmpresaParticipa)
                {
                    EntQuestionarioEmpresa questionarioEmpresa = new BllQuestionarioEmpresa().ObterQuestionarioAtivoPorEtapa(questionario.IdQuestionario, IdEmpresaCadastro, IdEtapa);
                    questionarioEmpresa.ParaAvaliador = false;
                    questionarioEmpresa.DtAlteracao = DateTime.Now;
                    new BllQuestionarioEmpresa().AlterarInsereDevolucao(questionarioEmpresa.IdQuestionarioEmpresa, txResumo);
                }
            }
        }

        protected void GeraProximosQuestionarios(EntQuestionarioEmpresa QuestionarioEmpresa, String Protocolo, Boolean isInscricao)
        {
            if (isInscricao)
            {
                //Questionario Aberto para a Mesma Fase
                EntQuestionarioEmpresa questionarioAberto = new EntQuestionarioEmpresa();
                questionarioAberto.Ativo = false;
                questionarioAberto.DtAlteracao = DateTime.Now;
                questionarioAberto.DtCadastro = DateTime.Now;
                questionarioAberto.EmpresaCadastro.IdEmpresaCadastro = QuestionarioEmpresa.EmpresaCadastro.IdEmpresaCadastro;
                questionarioAberto.Etapa.IdEtapa = QuestionarioEmpresa.Etapa.IdEtapa;
                questionarioAberto.ListQuestionarioEmpresaResposta = QuestionarioEmpresa.ListQuestionarioEmpresaResposta;
                questionarioAberto.ListQuestionarioEmpresaAvaliador = QuestionarioEmpresa.ListQuestionarioEmpresaAvaliador;
                questionarioAberto.PreencheQuestionario = QuestionarioEmpresa.PreencheQuestionario;
                questionarioAberto.MarcaQuestoesEspeciais = QuestionarioEmpresa.MarcaQuestoesEspeciais;
                questionarioAberto.Programa.IdPrograma = QuestionarioEmpresa.Programa.IdPrograma;
                questionarioAberto.Questionario.IdQuestionario = QuestionarioEmpresa.Questionario.IdQuestionario;
                questionarioAberto.Usuario.IdUsuario = QuestionarioEmpresa.Usuario.IdUsuario;
                new BllQuestionarioEmpresa().InserirComFilhos(questionarioAberto);
            }

            //Questionario para a próxima fase
            EntQuestionarioEmpresa questionarioProximaFase = new EntQuestionarioEmpresa();
            questionarioProximaFase.Ativo = true;
            questionarioProximaFase.DtAlteracao = DateTime.Now;
            questionarioProximaFase.DtCadastro = DateTime.Now;
            questionarioProximaFase.MarcaQuestoesEspeciais = QuestionarioEmpresa.MarcaQuestoesEspeciais;
            questionarioProximaFase.Programa.IdPrograma = QuestionarioEmpresa.Programa.IdPrograma;
            questionarioProximaFase.EmpresaCadastro.IdEmpresaCadastro = QuestionarioEmpresa.EmpresaCadastro.IdEmpresaCadastro;
            questionarioProximaFase.Etapa = new BllEtapa().ObterProximaEtapaPorEtapaEstadoOrdem(QuestionarioEmpresa.Etapa.IdEtapa);
            questionarioProximaFase.ListQuestionarioEmpresaResposta = QuestionarioEmpresa.ListQuestionarioEmpresaResposta;
            questionarioProximaFase.ListQuestionarioPontuacao = QuestionarioEmpresa.ListQuestionarioPontuacao;
            if (questionarioProximaFase.Etapa.TipoEtapa.IdTipoEtapa != EntTipoEtapa.TIPO_ETAPA_MPE_CLASSIFICACAO_NACIONAL)
            {
                questionarioProximaFase.ListQuestionarioEmpresaAvaliador = QuestionarioEmpresa.ListQuestionarioEmpresaAvaliador;
            }
            questionarioProximaFase.PreencheQuestionario = QuestionarioEmpresa.PreencheQuestionario;
            questionarioProximaFase.TotalPontuacao = QuestionarioEmpresa.TotalPontuacao;
            questionarioProximaFase.Protocolo = Protocolo;
            questionarioProximaFase.TotalPontuacaoAvaliacao = QuestionarioEmpresa.TotalPontuacaoAvaliacao;
            questionarioProximaFase.Programa.IdPrograma = QuestionarioEmpresa.Programa.IdPrograma;
            questionarioProximaFase.Questionario.IdQuestionario = QuestionarioEmpresa.Questionario.IdQuestionario;
            questionarioProximaFase.Usuario.IdUsuario = QuestionarioEmpresa.Usuario.IdUsuario;
            questionarioProximaFase.EnviaQuestionario = true;
                
            new BllQuestionarioEmpresa().DesabilitaAnteriores(questionarioProximaFase.EmpresaCadastro.IdEmpresaCadastro, questionarioProximaFase.Etapa.IdEtapa, QuestionarioEmpresa.Questionario.IdQuestionario);
            new BllQuestionarioEmpresa().InserirComFilhos(questionarioProximaFase);
        }

        private EntQuestionarioEmpresa ArmazenarPontuacao(EntQuestionarioEmpresa QuestionarioEmpresa)
        {
            new BllQuestionarioPontuacao().ExcluirPorIdQuestionarioEmpresa(QuestionarioEmpresa.IdQuestionarioEmpresa);
            foreach (EntQuestionarioPontuacao pontuacao in QuestionarioEmpresa.ListQuestionarioPontuacao)
            {
                new BllQuestionarioPontuacao().Inserir(pontuacao);
            }
            return QuestionarioEmpresa;
        }

        protected EntQuestionarioEmpresa FechaQuestionarioEmpresa(EntQuestionarioEmpresa QuestionarioEmpresa, String Protocolo, Boolean isAvaliacao)
        {
            QuestionarioEmpresa.Ativo = true;
            QuestionarioEmpresa.DtAlteracao = DateTime.Now;
            if (!isAvaliacao)
            {
                QuestionarioEmpresa.PassaProximaEtapa = true;
            }
            else
            {
                QuestionarioEmpresa.PassaProximaEtapa = false;
            }
            QuestionarioEmpresa.Protocolo = Protocolo;
            QuestionarioEmpresa.EnviaQuestionario = true;
            QuestionarioEmpresa.TotalPontuacao = this.SomaPontuacao(QuestionarioEmpresa.ListQuestionarioPontuacao, false);
            QuestionarioEmpresa.TotalPontuacaoAvaliacao = this.SomaPontuacao(QuestionarioEmpresa.ListQuestionarioPontuacao, true);
            new BllQuestionarioEmpresa().DesabilitaAnteriores(QuestionarioEmpresa.EmpresaCadastro.IdEmpresaCadastro, QuestionarioEmpresa.Etapa.IdEtapa, QuestionarioEmpresa.Questionario.IdQuestionario);
            new BllQuestionarioEmpresa().Alterar(QuestionarioEmpresa);
            return QuestionarioEmpresa;
        }

        protected Decimal SomaPontuacao(List<EntQuestionarioPontuacao> listaPontuacao, Boolean isAvaliacao)
        {
            Decimal res = 0;
            foreach (EntQuestionarioPontuacao p in listaPontuacao)
            {
                if (p.Avaliador == isAvaliacao)
                {
                    res += p.Ponto;
                }
            }
            return res;
        }

        private EntQuestionarioEmpresa CalculaPontuacaoGestao2011(EntQuestionarioEmpresa QuestionarioEmpresa)
        {
            List<EntQuestionarioPontuacao> listaPontuacao = new List<EntQuestionarioPontuacao>();
            EntQuestionarioPontuacao pontuacaoTemp = new EntQuestionarioPontuacao();
            for (int i = 0; i < QuestionarioEmpresa.ListQuestionarioEmpresaResposta.Count; i++)
            {
                EntQuestionarioEmpresaResposta resposta = QuestionarioEmpresa.ListQuestionarioEmpresaResposta[i];
                if (pontuacaoTemp.Criterio.IdCriterio == 0)
                {
                    pontuacaoTemp.Criterio.IdCriterio = resposta.Pergunta.Criterio.IdCriterio;
                    pontuacaoTemp.Questionario.IdQuestionario = QuestionarioEmpresa.Questionario.IdQuestionario;
                    pontuacaoTemp.QuestionarioEmpresa.IdQuestionarioEmpresa = QuestionarioEmpresa.IdQuestionarioEmpresa;
                    if (resposta.UsuarioAvaliador.IdUsuario > 0)
                    {
                        pontuacaoTemp.Avaliador = true;
                    }
                    pontuacaoTemp.Ponto = resposta.Resposta.Ponto;
                }
                else if (resposta.Pergunta.Criterio.IdCriterio != pontuacaoTemp.Criterio.IdCriterio || pontuacaoTemp.Avaliador != (resposta.UsuarioAvaliador.IdUsuario > 0))
                {
                    listaPontuacao.Add(pontuacaoTemp);
                    pontuacaoTemp = new EntQuestionarioPontuacao();
                    pontuacaoTemp.Criterio.IdCriterio = resposta.Pergunta.Criterio.IdCriterio;
                    pontuacaoTemp.Questionario.IdQuestionario = QuestionarioEmpresa.Questionario.IdQuestionario;
                    pontuacaoTemp.QuestionarioEmpresa.IdQuestionarioEmpresa = QuestionarioEmpresa.IdQuestionarioEmpresa;
                    if (resposta.UsuarioAvaliador.IdUsuario > 0)
                    {
                        pontuacaoTemp.Avaliador = true;
                    }
                    pontuacaoTemp.Ponto = resposta.Resposta.Ponto;
                }
                else
                {
                    pontuacaoTemp.Ponto += resposta.Resposta.Ponto;
                }

                //Verificação especial para FGA
                if (resposta.Pergunta.IdPergunta == 180 ||
                    resposta.Pergunta.IdPergunta == 181 ||
                    resposta.Pergunta.IdPergunta == 182 ||
                    resposta.Pergunta.IdPergunta == 187 ||
                    resposta.Pergunta.IdPergunta == 191 ||
                    resposta.Pergunta.IdPergunta == 194 ||
                    resposta.Pergunta.IdPergunta == 202)
                {
                    EntPerguntaResposta objPerguntaResposta = new BllPerguntaResposta().ObterPorId(resposta.Resposta.IdPerguntaResposta);
                    if (objPerguntaResposta.Ordem == 1 || objPerguntaResposta.Ordem == 2)
                    {
                        QuestionarioEmpresa.MarcaQuestoesEspeciais = true;
                    }
                    else
                    {
                        QuestionarioEmpresa.MarcaQuestoesEspeciais = false;
                    }
                }

            }
            listaPontuacao.Add(pontuacaoTemp);

            //Falta parte de resultados

            QuestionarioEmpresa.ListQuestionarioPontuacao = listaPontuacao;
            return QuestionarioEmpresa;
        }

        private EntQuestionarioEmpresa CalculaPontuacaoGestao2009(EntQuestionarioEmpresa QuestionarioEmpresa)
        {
            List<EntQuestionarioPontuacao> listaPontuacao = new List<EntQuestionarioPontuacao>();
            EntQuestionarioPontuacao pontuacaoTemp = new EntQuestionarioPontuacao();
            for(int i = 0; i < 30; i++){
                EntQuestionarioEmpresaResposta resposta = QuestionarioEmpresa.ListQuestionarioEmpresaResposta[i];
                if (pontuacaoTemp.Criterio.IdCriterio == 0){
                    pontuacaoTemp.Criterio.IdCriterio = resposta.Pergunta.Criterio.IdCriterio;
                    pontuacaoTemp.Questionario.IdQuestionario = QuestionarioEmpresa.Questionario.IdQuestionario;
                    pontuacaoTemp.QuestionarioEmpresa.IdQuestionarioEmpresa = QuestionarioEmpresa.IdQuestionarioEmpresa;
                    if(resposta.UsuarioAvaliador.IdUsuario > 0){
                        pontuacaoTemp.Avaliador = true;
                    }
                    pontuacaoTemp.Ponto = resposta.Resposta.Ponto;
                }else if(resposta.Pergunta.Criterio.IdCriterio != pontuacaoTemp.Criterio.IdCriterio){
                    listaPontuacao.Add(pontuacaoTemp);
                    pontuacaoTemp = new EntQuestionarioPontuacao();
                    pontuacaoTemp.Criterio.IdCriterio = resposta.Pergunta.Criterio.IdCriterio;
                    pontuacaoTemp.Questionario.IdQuestionario = QuestionarioEmpresa.Questionario.IdQuestionario;
                    pontuacaoTemp.QuestionarioEmpresa.IdQuestionarioEmpresa = QuestionarioEmpresa.IdQuestionarioEmpresa;
                    if (resposta.UsuarioAvaliador.IdUsuario > 0)
                    {
                        pontuacaoTemp.Avaliador = true;
                    }
                    pontuacaoTemp.Ponto = resposta.Resposta.Ponto;
                }else{
                    pontuacaoTemp.Ponto += resposta.Resposta.Ponto;
                }
            }
            listaPontuacao.Add(pontuacaoTemp);

            //Falta parte de resultados

            QuestionarioEmpresa.ListQuestionarioPontuacao = listaPontuacao;
            return QuestionarioEmpresa;
        }

        private EntQuestionarioEmpresa CalculaPontuacaoInovacao2011(EntQuestionarioEmpresa QuestionarioEmpresa)
        {
            List<EntQuestionarioPontuacao> listaPontuacao = new List<EntQuestionarioPontuacao>();
            EntQuestionarioPontuacao pontuacaoTemp = new EntQuestionarioPontuacao();
            for (int i = 0; i < QuestionarioEmpresa.ListQuestionarioEmpresaResposta.Count; i++)
            {
                EntQuestionarioEmpresaResposta resposta = QuestionarioEmpresa.ListQuestionarioEmpresaResposta[i];
                if (pontuacaoTemp.Criterio.IdCriterio == 0)
                {
                    pontuacaoTemp.Criterio.IdCriterio = resposta.Pergunta.Criterio.IdCriterio;
                    pontuacaoTemp.Questionario.IdQuestionario = QuestionarioEmpresa.Questionario.IdQuestionario;
                    pontuacaoTemp.QuestionarioEmpresa.IdQuestionarioEmpresa = QuestionarioEmpresa.IdQuestionarioEmpresa;
                    if (resposta.UsuarioAvaliador.IdUsuario > 0)
                    {
                        pontuacaoTemp.Avaliador = true;
                    }
                    pontuacaoTemp.Ponto = resposta.Resposta.Ponto;
                }
                else if (resposta.Pergunta.Criterio.IdCriterio != pontuacaoTemp.Criterio.IdCriterio || pontuacaoTemp.Avaliador != (resposta.UsuarioAvaliador.IdUsuario > 0))
                {
                    listaPontuacao.Add(pontuacaoTemp);
                    pontuacaoTemp = new EntQuestionarioPontuacao();
                    pontuacaoTemp.Criterio.IdCriterio = resposta.Pergunta.Criterio.IdCriterio;
                    pontuacaoTemp.Questionario.IdQuestionario = QuestionarioEmpresa.Questionario.IdQuestionario;
                    pontuacaoTemp.QuestionarioEmpresa.IdQuestionarioEmpresa = QuestionarioEmpresa.IdQuestionarioEmpresa;
                    if (resposta.UsuarioAvaliador.IdUsuario > 0)
                    {
                        pontuacaoTemp.Avaliador = true;
                    }
                    pontuacaoTemp.Ponto = resposta.Resposta.Ponto;
                }
                else
                {
                    pontuacaoTemp.Ponto += resposta.Resposta.Ponto;
                }
            }
            listaPontuacao.Add(pontuacaoTemp);

            //Falta parte de resultados

            QuestionarioEmpresa.ListQuestionarioPontuacao = listaPontuacao;
            return QuestionarioEmpresa;
        }

        private EntQuestionarioEmpresa CalculaPontuacaoEmpreendedorismo2009(EntQuestionarioEmpresa QuestionarioEmpresa)
        {
            List<EntQuestionarioPontuacao> listaPontuacao = new List<EntQuestionarioPontuacao>();
            EntQuestionarioPontuacao pontuacaoTemp = new EntQuestionarioPontuacao();

            //Pontuação da afirmação 1 - pontuação da afirmação 3 + pontuação da afirmação16 + 8 pontos.
            listaPontuacao.Add(MontaQuestionarioPontuacao(QuestionarioEmpresa.ListQuestionarioEmpresaResposta, 0, 2, 15, QuestionarioEmpresa.Questionario.IdQuestionario));

            //Pontuação da afirmação 2 - pontuação da afirmação 6 + pontuação da afirmação 17+ 8 pontos.
            listaPontuacao.Add(MontaQuestionarioPontuacao(QuestionarioEmpresa.ListQuestionarioEmpresaResposta, 1, 5, 16, QuestionarioEmpresa.Questionario.IdQuestionario));

            //Pontuação da afirmação 4 - pontuação da afirmação 9 + pontuação da afirmação 19 + 8 pontos.
            listaPontuacao.Add(MontaQuestionarioPontuacao(QuestionarioEmpresa.ListQuestionarioEmpresaResposta, 3, 8, 18, QuestionarioEmpresa.Questionario.IdQuestionario));

            //Pontuação da afirmação 5 - pontuação da afirmação 12 + pontuação da afirmação 20 + 8 pontos.
            listaPontuacao.Add(MontaQuestionarioPontuacao(QuestionarioEmpresa.ListQuestionarioEmpresaResposta, 4, 11, 19, QuestionarioEmpresa.Questionario.IdQuestionario));

            //Pontuação da afirmação 7 - pontuação da afirmação 15 + pontuação da afirmação 22 + 8 pontos.
            listaPontuacao.Add(MontaQuestionarioPontuacao(QuestionarioEmpresa.ListQuestionarioEmpresaResposta, 6, 14, 21, QuestionarioEmpresa.Questionario.IdQuestionario));

            //Pontuação da afirmação 8 - Pontuação da afirmação 18 + Pontuação da afirmação 23 + 8 pontos.
            listaPontuacao.Add(MontaQuestionarioPontuacao(QuestionarioEmpresa.ListQuestionarioEmpresaResposta, 7, 17, 22, QuestionarioEmpresa.Questionario.IdQuestionario));

            //Pontuação da afirmação 10 - pontuação da afirmação 21 + pontuação da afirmação 25 + 8 pontos.
            listaPontuacao.Add(MontaQuestionarioPontuacao(QuestionarioEmpresa.ListQuestionarioEmpresaResposta, 9, 20, 24, QuestionarioEmpresa.Questionario.IdQuestionario));

            //Pontuação da afirmação 11 - pontuação da afirmação 24 + pontuação da afirmação 26 + 8 pontos.
            listaPontuacao.Add(MontaQuestionarioPontuacao(QuestionarioEmpresa.ListQuestionarioEmpresaResposta, 10, 23, 25, QuestionarioEmpresa.Questionario.IdQuestionario));

            //Pontuação da afirmação 13 - pontuação da afirmação 27+ pontuação da afirmação 28 + 8 pontos.
            listaPontuacao.Add(MontaQuestionarioPontuacao(QuestionarioEmpresa.ListQuestionarioEmpresaResposta, 12, 26, 27, QuestionarioEmpresa.Questionario.IdQuestionario));

            //Pontuação da afirmação 14 - pontuação da afirmação 30 + pontuação da afirmação 29 + 8 pontos.
            listaPontuacao.Add(MontaQuestionarioPontuacao(QuestionarioEmpresa.ListQuestionarioEmpresaResposta, 13, 29, 28, QuestionarioEmpresa.Questionario.IdQuestionario));

            if(QuestionarioEmpresa.ListQuestionarioEmpresaResposta.Count > 30){
                //Pontuação da afirmação 1 - pontuação da afirmação 3 + pontuação da afirmação16 + 8 pontos.
                listaPontuacao.Add(MontaQuestionarioPontuacao(QuestionarioEmpresa.ListQuestionarioEmpresaResposta, 30, 32, 45, QuestionarioEmpresa.Questionario.IdQuestionario));

                //Pontuação da afirmação 2 - pontuação da afirmação 6 + pontuação da afirmação 17+ 8 pontos.
                listaPontuacao.Add(MontaQuestionarioPontuacao(QuestionarioEmpresa.ListQuestionarioEmpresaResposta, 31, 35, 46, QuestionarioEmpresa.Questionario.IdQuestionario));

                //Pontuação da afirmação 4 - pontuação da afirmação 9 + pontuação da afirmação 19 + 8 pontos.
                listaPontuacao.Add(MontaQuestionarioPontuacao(QuestionarioEmpresa.ListQuestionarioEmpresaResposta, 33, 38, 48, QuestionarioEmpresa.Questionario.IdQuestionario));

                //Pontuação da afirmação 5 - pontuação da afirmação 12 + pontuação da afirmação 20 + 8 pontos.
                listaPontuacao.Add(MontaQuestionarioPontuacao(QuestionarioEmpresa.ListQuestionarioEmpresaResposta, 34, 41, 49, QuestionarioEmpresa.Questionario.IdQuestionario));

                //Pontuação da afirmação 7 - pontuação da afirmação 15 + pontuação da afirmação 22 + 8 pontos.
                listaPontuacao.Add(MontaQuestionarioPontuacao(QuestionarioEmpresa.ListQuestionarioEmpresaResposta, 36, 44, 51, QuestionarioEmpresa.Questionario.IdQuestionario));

                //Pontuação da afirmação 8 - Pontuação da afirmação 18 + Pontuação da afirmação 23 + 8 pontos.
                listaPontuacao.Add(MontaQuestionarioPontuacao(QuestionarioEmpresa.ListQuestionarioEmpresaResposta, 37, 47, 52, QuestionarioEmpresa.Questionario.IdQuestionario));

                //Pontuação da afirmação 10 - pontuação da afirmação 21 + pontuação da afirmação 25 + 8 pontos.
                listaPontuacao.Add(MontaQuestionarioPontuacao(QuestionarioEmpresa.ListQuestionarioEmpresaResposta, 39, 50, 54, QuestionarioEmpresa.Questionario.IdQuestionario));

                //Pontuação da afirmação 11 - pontuação da afirmação 24 + pontuação da afirmação 26 + 8 pontos.
                listaPontuacao.Add(MontaQuestionarioPontuacao(QuestionarioEmpresa.ListQuestionarioEmpresaResposta, 40, 53, 55, QuestionarioEmpresa.Questionario.IdQuestionario));

                //Pontuação da afirmação 13 - pontuação da afirmação 27+ pontuação da afirmação 28 + 8 pontos.
                listaPontuacao.Add(MontaQuestionarioPontuacao(QuestionarioEmpresa.ListQuestionarioEmpresaResposta, 42, 56, 57, QuestionarioEmpresa.Questionario.IdQuestionario));

                //Pontuação da afirmação 14 - pontuação da afirmação 30 + pontuação da afirmação 29 + 8 pontos.
                listaPontuacao.Add(MontaQuestionarioPontuacao(QuestionarioEmpresa.ListQuestionarioEmpresaResposta, 43, 59, 58, QuestionarioEmpresa.Questionario.IdQuestionario));
            }

            QuestionarioEmpresa.ListQuestionarioPontuacao = listaPontuacao;
            return QuestionarioEmpresa;
        }

        private EntQuestionarioEmpresa CalculaPontuacaoEmpreendedorismo2011(EntQuestionarioEmpresa QuestionarioEmpresa)
        {
            List<EntQuestionarioPontuacao> listaPontuacao = new List<EntQuestionarioPontuacao>();
            EntQuestionarioPontuacao pontuacaoTemp = new EntQuestionarioPontuacao();

            //Pontuação da afirmação 1 - pontuação da afirmação 3 + pontuação da afirmação16 + 8 pontos.
            listaPontuacao.Add(MontaQuestionarioPontuacao(QuestionarioEmpresa.ListQuestionarioEmpresaResposta, 3, 20, 28, QuestionarioEmpresa.Questionario.IdQuestionario));

            //Pontuação da afirmação 2 - pontuação da afirmação 6 + pontuação da afirmação 17+ 8 pontos.
            listaPontuacao.Add(MontaQuestionarioPontuacao(QuestionarioEmpresa.ListQuestionarioEmpresaResposta, 19, 23, 24, QuestionarioEmpresa.Questionario.IdQuestionario));

            //Pontuação da afirmação 4 - pontuação da afirmação 9 + pontuação da afirmação 19 + 8 pontos.
            listaPontuacao.Add(MontaQuestionarioPontuacao(QuestionarioEmpresa.ListQuestionarioEmpresaResposta, 4, 8, 29, QuestionarioEmpresa.Questionario.IdQuestionario));

            //Pontuação da afirmação 5 - pontuação da afirmação 12 + pontuação da afirmação 20 + 8 pontos.
            listaPontuacao.Add(MontaQuestionarioPontuacao(QuestionarioEmpresa.ListQuestionarioEmpresaResposta, 6, 12, 15, QuestionarioEmpresa.Questionario.IdQuestionario));

            //Pontuação da afirmação 7 - pontuação da afirmação 15 + pontuação da afirmação 22 + 8 pontos.
            listaPontuacao.Add(MontaQuestionarioPontuacao(QuestionarioEmpresa.ListQuestionarioEmpresaResposta, 2, 9, 25, QuestionarioEmpresa.Questionario.IdQuestionario));

            //Pontuação da afirmação 8 - Pontuação da afirmação 18 + Pontuação da afirmação 23 + 8 pontos.
            listaPontuacao.Add(MontaQuestionarioPontuacao(QuestionarioEmpresa.ListQuestionarioEmpresaResposta, 11, 13, 26, QuestionarioEmpresa.Questionario.IdQuestionario));

            //Pontuação da afirmação 10 - pontuação da afirmação 21 + pontuação da afirmação 25 + 8 pontos.
            listaPontuacao.Add(MontaQuestionarioPontuacao(QuestionarioEmpresa.ListQuestionarioEmpresaResposta, 0, 10, 27, QuestionarioEmpresa.Questionario.IdQuestionario));

            //Pontuação da afirmação 11 - pontuação da afirmação 24 + pontuação da afirmação 26 + 8 pontos.
            listaPontuacao.Add(MontaQuestionarioPontuacao(QuestionarioEmpresa.ListQuestionarioEmpresaResposta, 14, 17, 22, QuestionarioEmpresa.Questionario.IdQuestionario));

            //Pontuação da afirmação 13 - pontuação da afirmação 27+ pontuação da afirmação 28 + 8 pontos.
            listaPontuacao.Add(MontaQuestionarioPontuacao(QuestionarioEmpresa.ListQuestionarioEmpresaResposta, 1, 18, 21, QuestionarioEmpresa.Questionario.IdQuestionario));

            //Pontuação da afirmação 14 - pontuação da afirmação 30 + pontuação da afirmação 29 + 8 pontos.
            listaPontuacao.Add(MontaQuestionarioPontuacao(QuestionarioEmpresa.ListQuestionarioEmpresaResposta, 5, 7, 16, QuestionarioEmpresa.Questionario.IdQuestionario));

            if (QuestionarioEmpresa.ListQuestionarioEmpresaResposta.Count > 30)
            {
                //Pontuação da afirmação 1 - pontuação da afirmação 3 + pontuação da afirmação16 + 8 pontos.
                listaPontuacao.Add(MontaQuestionarioPontuacao(QuestionarioEmpresa.ListQuestionarioEmpresaResposta, 33, 50, 58, QuestionarioEmpresa.Questionario.IdQuestionario));

                //Pontuação da afirmação 2 - pontuação da afirmação 6 + pontuação da afirmação 17+ 8 pontos.
                listaPontuacao.Add(MontaQuestionarioPontuacao(QuestionarioEmpresa.ListQuestionarioEmpresaResposta, 49, 53, 54, QuestionarioEmpresa.Questionario.IdQuestionario));

                //Pontuação da afirmação 4 - pontuação da afirmação 9 + pontuação da afirmação 19 + 8 pontos.
                listaPontuacao.Add(MontaQuestionarioPontuacao(QuestionarioEmpresa.ListQuestionarioEmpresaResposta, 34, 38, 59, QuestionarioEmpresa.Questionario.IdQuestionario));

                //Pontuação da afirmação 5 - pontuação da afirmação 12 + pontuação da afirmação 20 + 8 pontos.
                listaPontuacao.Add(MontaQuestionarioPontuacao(QuestionarioEmpresa.ListQuestionarioEmpresaResposta, 36, 42, 45, QuestionarioEmpresa.Questionario.IdQuestionario));

                //Pontuação da afirmação 7 - pontuação da afirmação 15 + pontuação da afirmação 22 + 8 pontos.
                listaPontuacao.Add(MontaQuestionarioPontuacao(QuestionarioEmpresa.ListQuestionarioEmpresaResposta, 32, 39, 55, QuestionarioEmpresa.Questionario.IdQuestionario));

                //Pontuação da afirmação 8 - Pontuação da afirmação 18 + Pontuação da afirmação 23 + 8 pontos.
                listaPontuacao.Add(MontaQuestionarioPontuacao(QuestionarioEmpresa.ListQuestionarioEmpresaResposta, 41, 43, 56, QuestionarioEmpresa.Questionario.IdQuestionario));

                //Pontuação da afirmação 10 - pontuação da afirmação 21 + pontuação da afirmação 25 + 8 pontos.
                listaPontuacao.Add(MontaQuestionarioPontuacao(QuestionarioEmpresa.ListQuestionarioEmpresaResposta, 30, 40, 57, QuestionarioEmpresa.Questionario.IdQuestionario));

                //Pontuação da afirmação 11 - pontuação da afirmação 24 + pontuação da afirmação 26 + 8 pontos.
                listaPontuacao.Add(MontaQuestionarioPontuacao(QuestionarioEmpresa.ListQuestionarioEmpresaResposta, 44, 47, 52, QuestionarioEmpresa.Questionario.IdQuestionario));

                //Pontuação da afirmação 13 - pontuação da afirmação 27+ pontuação da afirmação 28 + 8 pontos.
                listaPontuacao.Add(MontaQuestionarioPontuacao(QuestionarioEmpresa.ListQuestionarioEmpresaResposta, 31, 48, 51, QuestionarioEmpresa.Questionario.IdQuestionario));

                //Pontuação da afirmação 14 - pontuação da afirmação 30 + pontuação da afirmação 29 + 8 pontos.
                listaPontuacao.Add(MontaQuestionarioPontuacao(QuestionarioEmpresa.ListQuestionarioEmpresaResposta, 35, 37, 46, QuestionarioEmpresa.Questionario.IdQuestionario));
            }

            QuestionarioEmpresa.ListQuestionarioPontuacao = listaPontuacao;
            return QuestionarioEmpresa;
        }

        private EntQuestionarioPontuacao MontaQuestionarioPontuacao(List<EntQuestionarioEmpresaResposta> ListQuestionarioEmpresaResposta, Int32 resposta1, Int32 resposta2, Int32 resposta3, Int32 IdQuestionario)
        {
            EntQuestionarioPontuacao p1 = new EntQuestionarioPontuacao();
            p1.Ponto = ListQuestionarioEmpresaResposta[resposta1].Resposta.Ponto - ListQuestionarioEmpresaResposta[resposta2].Resposta.Ponto + ListQuestionarioEmpresaResposta[resposta3].Resposta.Ponto + 8;
            p1.Criterio.IdCriterio = ListQuestionarioEmpresaResposta[resposta1].Pergunta.Criterio.IdCriterio;
            p1.Questionario.IdQuestionario = IdQuestionario;
            p1.Avaliador = ListQuestionarioEmpresaResposta[resposta1].UsuarioAvaliador.IdUsuario > 0;
            p1.QuestionarioEmpresa.IdQuestionarioEmpresa = ListQuestionarioEmpresaResposta[resposta1].QuestionarioEmpresa.IdQuestionarioEmpresa;

            decimal valor = ((p1.Ponto / 250) * 100);
            p1.Ponto = Math.Round(valor, 2);

            return p1;
        }

        private EntQuestionarioEmpresa CalculaPontuacaoResponsabilidadeSocial2011(EntQuestionarioEmpresa QuestionarioEmpresa)
        {
            List<EntQuestionarioPontuacao> listaPontuacao = new List<EntQuestionarioPontuacao>();
            EntQuestionarioPontuacao pontuacaoTemp = new EntQuestionarioPontuacao();
            for (int i = 0; i < QuestionarioEmpresa.ListQuestionarioEmpresaResposta.Count; i++)
            {
                EntQuestionarioEmpresaResposta resposta = QuestionarioEmpresa.ListQuestionarioEmpresaResposta[i];
                if (pontuacaoTemp.Criterio.IdCriterio == 0)
                {
                    pontuacaoTemp.Criterio.IdCriterio = resposta.Pergunta.Criterio.IdCriterio;
                    pontuacaoTemp.Questionario.IdQuestionario = QuestionarioEmpresa.Questionario.IdQuestionario;
                    pontuacaoTemp.QuestionarioEmpresa.IdQuestionarioEmpresa = QuestionarioEmpresa.IdQuestionarioEmpresa;
                    if (resposta.UsuarioAvaliador.IdUsuario > 0)
                    {
                        pontuacaoTemp.Avaliador = true;
                    }
                    pontuacaoTemp.Ponto = resposta.Resposta.Ponto;
                }
                else if (resposta.Pergunta.Criterio.IdCriterio != pontuacaoTemp.Criterio.IdCriterio || pontuacaoTemp.Avaliador != (resposta.UsuarioAvaliador.IdUsuario > 0))
                {
                    listaPontuacao.Add(pontuacaoTemp);
                    pontuacaoTemp = new EntQuestionarioPontuacao();
                    pontuacaoTemp.Criterio.IdCriterio = resposta.Pergunta.Criterio.IdCriterio;
                    pontuacaoTemp.Questionario.IdQuestionario = QuestionarioEmpresa.Questionario.IdQuestionario;
                    pontuacaoTemp.QuestionarioEmpresa.IdQuestionarioEmpresa = QuestionarioEmpresa.IdQuestionarioEmpresa;
                    if (resposta.UsuarioAvaliador.IdUsuario > 0)
                    {
                        pontuacaoTemp.Avaliador = true;
                    }
                    pontuacaoTemp.Ponto = resposta.Resposta.Ponto;
                }
                else
                {
                    pontuacaoTemp.Ponto += resposta.Resposta.Ponto;
                }
            }
            listaPontuacao.Add(pontuacaoTemp);

            //Falta parte de resultados

            QuestionarioEmpresa.ListQuestionarioPontuacao = listaPontuacao;
            return QuestionarioEmpresa;
        }

        private EntQuestionarioEmpresa CalculaPontuacaoResponsabilidadeSocial2009(EntQuestionarioEmpresa QuestionarioEmpresa)
        {
            return QuestionarioEmpresa;
        }
    }
}
