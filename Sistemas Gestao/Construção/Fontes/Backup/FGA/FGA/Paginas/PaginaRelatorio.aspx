<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PaginaRelatorio.aspx.cs"
    Inherits="Sistema_de_Gestao.FGA.Paginas.PaginaRelatorio" %>

<%@ Register Src="~/MPE/User Control/UCRelatorioPergunta.ascx" TagName="UCRelatorioPerguntaCliente"
    TagPrefix="uc1" %>
<%@ Register Src="~/MPE/User Control/UCRelatorioPergunta.ascx" TagName="UCRelatorioPerguntaSociedade"
    TagPrefix="uc2" %>
<%@ Register Src="~/MPE/User Control/UCRelatorioPergunta.ascx" TagName="UCRelatorioPerguntaLideranca"
    TagPrefix="uc3" %>
<%@ Register Src="~/MPE/User Control/UCRelatorioPergunta.ascx" TagName="UCRelatorioPerguntaEstrategia"
    TagPrefix="uc4" %>
<%@ Register Src="~/MPE/User Control/UCRelatorioPergunta.ascx" TagName="UCRelatorioPerguntaPessoas"
    TagPrefix="uc5" %>
<%@ Register Src="~/MPE/User Control/UCRelatorioPergunta.ascx" TagName="UCRelatorioPerguntaProcessos"
    TagPrefix="uc6" %>
<%@ Register Src="~/MPE/User Control/UCRelatorioPergunta.ascx" TagName="UCRelatorioPerguntaInformacaoConhecimento"
    TagPrefix="uc7" %>
<%@ Register Src="~/MPE/User Control/UCRelatorioPergunta.ascx" TagName="UCRelatorioPerguntaResultado"
    TagPrefix="uc8" %>
<%@ Register Src="~/MPE/User Control/UCRelatorioPergunta.ascx" TagName="UCRelatorioPerguntaResponsabilidadeSocial"
    TagPrefix="uc9" %>
<%@ Register Src="~/MPE/User Control/UCRelatorioPergunta.ascx" TagName="UCRelatorioPerguntaInovacao"
    TagPrefix="uc10" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <style type="text/css">
        BODY
        {
            font-size: 9pt;
            background: #ffffff;
            color: #000000;
            font-family: Arial;
        }
        TD
        {
            font-size: 9pt;
            color: #000000;
            font-family: Arial;
        }
        P
        {
            font-size: 9pt;
            color: #000000;
            font-family: Arial;
        }
        .style2
        {
            font-size: 16px;
        }
        .style3
        {
            width: 295px;
        }
        .style5
        {
            width: 614px;
        }
        .style7
        {
            line-height: 150%;
            text-align: justify;
            font-size: medium;
            font-family: Arial;
            color: black;
            margin-left: 2cm;
            margin-right: -.3pt;
            margin-top: 12.0pt;
            margin-bottom: 10pt;
        }
        .style9
        {
            text-indent: -31.2pt;
            line-height: 150%;
            text-align: justify;
            font-size: 12.0pt;
            font-family: Verdana;
            color: teal;
            margin-left: 59.55pt;
            margin-right: 0cm;
            margin-top: 6.0pt;
            margin-bottom: .0001pt;
        }
        .newStyle1
        {
            font-size: large;
        }
        .style10Title
        {
            font-size: medium;
            line-height: 150%;
            margin-left: 2cm;
            margin-right: -.3pt;
            margin-top: 12.0pt;
            margin-bottom: 10pt;
        }
        .style11
        {
            line-height: 150%;
            font-family: Arial, sans-serif;
            font-size: small;
            margin-left: 2cm;
            margin-right: -.3pt;
            margin-top: 12.0pt;
            margin-bottom: 10pt;
        }
        .style13
        {
            text-align: justify;
            line-height: 150%;
            font-family: Arial, sans-serif;
            font-size: medium;
            color: black;
            margin-left: 2cm;
            margin-right: -.3pt;
            margin-top: 12.0pt;
            margin-bottom: 10pt;
        }
        .style13b
        {
            text-align: justify;
            line-height: 150%;
            font-family: Arial, sans-serif;
            font-size: medium;
            color: black;
        }
        .style13Title
        {
            line-height: 150%;
            font-family: Arial, sans-serif;
            font-size: medium;
        }
        .style15
        {
            font-size: medium;
            font-weight: normal;
        }
        .style16
        {
            text-align: justify;
            line-height: 150%;
            font-family: Arial, sans-serif;
            font-size: medium;
            color: black;
            margin-left: 2cm;
            margin-right: -.3pt;
            margin-top: 12.0pt;
            margin-bottom: 10pt;
        }
        .style17
        {
            text-align: justify;
            line-height: 150%;
            font-family: Arial, sans-serif;
            font-size: medium;
            color: black;
            margin-left: 2cm;
            margin-right: -.3pt;
            margin-top: 12.0pt;
            margin-bottom: 10pt;
        }
        .style18
        {
            text-align: justify;
            line-height: 150%;
            font-family: Arial, sans-serif;
            font-size: medium;
            margin-left: 2cm;
            margin-right: -.3pt;
            margin-top: 12.0pt;
            margin-bottom: 10pt;
        }
        .style19
        {
            text-align: justify;
            line-height: 150%;
            font-family: Arial, sans-serif;
            font-size: medium;
            margin-left: 2cm;
            margin-right: -.3pt;
            margin-top: 12.0pt;
            margin-bottom: 10pt;
        }
        .style20
        {
            text-indent: -31.2pt;
            line-height: 150%;
            text-align: justify;
            font-size: medium;
            font-family: Arial;
            color: windowtext;
            margin-left: 59.55pt;
            margin-right: 0cm;
            margin-top: 6.0pt;
            margin-bottom: .0001pt;
        }
        .style23
        {
            text-align: justify;
            line-height: 150%;
            font-family: Arial, sans-serif;
            color: black;
            margin-left: 2cm;
            margin-right: -.3pt;
            margin-top: 12.0pt;
            margin-bottom: 10pt;
        }
    </style>
    <title></title>
