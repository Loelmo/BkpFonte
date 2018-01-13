<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PaginaRelatorio.aspx.cs"
    Inherits="Sistema_de_Gestao.MPE.Paginas.PaginaRelatorio" %>

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
        <div class="style2" id="introTxt" runat="server" align="left" visible="false">
            <p>
                Prezado(a) Empresário(a)
            </p>
            <p>
                Este relatório apresenta os pontos fortes e as oportunidades para melhoria de sua
                empresa. Ele foi elaborado com base na autoavaliação por vocês enviada para participação
                no <b>Prêmio MPE Brasil 2010</b>. Nossa expectativa é que os comentários nele apresentados
                tornem seu negócio cada vez mais bem sucedido com resultados ainda mais satisfatórios.</p>
            <p>
                Quando falamos em resultados, nos referimos tanto aos financeiros, como lucratividade
                e rentabilidade, quanto a ter clientes mais satisfeitos, menos re-trabalho, não
                ocorrência de desperdícios e acidentes de trabalho, além de se ter um ambiente mais
                favorável à criatividade e à inovação dos produtos, serviços, processos e gestão
                da empresa. Todos esses são aspectos dinâmicos que levam ao sucesso do negócio.</p>
            <p>
                O objetivo deste relatório é registrar o grau de maturidade da gestão de sua empresa
                em relação aos Conceitos e Fundamentos de Excelência da Gestão, mostrando quais
                características estão mais fortalecidas e quais precisam de maior desenvolvimento.
            </p>
            <p>
                Ele é resultado do processo de avaliação do <b>Prêmio MPE Brasil</b>, que foi criado
                com o propósito de promover o aumento da competitividade das micro e pequenas empresas
                brasileiras. O processo do prêmio é formado pelas seguintes etapas:</p>
            <ol type="1" start="1">
                <li>Inscrição;</li>
                <li>Autoavaliação (preenchimento do questionário pelas candidatas com base no Modelo
                    de Excelência da Gestão® (MEG®) da Fundação Nacional da Qualidade (FNQ));</li>
                <li>Seleção das empresas para visita. pela Banca de Avaliadores do Prêmio;</li>
                <li>Visitas técnicas para validação das informações apresentadas no questionário;</li>
                <li>Avaliação da Banca de Juízes para a definição das empresas finalistas e vencedoras
                    do ciclo;</li>
                <li>Entrega dos relatórios para as empresas visitadas.</li>
            </ol>
            <p>
                Lembramos que como sua empresa não foi visitada, este relatório cantém apenas comentários-padrão
                com base nas respostas de sua própria autoavaliação.</p>
            <p>
                O conteúdo do relatório está estruturado da seguinte forma:</p>
            <p>
                <span><span><b>Parte I</b></span></span></p>
            <ul>
                <li>Informações sobre os Fundamentos de Excelência e Modelo de Excelência da Gestão®
                    da Fundação Nacional da Qualidade;</li>
                <li>Recomendações para sua empresa a partir do ciclo PDCL (Planejar, Fazer, Executar,
                    Controlar e Aprender);</li>
                <li>Pontuação obtida com base no questionário respondido sobre a gestão da empresa,
                    apresentada no gráfico Radar e em uma tabela por Critério de Excelência;</li>
                <li>Comentários com Pontos Fortes ou Oportunidades para Melhoria para cada questão respondida.</li>
            </ul>
            <p>
                <span><span><b>Parte II - Opcional -</b> Apenas para as empresas que responderam a parte
                    do questionário relacionada às Características do Comportamento Empreendedor.</span></span></p>
            <ul>
                <li>Tabela com pontuação e respectivo gráfico com base nas 30 respostas para a parte
                    II, tratando as Características do Comportamento Empreendedor;</li>
                <li>Quadro com a interpretação das respostas e comentários para reflexão pelo empresário
                    responsável pela condução do negócio;</li>
                <li>Descrição das Características do Comportamento Empreendedor;</li>
                <li>Recomendações Gerais.</li>
            </ul>
            <p>
                <span><span><b>Parte III - Opcional -</b> Apenas para as empresas que responderam a
                    parte do questionário relacionada à Responsabilidade Social.</span></span></p>
            <p>
                Desejamos que este relatório seja útil na promoção de reflexões e melhorias para
                sua empresa!
            </p>
            <br />
            <p>
                A partir deste ano você poderá acompanhar, através do Portal do Prêmio, a evolução
                do desempenho da sua empresa, em cada ciclo do Prêmio. Isso oportunizará que cada
                vez mais você na trabalhe nas Oportunidades de Melhorias identificadas ao longo
                dos anos.
            </p>
            <br />
            <p>
                Gostaríamos de agradecer sua inscrição no Prêmio, ciclo 2010, e de nos colocarmos
                à disposição para qualquer esclarecimento, através do Portal do Prêmio <b>www.premiompe.sebrae.com.br</b>.</span></p>
            <p>
                Atenciosamente</p>
            <p>
                Coordenação do Prêmio MPE Brasil</p>
        </div>
        <div class="style2" id="introTxtAvaliacao" runat="server" align="left">
            <p>
                Prezado(a) Empresário(a)</p>
            <p>
                Este relatório apresenta os pontos fortes e as oportunidades para melhoria de sua
                empresa. Ele foi elaborado com base na autoavaliação por vocês enviada para participação
                no
                <br>
                Prêmio MPE Brasil 2010</b>, e na visita realizada pelos avaliadores à sua empresa.
                Nossa expectativa é que os comentários nele apresentados tornem seu negócio cada
                vez mais bem sucedido com resultados ainda mais satisfatórios.</p>
            <p>
                Quando falamos em resultados, nos referimos tanto aos financeiros, como lucratividade
                e rentabilidade, quanto a ter clientes mais satisfeitos, menos re-trabalho, não
                ocorrência de desperdícios e acidentes de trabalho, além de se ter um ambiente mais
                favorável à criatividade e à inovação dos produtos, serviços, processos e gestão
                da empresa. Todos esses são aspectos dinâmicos que levam ao sucesso do negócio.</p>
            <p>
                O objetivo deste relatório é registrar o grau de maturidade da gestão de sua empresa
                em relação aos Conceitos e Fundamentos de Excelência da Gestão, mostrando quais
                características estão mais fortalecidas e quais precisam de maior desenvolvimento.
            </p>
            <p>
                Ele é resultado do processo de avaliação do <b>Prêmio MPE Brasil</b>, que foi criado
                com o propósito de promover o aumento da competitividade das micro e pequenas empresas
                brasileiras. O processo do prêmio é formado pelas seguintes etapas:</p>
            <ul>
                <li>Inscrição;</li>
                <li>Autoavaliação (preenchimento do questionário pelas candidatas com base no Modelo
                    de Excelência da Gestão® (MEG®) da Fundação Nacional da Qualidade (FNQ));</li>
                <li>Seleção das empresas para visita. pela Banca de Avaliadores do Prêmio;</li>
                <li>Visitas técnicas para validação das informações apresentadas no questionário;</li>
                <li>Avaliação da Banca de Juízes para a definição das empresas finalistas e vencedoras
                    do ciclo;</li>
                <li>Entrega dos relatórios para as empresas visitadas.</li>
            </ul>
            <p>
                O conteúdo do relatório está estruturado da seguinte forma:</p>
            <p>
                <span><b>Parte I</b></span></p>
            <ul type="disc">
                <li>Informações sobre os Fundamentos de Excelência e Modelo de Excelência da Gestão®
                    da Fundação Nacional da Qualidade;</li>
                <li>Recomendações para sua empresa a partir do ciclo PDCL (Planejar, Fazer, Executar,
                    Controlar e Aprender);</li>
                <li>Pontuação obtida com base no questionário respondido sobre a gestão da empresa,
                    apresentada no gráfico Radar e em uma tabela por Critério de Excelência;</li>
                <li>Comentários com Pontos Fortes ou Oportunidades para Melhoria para cada questão respondida:
                    comentário-padrão e do avaliador, para cada resposta.</li>
            </ul>
            <p>
                <span><b>Parte II -</b> Diagnóstico com base nas respostas da parte II do questionário
                    relacionada às Características do Comportamento Empreendedor.</span></p>
            <ul type="disc">
                <li>Tabela com pontuação e respectivo gráfico com base nas 30 respostas para a parte
                    II, tratando as Características do Comportamento Empreendedor;</li>
                <li>Quadro com a interpretação das respostas e comentários para reflexão pelo empresário
                    responsável pela condução do negócio;</li>
                <li>Descrição das Características do Comportamento Empreendedor;</li>
                <li>Recomendações Gerais.</li>
            </ul>
            <p>
                <span><b>Parte III - Opcional -</b> Apenas para as empresas que responderam a parte
                    do questionário relacionada à Responsabilidade Social.</span></p>
            <p>
                Desejamos que este relatório seja útil na promoção de reflexões e melhorias para
                sua empresa!
            </p>
            <p>
                A partir deste ano você poderá acompanhar, através do Portal do Prêmio, a evolução
                do desempenho da sua empresa, em cada ciclo do Prêmio. Isso oportunizará que cada
                vez mais você na trabalhe nas Oportunidades de Melhorias identificadas ao longo
                dos anos.
            </p>
            <p>
                Gostaríamos de agradecer sua inscrição no Prêmio, ciclo 2010, e de nos colocarmos
                à disposição para qualquer esclarecimento, através do Portal do Prêmio <b>www.premiompe.sebrae.com.br</b>.</span></p>
            <p>
                Atenciosamente</p>
            <p>
                Coordenação do Prêmio MPE Brasil</p>
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
                        <span>Categoria:</span>
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
                        <span>CPF/CNPJ:</span>
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
            <table cellspacing="2" cellpadding="1" width="100%" border="0" class="style11">
                <tr>
                    <td class="tdAzulEscuro" colspan="2">
                        <span>Respostas da empresa</span>
                    </td>
                </tr>
                <tr class="tdAzulMedio">
                    <td>
                        <span>1. Os dirigentes têm clareza do que a empresa deverá ser no futuro?</span>
                    </td>
                    <td>
                        <asp:Label ID="lblResposta1" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr class="tdAzulClaro">
                    <td>
                        <span>2. Existem ações definidas para alcançar o que a empresa quer ser no futuro?</span>
                    </td>
                    <td>
                        <asp:Label ID="lblResposta2" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr class="tdAzulMedio">
                    <td>
                        <span>3. As necessidades dos clientes são conhecidas e atendidas?</span>
                    </td>
                    <td>
                        <asp:Label ID="lblResposta3" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr class="tdAzulClaro">
                    <td>
                        <span>4. As receitas e despesas são controladas para garantir a permanência da empresa
                            no mercado?</span>
                    </td>
                    <td>
                        <asp:Label ID="lblResposta4" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
        </div>
        <div style="page-break-before: always">
        <div id="introTxt2" runat="server">
            <p style="font-weight: bold; text-align: center;">
                RELATÓRIO DE AUTOAVALIAÇÃO
                <br />
                MPE BRASIL
                <br />
                PRÊMIO DE COMPETITIVIDADE PARA MICRO E PEQUENAS EMPRESAS
                <br />
                ANO 2010
            </p>
            <p align="center" class="style13Title">
                <b>PARTE I: GESTÃO DA EMPRESA</b>
            </p>
            <p>
                Esta parte do Relatório de Autoavaliação apresenta o desempenho de sua empresa a
                partir do preenchimento do Questionário do MPE Brasil que avalia a Gestão da Empresa.
            </p>
            <p>
                A partir dos comentários apresentados você terá a oportunidade de avaliar seus resultados
                e tomar ações para melhoria, buscando aumentar a competitividade de sua empresa.
            </p>
            <p>
                <b>INTRODUÇÃO</b>
            </p>
            <p>
                O questionário de Autoavaliação do Prêmio MPE Brasil é baseado no Modelo de Excelência
                da Gestão® - MEG da Fundação Nacional da Qualidade (FNQ) adotado por inúmeras empresas.
                O MEG tem como base os 11 Fundamentos de Excelência da Gestão, que são conceitos
                reconhecidos mundialmente encontrados em empresas que já atingiram patamares de
                Excelência, ou que estão caminhando nessa direção. Cabe destacar que esses Fundamentos
                são aplicáveis a qualquer empresa, uma vez que tratam, de forma genérica, dos mais
                modernos conceitos de gestão. São eles:</p>
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
                Buscando o aumento da competitividade das organizações e do Brasil, a FNQ vem disseminando
                os Fundamentos da Excelência por meio do Modelo de Excelência da Gestão® (MEG),
                apresentado em 4 versões de avaliação das empresas:</p>
            <p>
                <b>· MPE Brasil – questionário que apresenta o Modelo de Excelência da Gestão® simplificado
                    e adaptado para a realidade das micro e pequenas empresas que estão iniciando a
                    caminhada rumo à excelência da gestão;</b></p>
            <p>
                · Compromisso com a Excelência – para empresas em fase inicial de adoção do Modelo
                de Excelência da Gestão® (adotado pela Rede de Prêmios da FNQ)</p>
            <p>
                · Rumo à Excelência – para empresas em fase intermediária de adoção do Modelo de
                Excelência da Gestão® (adotado pela Rede de Prêmios da FNQ)</p>
            <p>
                · Critérios de Excelência – para empresas que já estão maduras para buscarem o reconhecimento
                de Classe Mundial (adotado pelas empresas participantes dos ciclos de avaliação
                do PNQ).</p>
            <p>
                O Modelo de Excelência da Gestão® (MEG) consiste da aplicação dos Fundamentos de
                Excelência às práticas de gestão de uma empresa. Em função de sua flexibilidade
                e simplicidade de linguagem, é útil para avaliação, o diagnóstico e como orientação
                para qualquer tipo de empresa, no setor público e privado, com ou sem finalidade
                de lucro, e de porte pequeno, médio ou grande.
            </p>
            <p>
                O MEG é constituído por 8 Critérios:
                <br />
                <ul>
                    <li>1. Liderança: critério que trata da forma como o empresário conduz o seu negócio,
                        define rumos, analisa o desempenho da sua empresa e aprimora o conhecimento dos
                        seus líderes.</li>
                    <li>2. Estratégias e Planos: critério que trata da definição das estratégias da empresa
                        (caminhos ou rumos escolhidos para se alcançar a sua visão de futuro), do desdobramento
                        destas em metas e planos de ação, incluindo a definição de indicadores de desempenho.</li>
                    <li>3. Clientes: este critério trata do conhecimento que a empresa tem dos seus clientes
                        e mercados, da identificação de suas necessidades e do seu grau de satisfação, e
                        de como suas reclamações são tratadas.</li>
                    <li>4. Sociedade: este critério trata da identificação dos impactos ambientais decorrentes
                        dos produtos, processos e instalações da empresa e ainda da sua prática de ações
                        relativas à responsabilidade social.</li>
                    <li>5. Informações e Conhecimento: critério que trata da identificação e uso de informações
                        necessárias para a execução das atividades da empresa, bem como de informações comparativas
                        para auxiliar na análise e melhoria do seu desempenho.</li>
                    <li>6. Pessoas: critério que trata da estrutura organizacional, do reconhecimento, capacitação
                        e desenvolvimento dos colaboradores e das ações voltadas para a qualidade de vida
                        no trabalho, a fim de melhorar o desempenho das pessoas e da empresa.</li>
                    <li>7. Processos: critério que trata da definição e gerenciamento dos processos principais
                        do negócio da empresa (produção, prestação de serviço, manufatura, comercialização)
                        e daqueles necessários para que a sua execução ocorra sem problemas (processos de
                        apoio); bem como do gerenciamento dos seus principais fornecedores e dos recursos
                        financeiros da empresa.</li>
                    <li>8. Resultados: este critério solicita os resultados de indicadores de desempenho
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
                COMENTÁRIOS GERADOS PELO SISTEMA A PARTIR DAS RESPOSTAS APRESENTADAS NA PARTE I
                – GESTÃO DA EMPRESA</p>
            <p>
                Ao preencher a Parte I do Questionário de Autoavaliação – Gestão da Empresa, você
                respondeu 30 questões de alternativas (a, b, c, ou d) dos critérios de 1 a 7 e apresentou
                justificativas de acordo com a alternativa selecionada, quando solicitado. Os 8
                resultados solicitados, que formam o oitavo critério, estavam ao final do questionário
                na forma da tabela para preenchimento de controle ou não, e em caso de resposta
                afirmativa, foram ainda solicitados os dados para os três últimos anos, ou no mínimo
                um deles. Neste relatório você visualizará os oito critérios, pois os resultados
                estão apresentados separadamente das questões.</p>
        </div>
        <div>
            <p>
                <b>GRÁFICO RADAR</b></p>
            <p>
                O gráfico abaixo apresenta a distribuição das pontuações por Critério.</p>
            <div align="center" id="GraficoRadar">
                <table width="500" cellspacing="1" cellpadding="1">
                    <tr>
                        <td align="center" bgcolor="#8B8989" colspan="2" style="font-size: 12px; color: white">
                            Autoavaliação da Gestão - Desempenho Global das Empresas
                        </td>
                    </tr>
                    <tr>
                        <td align="center" bgcolor="#8B8989" style="font-size: 12px; color: white; font-style: bold">
                            Desempenho da Empresa
                        </td>
                        <td align="center" bgcolor="#8B8989" style="font-size: 12px; color: white">
                            Comparativo Geral 2010
                        </td>
                    </tr>
                    <tr>
                        <td align="center" bgcolor="#f0f0f0">
                            <asp:Image ID="imgGraficoRadarCorrente" runat="server" />
                        </td>
                        <td align="center" bgcolor="#f0f0f0">
                            <asp:Image ID="imgGraficoRadarAnterior" runat="server" />
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
                                    <asp:TemplateField HeaderText="Pontuação Obtida">
                                        <ItemTemplate>
                                            <%# Vinit.SG.Common.DoubleUtils.ToString(Vinit.SG.Common.ObjectUtils.ToDouble(DataBinder.Eval(Container.DataItem, "Ponto"))) + "%"%>
                                        </ItemTemplate>
                                        <HeaderStyle Width="130px" />
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalPontuacaoObtida" ForeColor="White" Font-Bold="true" runat="server"></asp:Label></FooterTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Pontuação Classificadas 2010">
                                        <ItemTemplate>
                                            <%# Vinit.SG.Common.DoubleUtils.ToString(Vinit.SG.Common.ObjectUtils.ToDouble(DataBinder.Eval(Container.DataItem, "Criterio.QuestionarioGestaoPontuacaoAnterior"))) + "%"%>
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
                    Quando a empresa apresentar pontuação para os critérios 1, 2, 3, 4 e 5, abaixo do
                    intervalo 40-60, é importante rever como estão sendo planejadas suas práticas. Pontuações
                    obtidas no intervalo 40-60 demonstram que a empresa vem planejando suas práticas,
                    porém faz-se necessário um maior controle e comunicação desse planejamento. O intervalo
                    60-100 sugere que a empresa está no caminho certo no que se refere ao "P" do PDCL,
                    devendo ficar atenta apenas para não descontinuar o que já vem fazendo.</p>
                <p>
                    Quando a empresa apresentar pontuação para os critérios 5, 6 e 7, abaixo do intervalo
                    40-60, é importante rever como estão sendo desenvolvidas suas práticas. Pontuações
                    obtidas no intervalo 40-60 demonstram que a empresa vem desenvolvendo suas práticas,
                    porém faz-se necessário um maior controle e comunicação do que vem sendo desenvolvido.
                    O intervalo 60-100 sugere que a empresa está no caminho certo no que se refere ao
                    "D" do PDCL, devendo ficar atenta apenas para não descontinuar o que já vem fazendo.</p>
                <p>
                    Quando a empresa apresentar a pontuação para o critério 8, abaixo do intervalo 40-60,
                    é importante rever como estão sendo controladas suas práticas. Pontuações obtidas
                    no intervalo 40-60 demonstram que a empresa vem controlando suas práticas, porém
                    faz-se necessário uma maior abrangência desse controle. O intervalo 60-100 sugere
                    que a empresa está no caminho certo no que se refere ao "C" do PDCL, devendo ficar
                    atenta apenas para não descontinuar o que já vem fazendo.</p>
                <p>
                    Pontuações acima do marco 80 apontam que a empresa já está preparada para um novo
                    patamar, devendo rodar seu ciclo PDCL por meio da revisão e melhoria dos padrões
                    de trabalho (como fazem) de suas práticas de gestão (o que fazem).</p>
                <p>
                    A seguir, são apresentados os comentários automáticos gerados pelo sistema de avaliação,
                    correspondentes às respostas dadas na Parte I do questionário respondido por sua
                    empresa.</p>
                <p>
                    Sempre que assinaladas como respostas as letras a, b ou c é recomendada uma oportunidade
                    de melhoria, diretamente relacionada à necessidade do atendimento ao próximo marcador/letra.
                    Exemplo: quando assinalado o marcador "a)" a Oportunidade de Melhoria mais imediata
                    para a empresa está associada diretamente à implantação de ações que levarão ao
                    atendimento do marcador "b" e assim sucessivamente. E quando for assinalada a letra
                    d, é apresentado como ponto forte na gestão da empresa.</p>
                <p>
                    Para a orientação de como implementar ações/práticas de gestão que atendam aos marcadores/letras
                    das questões desta ferramenta de avaliação, sugerimos a leitura dos Cadernos "Compromisso
                    com a Excelência", publicados pela FNQ e disponibilizados em <b>www.fnq.org.br</b>
                    para consulta gratuita.</p>
                <p>
                    No início do critério, será indicado por meio de "gráficos" como que o resultado
                    dessa avaliação sugere o nível de maturidade da empresa, especificamente no critério
                    em questão, no modelo do PDCL e conseqüentemente na implantação do MEG®, no nível
                    proposto pela FNQ às micro e pequenas empresas.</p>
                <p>
                    Para cada questão respondida você encontrará comentários com Pontos Fortes ou Oportunidades
                    para Melhoria para sua empresa. Os Pontos Fortes devem ser fortalecidos para a melhoria
                    contínua do negócio. Para as Oportunidades de Melhoria devem ser tomadas ações corretivas
                    e preventivas para a melhoria da gestão do negócio.</p>
            </div>
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
                <table border="0" cellspacing="1" cellpadding="1" width="800">
                    <tr>
                        <td>
                            O critério impacta diretamente no "C" do PDCL
                        </td>
                    </tr>
                </table>
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
            <div align="center">
                <p align="center">
                    <span>ANÁLISE DOS RESULTADOS</span>
                </p>
                <p>
                    Os resultados são avaliados quanto à sua evolução, ou seja, seu comportamento ao
                    longo do tempo. Para um dado indicador, por exemplo, quando o resultado de 2008
                    é melhor que o de 2007, e o de 2009 é melhor que o de 2008, a evolução é favorável,
                    demonstrando que a empresa vem conseguindo obter bons resultados como decorrência
                    da utilização de práticas adequadas em sua gestão.
                </p>
                <p>
                    Além da avaliação da evolução do desempenho individual da sua empresa, é importante
                    comparar estes resultados com outras empresas do seu setor, ou de setores similares,
                    para que avalie o seu desempenho no mercado onde atua e possa manter a sua empresa
                    competitiva em relação às concorrentes.
                </p>
                <p>
                    Essas informações podem ser encontradas, na maioria das vezes, nas entidades que
                    representam o seu setor, ou até mesmo com o Sebrae, caso possua um projeto setorial
                    estruturado, no seu estado.
                </p>
            </div>
            <div runat="server" id="parte2" visible="true">
                <p align="center">
                    <span style="mso-bidi-font-weight: normal"><span>PARTE II: AUTOAVALIAÇÃO DAS CARACTERÍSTICAS
                        DE COMPORTAMENTO EMPREENDEDOR</span>
                </p>
                <p>
                    A segunda parte do questionário avalia o desempenho do empreendedor nas dez Características
                    de Comportamento Empreendedor. Quanto maior for a pontuação em cada uma das dez
                    características, maior tende a ser o desempenho do empreendedor, pois representa
                    a sua forma de agir segundo a sua própria percepção. Lembre-se que o instrumento
                    preenchido trata-se de uma auto-avaliação.<o:p></o:p></p>
                <ul>
                    <li>1. Busca de oportunidades e iniciativa</li>
                    <li>2. Persistência</li>
                    <li>3. Comprometimento</li>
                    <li>4. Exigência de qualidade e eficiência</li>
                    <li>5. Correr riscos calculados</li>
                    <li>6. Estabelecimento de metas</li>
                    <li>7. Busca de informações</li>
                    <li>8. Planejamento e monitoramento sistemáticos</li>
                    <li>9. Persuasão e rede de contatos</li>
                    <li>10. Independência e autoconfiança</li>
                </ul>
                <p>
                    Você deve considerar que não existe um perfil ideal. Portando, esta é uma referência
                    que você poderá utilizar para buscar melhorias contínuas no seu ambiente de negócio.
                </p>
                <p>
                    Um fato relevante que você deve considerar é a combinação das dez características,
                    com isto, você poderá ter uma visão mais realista em relação ao seu resultado. A
                    análise da combinação torna-se fundamental devido ao fato que o desalinhamento de
                    algumas características pode afetar de forma adversa o desempenho de um empreendedor,
                    portando, antes de se preocupar com a intensidade do seu perfil, procure analisar
                    a combinação das características.
                </p>
                <div align="left" id="QuestionarioEmpreendedorismo">
                    <p>
                        <b>RESPOSTAS DADAS PELA EMPRESA</b>
                    </p>
                    <asp:Literal ID="ltrEmpreendedorResposta" runat="server"></asp:Literal>
                    Legenda:<br />
                    1 - Nunca<br />
                    2 - Às Vezes<br />
                    3 - Sempre
                </div>
                <div align="center" id="GraficoLinha">
                    <table width="600" cellspacing="1" cellpadding="1" class="tdAzulEscuro">
                        <tr>
                            <td colspan="4">
                                <asp:GridView ID="grdDesempenhoEmpresaEmpreendedorismo" runat="server" AllowPaging="True"
                                    AllowSorting="True" Width="100%" AutoGenerateColumns="False" ShowFooter="true">
                                    <RowStyle BackColor="#FFFBD6" ForeColor="#333333" HorizontalAlign="Center" Font-Size="Small" />
                                    <SelectedRowStyle BackColor="#FFCC66" ForeColor="Navy" />
                                    <HeaderStyle BackColor="#8B8989" ForeColor="White" HorizontalAlign="Center" Font-Size="Smaller" />
                                    <FooterStyle BackColor="#8B8989" ForeColor="White" HorizontalAlign="Center" Font-Size="Smaller" />
                                    <AlternatingRowStyle BackColor="White" />
                                    <EmptyDataTemplate>
                                        Não existem dados*
                                    </EmptyDataTemplate>
                                    <RowStyle HorizontalAlign="Center" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="Característica Empreendedora">
                                            <ItemTemplate>
                                                <%# DataBinder.Eval(Container.DataItem, "Criterio.QuestionarioEmpreendedorismoPorExtenso")%>
                                            </ItemTemplate>
                                            <HeaderStyle Width="200px" />
                                            <FooterTemplate>
                                                <asp:Label ID="lblTotal" runat="server" ForeColor="White" Font-Bold="true" Text="Total"></asp:Label></FooterTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Pontuação Máxima">
                                            <ItemTemplate>
                                                <%# DataBinder.Eval(Container.DataItem, "Criterio.QuestionarioEmpreendedorismoPontuacaoMaxima")%>
                                            </ItemTemplate>
                                            <HeaderStyle Width="130px" />
                                            <FooterTemplate>
                                                <asp:Label ID="lblTotalPontuacaoMaxima" runat="server" ForeColor="White" Font-Bold="true"
                                                    Text="100,00%"></asp:Label></FooterTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Pontuação Obtida">
                                            <ItemTemplate>
                                                <%# Vinit.SG.Common.DoubleUtils.ToString(Vinit.SG.Common.ObjectUtils.ToDouble(DataBinder.Eval(Container.DataItem, "Ponto"))) + "%"%>
                                            </ItemTemplate>
                                            <HeaderStyle Width="130px" />
                                            <FooterTemplate>
                                                <asp:Label ID="lblTotalPontuacaoObtida" ForeColor="White" Font-Bold="true" runat="server"></asp:Label></FooterTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Panel ID="pnlEmpreendedorPontuacao" runat="server">
                                </asp:Panel>
                            </td>
                        </tr>
                    </table>
                </div>
                <span><b>PONTUAÇÃO OBTIDA</b></span>
                <br />
                <p>
                    Ao interpretar a sua pontuação no perfil empreendedor, você deve considerar que
                    a escala pontua até 10% por característica de comportamento empreendedor. A pontuação
                    máxima que pode ser obtida na Parte II é 100%.</p>
                <br>
            </div>
            <span>INTERPRETAÇÃO DAS RESPOSTAS</span>
            <table border="1" cellpadding="0" cellspacing="0" width="732">
                <tr>
                    <td valign="top" width="360" align="center">
                        <b>Combinação</b>
                    </td>
                    <td valign="top" width="372">
                        <b>Significado</b>
                    </td>
                </tr>
                <tr>
                    <td valign="top" width="360">
                        Quando a pontuação obtida na característica <b>Planejamento e Monitoramento Sistemático</b>
                        for maior do que a de <b>Busca de Informações</b>.
                    </td>
                    <td valign="top" width="372">
                        O planejamento tende a apresentar, em maior intensidade, percepções do empreendedor,
                        ao invés de informações específicas de mercado
                    </td>
                </tr>
                <tr>
                    <td valign="top" width="360">
                        Quando a pontuação obtida na característica <b>Persistência </b>for maior do que
                        a de <b>Estabelecimento de Metas</b>.
                    </td>
                    <td valign="top" width="372">
                        O empreendedor tende a persistir em atividades numa intensidade superior a capacidade
                        de estabelecer um objetivo. Um grande distanciamento destas duas características
                        pode indicar uma propensão à teimosia.
                    </td>
                </tr>
                <tr>
                    <td valign="top" width="360">
                        Quando a pontuação obtida na característica <b>Persuasão e Rede de Contatos </b>
                        for maior do que a de <b>Comprometimento</b>.
                    </td>
                    <td valign="top" width="372">
                        <p>
                            Uma capacidade superior de convencer os outros do que a capacidade de cumprir com
                            o que foi combinado.</p>
                    </td>
                </tr>
                <tr>
                    <td valign="top" width="360">
                        <p>
                            Quando a pontuação obtida na característica <b>Persuasão e Rede de Contatos </b>
                            for maior do que a de <b>Exigência de Qualidade e Eficiência</b>
                        .
                    </td>
                    <td valign="top" width="372">
                        Uma capacidade superior de convencer os outros a respeito da qualidade daquilo que
                        oferece do que a capacidade de cumprir com o que foi oferecido.
                    </td>
                </tr>
                <tr>
                    <td valign="top" width="360">
                        Quando a pontuação obtida na característica <b>Busca de Oportunidade e Iniciativa
                        </b>for maior do que a de <b>Planejamento e Monitoramento Sistemático.</b>
                    </td>
                    <td valign="top" width="372">
                        O empreendedor tende a agir antes de planejar a ação.
                    </td>
                </tr>
                <tr>
                    <td valign="top" width="360">
                        Quando a pontuação obtida na característica <b>Planejamento e Monitoramento Sistemático
                        </b>for maior do que a de <b>Estabelecimento de Metas</b>.
                    </td>
                    <td valign="top" width="372">
                        Uma tendência a planejar as ações, contudo, sem a definição clara de um ponto de
                        chegada.
                    </td>
                </tr>
                <tr>
                    <td valign="top" width="360">
                        Quando a pontuação obtida na característica <b>Independência e Autoconfiança for maior
                            do que <b>todas as demais características</b>.
                    </td>
                    <td valign="top" width="372">
                        Como a característica Independência e Autoconfiança é a conseqüência do fortalecimento
                        de todas as demais características, tê-la numa pontuação muito superior às demais
                        pode ser indícios de uma AUTOAVALIAÇÃO superestimada da sua própria capacidade.
                    </td>
                </tr>
                <tr>
                    <td valign="top" width="360">
                        Quando a pontuação obtida na característica <b>Busca de Oportunidade e Iniciativa</b>
                        for maior do que a de <b>Estabelecimento de Metas</b>.
                    </td>
                    <td valign="top" width="372">
                        Tendência em priorizar à iniciativa na identificação e implantação de oportunidades
                        sem que estas sejam focos de metas e objetivos. Falta de foco.
                    </td>
                </tr>
                <tr>
                    <td valign="top" width="360">
                        Quando a pontuação obtida na característica <b>Correr Riscos Calculados </b>for
                        maior do que a de <b>Busca de Informações</b>.
                    </td>
                    <td valign="top" width="372">
                        A avaliação dos riscos fica prejudicada pela falta de informações. Tendência em
                        avaliar a partir de suposições.
                    </td>
                </tr>
                <tr>
                    <td valign="top" width="360">
                        Quando a pontuação obtida na característica <b>Busca de Informações </b>for maior
                        do que a de <b>Planejamento e Monitoramento Sistemático</b>.
                    </td>
                    <td valign="top" width="372">
                        Tendência em concentrar esforços na busca de informações e não canaliza para a implantação
                        de uma oportunidade através do planejamento.
                    </td>
                </tr>
            </table>
            <p>
                SAIBA MAIS SOBRE AS DEZ CARACTERÍSTICAS DE COMPORTAMENTO EMPREENDEDOR (adaptado
                de fontes diversas)
            </p>
            <p>
                <b>1. Busca de oportunidades e iniciativa</b><br />
                · Fazer as coisas de forma pró-ativa, antes de ser solicitado, ou de ser forçado
                pelas circunstâncias;<br />
                · Procurar expandir o negócio em novas áreas, mercados, produtos ou serviços;<br />
                · Aproveitar oportunidades detectadas de expandir ou começar um novo negócio, obter
                financiamentos, novos equipamentos, aprimorar o local de trabalho ou agregação de
                valor.<br />
                <p>
                    O empreendedor é alguém que está sempre buscando e se deparando com novas oportunidades.
                    Ao observar o ambiente interno e externo, costuma ter idéias que normalmente podem
                    ser transformadas em negócios e serem colocados em prática.
                </p>
            </p>
            <p>
                <b>2. Persistência</b><br />
                · Perceber os obstáculos como uma oportunidade para a superação;<br />
                · Repetir ou mudar de estratégia quando necessário, a fim de enfrentar um desafio
                ou superar um resultado indesejado;<br />
                · Assumir a responsabilidade pessoal pelo cumprimento das ações necessárias para
                atingir as metas e objetivos definidos.<br />
                <p>
                    A <b>persistência</b> é uma característica fundamental em qualquer empreendedor.
                    Todo negócio tem seus momentos difíceis, mas é preciso persistir e buscar superação
                    sempre, levando-se em conta o aprendizado obtido.
                </p>
            </p>
            <p>
                <b>3. Comprometimento</b><br />
                · Fazer sacrifícios pessoais ou despender esforços extraordinários para completar
                uma tarefa;<br />
                · Colaborar com os empregados, colaboradores e parceiros ou assumir o papel deles,
                se necessário, para terminar um trabalho;<br />
                · Esmerar-se para manter as partes envolvidas satisfeitas e colocar em primeiro
                lugar a justiça e a boa vontade em longo prazo, acima de ganhos de curto prazo.<br />
                <p>
                    Estar comprometido significa ter envolvimento pessoal para que os compromissos assumidos
                    sejam respeitados. Isso é fator chave para o sucesso pessoal e profissional. Às
                    vezes, um esforço extra é necessário para garantir relacionamentos de qualidade
                    e de longo prazo.
                </p>
            </p>
            <p>
                <b>4. Exigência de qualidade e eficiência</b><br />
                · Encontrar maneiras de fazer as coisas melhor, mais rápidas, com mais eficiência
                na utilização dos recursos;<br />
                · Fazer com que os produtos e serviços atendam ou até excedam às expectativas, dentro
                de padrões de excelência; · Desenvolver e utilizar procedimentos e padrões de trabalho
                para assegurar que as tarefas sejam terminadas em tempo e dentro dos padrões de
                qualidade e de custo previamente acordados.
                <p>
                    A exigência de qualidade e eficiência é um importante diferencial em qualquer tipo
                    de negócio. Quando os prazos e a qualidade esperada pelo cliente são garantidos,
                    conquista-se a confiança do cliente. Lembre-se que, por mais qualidade que você
                    forneça é preciso estar sempre melhorando, para se ajustar às mudanças tecnológicas,
                    comportamentais, tendências de mercado e se destacar em relação à concorrência.
                </p>
            </p>
            <p>
                <b>5. Correr riscos calculados</b><br />
                · Considerar os recursos físicos, organizacionais e financeiros - seus pontos fortes
                e fracos – ao avaliar as situações e correr riscos;<br />
                · Buscar deliberadamente reduzir os riscos ou controlar os resultados;<br />
                · Colocar-se em situações que implicam desafios ou riscos moderados.<br />
                <p>
                    Montar uma empresa ou investir para melhorá-la implica riscos. Ser ousado é muito
                    importante para se ter um diferencial competitivo. No entanto, é fundamental calcular
                    esses riscos para saber quando você deve arriscar para fazer sua empresa crescer.
                    Aprender a correr riscos calculados significa avaliar bem as possibilidades, tentar
                    minimizar os riscos e controlar os resultados. Se, por exemplo, você desejar investir
                    em sua empresa para aumentar a produção e as vendas, é importante realizar uma pesquisa
                    para saber se existe mercado para absorver este volume de produção adicional, bem
                    como se a infra-estrutura atual, os recursos de caixa e as competências instaladas
                    favorecem a decisão.</p>
            </p>
            <p>
                <b>6. Estabelecimento de metas</b><br />
                · Estabelecer metas e objetivos que sejam desafiantes, factíveis e que tenham significado
                pessoal ou pressuponham uma vocação natural;<br />
                · Definir metas tanto de curto, como de médio e longo prazo. Que sejam claras, realistas,
                mensuráveis, coerentes e integradas com aquelas estabelecidas em outras áreas do
                negócio;<br />
                <p>
                    Estabelecer uma meta é muito importante, pois especifica as condições, o tempo e
                    aonde se quer chegar. Para atingir sua meta é interessante que você crie estratégias
                    e estabeleça indicadores para verificar se está se aproximando ou afastando delas.
                    Se sua meta é aprimorar a gestão de sua empresa, a participação neste Prêmio é uma
                    ótima oportunidade para você avaliar seu comportamento empreendedor, e os pontos
                    fortes e oportunidades de melhoria na gestão da empresa.
                </p>
            </p>
            <p>
                <b>7. Busca de informações</b><br />
                · Dedicar-se para obter informações econômicas, tecnológicas, sociais, político-legais,
                tendências de mercado, de clientes, atuação dos fornecedores e dos concorrentes;<br />
                · Investigar produtos e serviços oferecidos, pela concorrência, prazos, preços,
                condições de pagamento, entrega e serviços complementares praticados;<br />
                · Consultar especialistas e organizações que atuam em gestão empresarial para obter
                assessoria técnica, econômica, legal ou comercial.<br />
                · Conhecer a realidade do setor e da cadeia produtiva em que a empresa está inserida.
                <p>
                    Conversar com colaboradores, clientes, fornecedores e concorrentes é essencial para
                    posicionar melhor sua empresa no mercado.</p>
                <p>
                    É inerente a um empreendedor querer saber mais e mais. Saber identificar e filtrar
                    as fontes de informações ajuda a melhorar a percepção do seu negócio. Você pode
                    obter informações de diversas fontes. Procure saber as opiniões dos consumidores
                    sobre o seu produto, fique atento às suas sugestões e observações; pesquise maneiras
                    de melhorar seu produto ou serviço; identifique vantagens e desvantagens de sua
                    empresa em relação à concorrência; leia jornais, revistas, e publicações setoriais,
                    navegue na Internet. Há sempre cursos e palestras e novas informações no mercado.
                    Visite o concorrente, experimente o modelo dele e, quando a sua pesquisa pessoal
                    não for suficiente, procure a ajuda especializada de um técnico. Lembre-se de consultar
                    o SEBRAE, Associações Empresariais, o IBQP, a FNQ, dentre outros, pois são organizações,
                    que possuem publicações, cursos e serviços relacionados à gestão que poderão lhe
                    ser muito úteis.
                </p>
            </p>
            <p>
                <b>8. Planejamento e monitoramento sistemáticos</b><br />
                · Planejar dividindo grandes tarefas em sub-tarefas, com prazos, resultados esperados,
                forma de atuação e responsáveis bem definidos;<br />
                · Revisar seus planos constantemente, levando em conta os resultados obtidos e as
                mudanças e ajustes circunstanciais necessários;<br />
                · Manter registros dos dados e fatos e utilizá-los na tomada de decisões e solução
                de problemas.<br />
                · Comparar previsto com o realizado.<br />
                <p>
                    Para se tornar um empreendedor bem-sucedido é preciso que você aprenda a planejar.
                    Por isso, é indispensável que você aprenda a programar suas ações futuras.
                </p>
                <p>
                    Além de planejar, é preciso acompanhamento permanente dos resultados da empresa
                    – fazer o que se chama de monitoramento sistemático, e a adoção de medidas corretivas
                    ou ajustes sempre que necessário. Por último padronizar o que funciona bem e aprimorar
                    o que for detectado como aprendizado. (Ciclo PDCA)
                </p>
            </p>
            <p>
                <b>9. Persuasão e rede de contatos</b><br />
                · Utilizar estratégias deliberadas para influenciar ou persuadir os outros, sempre
                com pragmatismo e valores éticos comuns;<br />
                · Utilizar pessoas-chave como agentes para atingir seus próprios objetivos;<br />
                · Desenvolver e manter relações e parcerias comerciais de qualidade e sustentáveis.<br />
                <p>
                    Um empreendedor está sempre em contato com muitas pessoas: clientes, fornecedores,
                    concorrentes, técnicos, especialistas de diversas áreas etc. Muitas vezes, são pessoas
                    que não estão diretamente ligadas ao seu negócio, mas que, a qualquer momento, podem
                    lhe ser muito úteis. Busque, portanto, manter contato com as pessoas que podem se
                    tornar fonte de informações e/ou soluções para você.
                </p>
                <p>
                    Todo empreendedor além da rede de contatos: precisa saber convencer as pessoas a
                    fazerem o que se espera delas: convencer um cliente a experimentar o produto, um
                    fornecedor a entregar mais rápido, ou um colaborador a mudar sua forma de trabalhar,
                    por exemplo. Mas, para convencer alguém, é preciso saber se comunicar de forma assertiva,
                    ter bons argumentos, comprometimento com o que foi acordado e que ambas as partes
                    se beneficiem no processo.
                </p>
            </p>
            <p>
                <b>10. Independência e autoconfiança</b>
                <br />
                · Buscar autonomia em relação a normas e controles sendo impostos por outras pessoas;<br />
                · Manter seu ponto de vista, mesmo diante da oposição ou de resultados inicialmente
                desanimadores, se sua experiência de vida justificar tal decisão;<br />
                · Expressar confiança na sua própria capacidade de complementar uma tarefa difícil
                ou de enfrentar um desafio.
                <p>
                    A autoconfiança é fonte de inspiração para colaboradores e membros da rede de contatos.
                    Ela é um dos fatores que asseguram o papel de liderança em uma organização.
                </p>
            </p>
        </div>
        <div id="parte2RecomendacoesGerais" runat="server">
            <p>
                RECOMENDAÇÕES GERAIS:
            </p>
            <br />
            · Lembre-se que a devolutiva reflete uma autoavaliação, desta forma, mostra a sua
            percepção referente ao seu próprio comportamento.
            <br />
            · Procure fortalecer as características mais fracas.
            <br />
            · Procure utilizar uma característica forte para desenvolver uma fraca. Ex. Caso
            você tenha Persistência como uma característica forte e Planejamento e Monitoramento
            Sistemático como fraca, poderá utilizar a persistência para desenvolver a capacidade
            de planejar.
            <br />
            · Quanto mais equilibrado for o perfil, melhor tende a ser o desempenho do empreendedor.
            <br />
            · Procure evitar a dependência de uma única característica empreendedora para suas
            ações de negócio.
            <br />
            · O Sebrae oferece capacitações específicas voltadas ao desenvolvimento de características
            empreendedoras. Caso seja do seu interesse procure o SEBRAE local e inscreva-se
            no EMPRETEC . Ele é um curso que trabalha muito os aspectos comportamentais do empreendedor.
        </div>
        <div id="ResponsabilidadeSocial" runat="server">
            <p align="center">
                PARTE III: RESPONSABILIDADE SOCIAL
            </p>
            <p>
                A terceira parte do questionário avalia as boas práticas de responsabilidade social,
                identificando como a empresa contribui para o desenvolvimento sustentável da sociedade,
                a preservação dos recursos ambientais e culturais, a diversidade, promovendo a redução
                da desigualdade sociais como parte da estratégia do seu negócio. As respostas abaixo
                são as preenchidas pela empresa na fase de autoavaliação.
            </p>
            <p class="style13">
                <b>RESPOSTAS DADAS PELA EMPRESA</b><br />
                <div class="style23">
                    <uc9:UCRelatorioPerguntaResponsabilidadeSocial ID="UCRelatorioPerguntaResponsabilidadeSocial1"
                        runat="server" />
                </div>
            </p>
        </div>
        <div id="Inovacao" runat="server">
            <p align="center">
                PARTE IV: INOVAÇÂO
            </p>
            <p>
                .............
            </p>
            <p class="style13">
                <b>RESPOSTAS DADAS PELA EMPRESA</b><br />
                <div class="style23">
                    <uc10:UCRelatorioPerguntaInovacao ID="UCRelatorioPerguntaInovacao1" runat="server" />
                </div>
            </p>
        </div>
    </form>
</body>
</html>