</head>
<body>
    <form id="Form2" runat="server">
    <div align="center" id="imgIntro" runat="server">
        <asp:Image runat="server" ID="imgAA" alt="" ImageUrl="~/Image/Mpe/img_auto_2010.jpg"
            Width="859" Height="1134" Visible="true" />
        <asp:Image runat="server" ID="imgA" alt="" ImageUrl="~/Image/Mpe/img_aval_2010.jpg"
            Width="859" Height="1134" Visible="false" />
        <div style="page-break-before: always">
        </div>
    </div>
    <div align="left" class="style2" style="width: 859px">
        <div class="style2" id="introTxt" runat="server" align="left">
            <p>
                Prezado(a) Empresário(a)
            </p>
            <p>
                Este relatório apresenta os pontos fortes e as oportunidades para melhoria de sua empresa. 
                Ele foi elaborado com base em sua autoavaliação. Nossa expectativa é que os comentários e informações 
                nele apresentados possam auxiliar na definição de ações de melhoria para seu negócio.</p>
            <p>
                Os comentários nele apresentados retratam o grau de maturidade da gestão de sua empresa em relação ao Modelo de Excelência da Gestão® adaptado para a realidade de pequenas empresas, e seu conteúdo está estruturado da seguinte forma:</p>
            <ol type="1" start="1">
                <li>Informações sobre os Fundamentos de Excelência e Modelo de Excelência da Gestão® da Fundação Nacional da Qualidade;</li>
                <li>Recomendações de seu negócio a partir do ciclo PDCL (Planejar, Fazer, Executar, Controlar e Aprender);</li>
                <li>Pontuação obtida a partir do questionário respondido sobre a gestão da empresa, apresentado no gráfico Radar;</li>
                <li>Comentários com Pontos Fortes e Oportunidades para Melhoria para cada questão respondida.</li>
            </ol>
            <p>
                Atenciosamente</p>
            <p>
                Fundação Nacional da Qualidade – FNQ e <br />
                Serviço Brasileiro de Apoio às Micro e Pequenas Empresas - SEBRAE
                </p>
        </div>
        <div style="page-break-before: always">
        </div>
        <div class="style11 style5 style2">
            <p align="center" class="style13Title">
                <b>DADOS DA EMPRESA</b>
            </p>
            <table cellspacing="2" cellpadding="1" width="100%" border="0" class="style11">
                <tr class="tdAzulMedio">
                    <td>
                        <span>Razão Social:</span>
                    </td>
                    <td>
                        <asp:Label ID="lblRazaoSocial" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr class="tdAzulClaro">
                    <td>
                        <span>Nome Fantasia:</span>
                    </td>
                    <td>
                        <asp:Label ID="lblNomeFantasia" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr class="tdAzulMedio">
                    <td>
                        <span>Setor:</span>
                    </td>
                    <td>
                        <asp:Label ID="lblCategoria" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr class="tdAzulClaro">
                    <td>
                        <span>Atividade Econômica (CNAE):</span>
                    </td>
                    <td>
                        <asp:Label ID="lblCNAE" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr class="tdAzulMedio">
                    <td>
                        <span>Principal Atividade:</span>
                    </td>
                    <td>
                        <asp:Label ID="lblAtividadeEconomicaTxt" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr class="tdAzulClaro">
                    <td>
                        <span>CNPJ:</span>
                    </td>
                    <td>
                        <asp:Label ID="lblCPFCNPJ" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr class="tdAzulMedio">
                    <td>
                        <span>Faturamento anual em R$ (Reais):</span>
                    </td>
                    <td>
                        <span>
                            <asp:Label ID="lblFaturamento" runat="server"></asp:Label>
                        </span>
                    </td>
                </tr>
                <tr class="tdAzulClaro">
                    <td height="21">
                        <span>Colaboradores:</span>
                    </td>
                    <td>
                        <asp:Label ID="lblEmpregados" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr class="tdAzulMedio">
                    <td>
                        <span>Data de Abertura:</span>
                    </td>
                    <td>
                        <asp:Label ID="lblDataAbertura" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr class="tdAzulClaro">
                    <td>
                        <span>Bairro:</span>
                    </td>
                    <td>
                        <asp:Label ID="lblBairro" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr class="tdAzulMedio">
                    <td>
                        <span>Endereço:</span>
                    </td>
                    <td>
                        <asp:Label ID="lblEndereco" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr class="tdAzulClaro">
                    <td>
                        <span>CEP:</span>
                    </td>
                    <td>
                        <asp:Label ID="lblCEP" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr class="tdAzulMedio">
                    <td>
                        <span>Cidade/Estado:</span>
                    </td>
                    <td>
                        <asp:Label ID="lblCidade" runat="server"></asp:Label>
                        -
                        <asp:Label ID="lblEstado" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" height="0">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td class="tdAzulEscuro" colspan="2">
                        <span>Dados do Contato da Empresa</span>
                    </td>
                </tr>
                <tr class="tdAzulMedio">
                    <td>
                        <span>Nome:</span>
                    </td>
                    <td>
                        <asp:Label ID="lblContatoNome" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr class="tdAzulClaro">
                    <td>
                        <span>Cargo:</span>
                    </td>
                    <td>
                        <asp:Label ID="lblContatoCargo" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr class="tdAzulMedio">
                    <td>
                        <span>Telefone Fixo:</span>
                    </td>
                    <td>
                        <asp:Label ID="lblContatoTelefone" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr class="tdAzulClaro">
                    <td>
                        <span>Celular:</span>
                    </td>
                    <td>
                        <asp:Label ID="lblContatoCelular" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr class="tdAzulMedio">
                    <td>
                        <span>E-mail:</span>
                    </td>
                    <td>
                        <asp:Label ID="lblContatoEmail" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
        <div style="page-break-before: always">
        </div>
        <div id="introTxt2" runat="server">
            <p style="font-weight: bold; text-align: center;">
                RELATÓRIO DE AUTOAVALIAÇÃO
                <br />
                PROGRAMA FERRAMENTAS DE GESTÃO AVANAÇADA
                <br />
                ANO 2011
            </p>
            <p align="center" class="style13Title">
                <b>GESTÃO DA EMPRESA</b>
            </p>
            <p>
                <b>INTRODUÇÃO</b>
            </p>
            <p>
                O questionário de Autoavaliação do Programa Ferramentas de Gestão Avançada - FGA é baseado no Modelo de Excelência da Gestão® - 
                MEG da Fundação Nacional da Qualidade (FNQ) adotado por inúmeras empresas. O MEG tem como base os 11 Fundamentos de Excelência da 
                Gestão, que são conceitos reconhecidos mundialmente encontrados em empresas que já atingiram patamares de Excelência, ou que estão 
                caminhando nessa direção. Cabe destacar que esses Fundamentos são aplicáveis a qualquer empresa, uma vez que tratam, de forma genérica, 
                dos mais modernos conceitos de gestão. São eles:</p>
            <ul>
                <li>1. PENSAMENTO SISTÊMICO</li>
                <li>2. APRENDIZADO ORGANIZACIONAL</li>
                <li>3. CULTURA DE INOVAÇÃO</li>
                <li>4. LIDERANÇA E CONSTÂNCIA DE PROPÓSITOS</li>
                <li>5. ORIENTAÇÃO POR PROCESSOS E INFORMAÇÕES</li>
                <li>6. VISÃO DE FUTURO</li>
                <li>7. GERAÇÃO DE VALOR</li>
                <li>8. VALORIZAÇÃO DAS PESSOAS</li>
                <li>9. CONHECIMENTO SOBRE O CLIENTE E O MERCADO</li>
                <li>10. DESENVOLVIMENTO DE PARCERIAS</li>
                <li>11. RESPONSABILIDADE SOCIAL</li>
            </ul>
            <p>
                Para conhecer mais sobre os Fundamentos de Excelência, sugere-se a leitura da publicação
                “Conceitos Fundamentais da Excelência em Gestão” da FNQ, disponível para download
                gratuito no Portal da FNQ <b>www.fnq.org.br</b>.
            </p>
            <p>
                Buscando o aumento da competitividade das organizações e do Brasil, a FNQ vem disseminando os Fundamentos da Excelência por meio 
                do Modelo de Excelência da Gestão® (MEG), apresentado em 4 versões de avaliação das empresas:</p>
            <p>
                • Programa de Empresas Avançadas e o MPE Brasil – questionários que apresentam o Modelo de Excelência da Gestão® 
                simplificado e adaptado para a realidade das micro e pequenas empresas que estão iniciando a caminhada rumo à excelência da gestão;</p>
            <p>
                • Compromisso com a Excelência – para empresas em fase inicial de adoção do Modelo de Excelência da Gestão® (adotado pela Rede de Prêmios da FNQ)</p>
            <p>
                • Rumo à Excelência – para empresas em fase intermediária de adoção do Modelo de Excelência da Gestão® (adotado pela Rede de Prêmios da FNQ)</p>
            <p>
                • Critérios de Excelência – para empresas que já estão maduras para buscarem o reconhecimento de Classe Mundial (adotado pelas empresas participantes dos ciclos de avaliação do PNQ).</p>
            <p>
                Sendo o Modelo de Excelência da Gestão® (MEG) a aplicação dos Fundamentos de Excelência, em função de sua flexibilidade e simplicidade de linguagem, é útil, então, para avaliação, diagnóstico e orientação de qualquer tipo de empresa no setor público e privado, com ou sem finalidade de lucro, e de porte pequeno, médio ou grande.
            </p>
            <p>
                O MEG é constituído por 8 Critérios:
                <br />
                <ul>
                    <li><b>1. Liderança:</b> critério que trata da forma como o empresário conduz o seu negócio,
                        define rumos, analisa o desempenho da sua empresa e aprimora o conhecimento dos
                        seus líderes.</li>
                    <li><b>2. Estratégias e Planos:</b> critério que trata da definição das estratégias da empresa
                        (caminhos ou rumos escolhidos para se alcançar a sua visão de futuro), do desdobramento
                        destas em metas e planos de ação, incluindo a definição de indicadores de desempenho.</li>
                    <li><b>3. Clientes:</b> este critério trata do conhecimento que a empresa tem dos seus clientes
                        e mercados, da identificação de suas necessidades e do seu grau de satisfação, e
                        de como suas reclamações são tratadas.</li>
                    <li><b>4. Sociedade:</b> este critério trata da identificação dos impactos ambientais decorrentes
                        dos produtos, processos e instalações da empresa e ainda da sua prática de ações
                        relativas à responsabilidade social.</li>
                    <li><b>5. Informações e Conhecimento:</b> critério que trata da identificação e uso de informações
                        necessárias para a execução das atividades da empresa, bem como de informações comparativas
                        para auxiliar na análise e melhoria do seu desempenho.</li>
                    <li><b>6. Pessoas:</b> critério que trata da estrutura organizacional, do reconhecimento, capacitação
                        e desenvolvimento dos colaboradores e das ações voltadas para a qualidade de vida
                        no trabalho, a fim de melhorar o desempenho das pessoas e da empresa.</li>
                    <li><b>7. Processos:</b> critério que trata da definição e gerenciamento dos processos principais
                        do negócio da empresa (produção, prestação de serviço, manufatura, comercialização)
                        e daqueles necessários para que a sua execução ocorra sem problemas (processos de
                        apoio); bem como do gerenciamento dos seus principais fornecedores e dos recursos
                        financeiros da empresa.</li>
                    <li><b>8. Resultados:</b> este critério solicita os resultados de indicadores de desempenho
                        da empresa relativos à clientes, sociedade, pessoas, processos, financeiros e relativos
                        aos fornecedores.</li>
                </ul>
            </p>
            <p>
                O Modelo de Excelência da Gestão® é apresentado pelo diagrama abaixo; ele representa
                uma visão global da gestão da empresa.
            </p>
            <div align="center">
                <asp:Image runat="server" ID="Image1" alt="" ImageUrl="~/Image/Mpe/ModeloExcelenciaGestao.JPG"
                    Width="301" Height="301" Visible="true" />
            </div>
            <p>
                Os <b>resultados</b> são mensurados, gerando <b>informações e conhecimento</b> que
                serão analisados para buscar o aprendizado da empresa.</p>
            <p>
                A adoção do MEG faz com que a empresa obtenha:
                <ul>
                    <li>· Melhorias em processos e produtos;</li>
                    <li>· Redução de custos;</li>
                    <li>· Aumento da produtividade, e consequentemente, de sua competitividade;</li>
                    <li>· Aumento da credibilidade da empresa e o reconhecimento público;</li>
                    <li>· Maior flexibilidade frente às mudanças;</li>
                    <li>· Melhores condições de atingir e manter o desempenho desejado.</li>
                </ul>
            </p>
            <p>
                A melhor interpretação do desenho do MEG é o do conceito de aprendizado do ciclo
                do PDCL (Planejar, Fazer, Checar e Aprender).></p>
            <p>
                <b>PLANEJAR (P):</b></p>
            <p>
                A sobrevivência e o sucesso de uma empresa estão diretamente relacionados à sua
                capacidade de atender às necessidades e expectativas dos <b>CLIENTES</b> (pessoas
                que compram os produtos ou serviços da empresa), e à atuação de forma responsável
                junto à <b>SOCIEDADE</b> (região, o estado ou o país onde a empresa está localizada),
                e às comunidades ( pessoas e outras empresas vizinhas e que são afetadas pelas atividades
                da sua empresa) com as quais interage.</p>
            <p>
                De posse destas informações, a <b>LIDERANÇA</b> (proprietário ou os dirigentes da
                empresa) formula as <b>ESTRATÉGIAS</b> (ações ou os caminhos seguidos pela empresa
                para garantir o atendimento às necessidades de seus clientes, da sociedade e de
                seu proprietário) e estabelece os <b>PLANOS</b> de ação (ações necessárias para
                o cumprimento das estratégias, definindo os responsáveis, os prazos e a maneira
                correta de executar as ações), e as metas para conquistar os resultados desejados.
                Os planos e as metas são comunicados aos colaboradores e posteriormente acompanhados.</p>
            <p>
                Feito o planejamento, é necessário colocá-lo em prática!</p>
            <p>
                <b>FAZER (D):</b></p>
            <p>
                As <b>PESSOAS</b> (colaboradores que trabalham na empresa) devem estar capacitadas
                para as atribuições, e precisam atuar em um ambiente adequado para que os <b>PROCESSOS</b>
                (atividades que transformam os materiais e as matérias-primas adquiridas em produtos
                ou serviços que vão atender às necessidades e expectativas dos clientes e da sociedade)
                sejam executados conforme o planejado, considerando-se os custos, os prazos, os
                investimentos e os riscos previstos. É importante, ainda, aperfeiçoar o relacionamento
                com os fornecedores, uma vez que as necessidades dos clientes sejam entendidas por
                aqueles que fornecerão os insumos necessários para a execução dos processos.</p>
            <p>
                Na etapa do Fazer, os principais fatores no Modelo de Excelência da Gestão® são
                as <b>PESSOAS</b> e os <b>PROCESSOS</b> da empresa.</p>
            <p>
                Para que as coisas ocorram dentro do esperado é necessário o controle!</p>
            <p>
                <b>CONTROLAR (C):</b></p>
            <p>
                Na empresa, de acordo com o MEG, são realizados procedimentos para conferir e controlar
                o que está sendo colocado em prática. Para efetivar a etapa do Controle, são medidos
                os <b>RESULTADOS</b> (decorrentes dos processos e demais atividades realizadas na
                empresa) em relação à situação econômico-financeira, aos clientes e mercado, às
                pessoas, à sociedade, aos processos principais do negócio e processos de apoio,
                e aos fornecedores.</p>
            <p>
                Os efeitos gerados pela implementação das práticas de gestão podem ser comparados
                às metas estabelecidas para eventuais correções de rumo ou reforços das ações implementadas.</p>
            <p>
                Na etapa do Controlar, os principais fatores no Modelo de Excelência da Gestão®
                são os <b>RESULTADOS</b> da empresa.</p>
            <p>
                Com base nos resultados obtidos, é necessária uma reflexão para se identificar as
                melhorias ou o que pode ser melhorado!</p>
            <p>
                <b>APRENDER (L):</b></p>
            <p>
                Os resultados, na forma de <b>INFORMAÇÕES</b> ( dados gerados na execução dos processos
                e demais atividades realizadas na empresa) e de <b>CONHECIMENTO</b> (o saber já
                internalizado na empresa sobre como realizar os produtos e serviços que esta entrega
                para os seus clientes), são analisados para se aprender com os acertos e erros cometidos,
                de modo que se possa iniciar novamente o planejamento e recomeçar novamente o ciclo,
                considerando-se o aprendizado obtido. O aprendizado completa o ciclo PDCL de uma
                empresa.</p>
            <p>
                Essas ações representam a inteligência da empresa, viabilizando a análise do desempenho
                e a execução das ações necessárias.</p>
            <p>
                Por tudo o que foi aqui colocado, verifica-se que ao utilizar o Modelo de Excelência
                da Gestão da FNQ, uma organização pode modelar seu sistema de gestão, realizar autoavaliações,
                e identificar onde melhorar o desempenho de seu negócio.</p>
            <p>
                COMENTÁRIOS GERADOS PELO SISTEMA A PARTIR DAS RESPOSTAS APRESENTADAS SOBRE A GESTÃO DA EMPRESA</p>
            <p>
                Ao preencher o Questionário de Autoavaliação você respondeu 31 questões, com 4 opções de resposta cada (a, b, c, ou d), dos critérios de 1 a 7. As perguntas e resultados solicitados, da questão 32, que formam o oitavo critério, estavam ao final do questionário e, dependendo da sua resposta, foi necessário apresentar o dos últimos anos. Neste relatório você visualizará os oito critérios, pois os resultados estão apresentados separadamente das questões.</p>
        </div>
        <div>
            <p class="style13Title" align="center">
                <b>GRÁFICO RADAR</b></p>
            <p>
                O gráfico abaixo apresenta a distribuição das pontuações por Critério.</p>
            <div align="center" id="GraficoRadar">
                <table width="500" cellspacing="1" cellpadding="1">
                    <tr id="coluna1Fase4" runat="server">
                        <td align="center" bgcolor="#8B8989" colspan="2" style="font-size: 12px; color: white">
                            Autoavaliação da Gestão - Comparativo
                        </td>
                    </tr>
                    <tr>
                        <td align="center" bgcolor="#8B8989" style="font-size: 12px; color: white; font-weight:bold;">
                            Autoavaliação Inicial
                        </td>
                        <td align="center" bgcolor="#8B8989" style="font-size: 12px; color: white" id="coluna2Fase4" runat="server" visible="false">
                            Autoavaliação Final
                        </td>
                    </tr>
                    <tr>
                        <td align="center" bgcolor="#f0f0f0">
                            <asp:Image ID="imgGraficoRadarInicial" runat="server" />
                        </td>
                        <td align="center" bgcolor="#f0f0f0" id="coluna3Fase4" runat="server" visible="false">
                            <asp:Image ID="imgGraficoRadarFinal" runat="server" />
                        </td>
                    </tr>
                </table>
                <table width="600" cellspacing="1" cellpadding="1" class="tdAzulEscuro">
                    <tr>
                        <td colspan="4">
                            <asp:GridView ID="grdDesempenhoEmpresaGestao" runat="server" AllowPaging="True" AllowSorting="True"
                                Width="100%" AutoGenerateColumns="False" ShowFooter="true">
                                <RowStyle BackColor="#dddddd" ForeColor="#333333" HorizontalAlign="Center" Font-Size="11px" />
                                <SelectedRowStyle BackColor="#FFCC66" ForeColor="Navy" />
                                <HeaderStyle BackColor="#004a91" ForeColor="White" HorizontalAlign="Center" Font-Size="11px" />
                                <FooterStyle BackColor="#004a91" ForeColor="White" HorizontalAlign="Center" Font-Size="11px" />
                                <AlternatingRowStyle BackColor="White" />
                                <EmptyDataTemplate>
                                    Não existem dados*
                                </EmptyDataTemplate>
                                <RowStyle HorizontalAlign="Center" />
                                <Columns>
                                    <asp:TemplateField HeaderText="Critério">
                                        <ItemTemplate>
                                            <%# DataBinder.Eval(Container.DataItem, "Criterio.QuestionarioGestaoPorExtenso")%>
                                        </ItemTemplate>
                                        <HeaderStyle Width="200px" />
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotal" runat="server" ForeColor="White" Font-Bold="true" Text="Total"></asp:Label></FooterTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Pontuação Máxima">
                                        <ItemTemplate>
                                            <%# DataBinder.Eval(Container.DataItem, "Criterio.QuestionarioGestaoPontuacaoMaxima")%>
                                        </ItemTemplate>
                                        <HeaderStyle Width="130px" />
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalPontuacaoMaxima" runat="server" ForeColor="White" Font-Bold="true"
                                                Text="100,00%"></asp:Label></FooterTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Pontuação Autoavaliação Inicial">
                                        <ItemTemplate>
                                            <%# Vinit.SG.Common.DoubleUtils.ToString(Vinit.SG.Common.ObjectUtils.ToDouble(DataBinder.Eval(Container.DataItem, "Ponto"))) + "%"%>
                                        </ItemTemplate>
                                        <HeaderStyle Width="130px" />
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalPontuacaoObtida" ForeColor="White" Font-Bold="true" runat="server"></asp:Label></FooterTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Pontuação Autoavaliação Final" Visible="false">
                                        <ItemTemplate>
                                            <%# Vinit.SG.Common.DoubleUtils.ToString(Vinit.SG.Common.ObjectUtils.ToDouble(DataBinder.Eval(Container.DataItem, "Ponto"))) + "%"%>
                                        </ItemTemplate>
                                        <HeaderStyle Width="130px" />
                                        <FooterTemplate>
                                            <asp:Label ForeColor="White" Font-Bold="true" ID="lblTotalPontuacaoClassificadaAnterior"
                                                runat="server" Text="43,09%"></asp:Label></FooterTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </td>
                    </tr>
                </table>
            </div>
            <div align="center">
                <asp:Panel ID="pnlGestaoCriterio" runat="server">
                </asp:Panel>
            </div>
            <div id="txtRadar" runat="server">
                <p>
                    <b>Interpretação Padrão do Gráfico Radar</b></p>
                <p>
                    Quando a empresa apresentar seus resultados para os critérios 1, 2, 3, 4 e 5, abaixo do intervalo 40–60, é importante rever como estão sendo planejadas suas práticas. Resultados obtidos no intervalo 40-60 demonstram que a empresa vem planejando suas práticas, porém faz-se necessário um maior controle e comunicação desse planejamento. O intervalo 60-100 sugere que a empresa está no caminho certo no que se refere ao "P" do PDCL, devendo ficar atenta apenas para não descontinuar o que já vem fazendo.</p>
                <p>
                    Quando a empresa apresentar seus resultados para os critérios 5, 6 e 7, abaixo do intervalo 40–60, é importante rever como estão sendo desenvolvidas suas práticas. Resultados obtidos no intervalo 40-60 demonstram que a empresa vem desenvolvendo suas práticas, porém faz-se necessário um maior controle e comunicação do que vem sendo desenvolvido. O intervalo 60-100 sugere que a empresa está no caminho certo no que se refere ao "D" do PDCL, devendo ficar atenta apenas para não descontinuar o que já vem fazendo.</p>
                <p>
                    Quando a empresa apresentar seus resultados para o critério 8, abaixo do intervalo 40–60, é importante rever como estão sendo controladas suas práticas. Resultados obtidos no intervalo 40-60 demonstram que a empresa vem controlando suas práticas, porém faz-se necessário uma maior abrangência desse controle. O intervalo 60-100 sugere que a empresa está no caminho certo no que se refere ao "C" do PDCL, devendo ficar atenta apenas para não descontinuar o que já vem fazendo.</p>
                <p>
                    Resultados acima do marco 80 apontam que a empresa já está preparada para um novo patamar, devendo rodar seu ciclo PDCL por meio da revisão e melhoria dos padrões de trabalho (como fazem) de suas práticas de gestão (o que fazem).</p>
                <p>
                    A seguir está apresentada a Parte I do questionário respondido por sua empresa, incluindo comentários automáticos gerados pelo sistema de avaliação, correspondentes às respostas dadas.</p>
                <p>
                    Sempre que assinaladas como respostas as letras a, b ou c é recomendada uma oportunidade de melhoria, diretamente relacionada à necessidade do atendimento ao próximo marcador/letra. Exemplo: quando assinalado o marcador "a)" a Oportunidade de Melhoria mais imediata para a empresa está associada diretamente à implantação de ações que levarão ao atendimento do marcador "b" e assim sucessivamente.</p>
                <p>
                    Para a orientação de como implementar ações/práticas de gestão que atendam aos marcadores/letras
                    das questões desta ferramenta de avaliação, sugerimos a leitura dos Cadernos "Compromisso
                    com a Excelência", publicados pela FNQ e disponibilizados em <b>www.fnq.org.br</b>
                    para consulta gratuita.</p>
                <p>
                    No início do critério, será indicado por meio de "gráficos" como que o resultado dessa avaliação sugere o nível de maturidade da empresa, especificamente no critério em questão, no modelo do PDCL e conseqüentemente na implantação do MEG®, no nível proposto pela FNQ para as micro e pequenas empresas.</p>
                <p>
                    Para cada questão respondida você receberá comentários com Pontos Fortes e/ou Oportunidades para Melhoria para sua empresa. Os Pontos Fortes devem ser fortalecidos para a melhoria contínua do negócio. Para as Oportunidades de Melhoria devem ser tomadas ações corretivas e preventivas para a melhoria da gestão do negócio.</p>
            </div>
        </div>
        <div style="page-break-before: always">
        </div>
        <div>
            <div class="tdAzulEscuro" align="center">
                CRITÉRIO 1 - LIDERANÇA</div>
            <div align="left">
                <uc3:UCRelatorioPerguntaLideranca ID="UCRelatorioPerguntaLideranca1" runat="server" />
            </div>
            <div class="tdAzulEscuro" align="center">
                CRITÉRIO 2 - ESTRATÉGIAS E PLANOS</div>
            <div align="left">
                <uc4:UCRelatorioPerguntaEstrategia ID="UCRelatorioPerguntaEstrategia1" runat="server" />
            </div>
            <div class="tdAzulEscuro" align="center">
                CRITÉRIO 3 - CLIENTES</div>
            <div align="left">
                <uc1:UCRelatorioPerguntaCliente ID="UCRelatorioPerguntaCliente1" runat="server" />
            </div>
            <div class="tdAzulEscuro" align="center">
                CRITÉRIO 4 - SOCIEDADE</div>
            <div align="left">
                <uc2:UCRelatorioPerguntaSociedade ID="UCRelatorioPerguntaSociedade1" runat="server" />
            </div>
            <div class="tdAzulEscuro" align="center">
                CRITÉRIO 5 - INFORMAÇÕES E CONHECIMENTOS</div>
            <div align="left">
                <uc7:UCRelatorioPerguntaInformacaoConhecimento ID="UCRelatorioPerguntaInformacaoConhecimento1"
                    runat="server" />
            </div>
            <div class="tdAzulEscuro" align="center">
                CRITÉRIO 6 - PESSOAS</div>
            <div align="left">
                <uc5:UCRelatorioPerguntaPessoas ID="UCRelatorioPerguntaPessoas1" runat="server" />
            </div>
            <div class="tdAzulEscuro" align="center">
                CRITÉRIO 7 - PROCESSOS</div>
            <div align="left">
                <uc6:UCRelatorioPerguntaProcessos ID="UCRelatorioPerguntaProcessos1" runat="server" />
            </div>
            <div class="tdAzulEscuro" align="center">
                CRITÉRIO 8 - RESULTADOS</div>
            <div align="left">
                <uc8:UCRelatorioPerguntaResultado ID="UCRelatorioPerguntaResultado1" runat="server" />
                <br />
            </div>
            <br />
            <div align="center" class="style11" id="comentariosAvaliador" runat="server">
                <p align="center">
                    <span>COMENTÁRIOS DO AVALIADOR</span>
                </p>
                <table cellspacing="1" cellpadding="3" border="1" bgcolor="#000000" width="100%">
                    <tr bgcolor="#FFFFFF">
                        <asp:Label ID="comentarioAvaliador" runat="server"></asp:Label>
                    </tr>
                </table>
            </div>
    </div>
    </form>
</body>
</html>
