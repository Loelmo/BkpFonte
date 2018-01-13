<%@ Page Title="Glossário" Language="C#" MasterPageFile="~/Master Page/Principal.Master" AutoEventWireup="true" CodeBehind="Glossario.aspx.cs" Inherits="PEG.Paginas.Glossario" %>

<%@ Register Src="../User Control Base/UCLoading.ascx" TagName="UCLoading" TagPrefix="uc1" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <fieldset >
        <legend style="font-weight: bold;">Glossário</legend>
                <table cellspacing="1" cellpadding="1" width="100%" align="center" border="0">
            <tr>
                <td>
Os conceitos e definições aqui apresentados não têm a pretensão de normalizar terminologia, refletindo, apenas, o significado de termos utilizados para tratar de sistemas de gestão. 
<br />
<br />
<b>A</b>
<br />
<b>Análise de desempenho:</b><br /> verificação profunda e global, produto, serviço processo ou informação quanto a requisitos, objetivando identificar problemas e propor soluções.
<br />
<br />
<b>C</b>
<br />
<b>Classe mundial:</b><br /> termo utilizado para caracterizar uma empresa, prática de gestão ou resultado como referencial de excelência.
<br />
<b>Cliente:</b><br /> destinatário dos produtos da empresa. Pode ser uma pessoa física ou jurídica. É quem adquire (comprador) ou quem utiliza o produto (usuário/consumidor)
<br />
<b>Colaboradores:</b><br /> pessoas que compõem uma empresa e que contribuem para a consecução de suas estratégias, objetivos e metas, tais como empregados em tempo integral ou parcial, temporários, autônomos e contratados de terceiros que trabalham sob a coordenação direta da empresa.
<br />
<b>Comunidades:</b><br /> agrupamento de pessoas influenciado diretamente pela empresa, conforme o seu perfil. Por exemplo, a comunidade de familiares dos colaboradores, comunidade local, comunidade acadêmica, comunidade setorial, etc.
<br />
<br />
<b>D</b>
<br />
<b>Dirigentes:</b><br /> membros de escalões superiores (empresários, diretores, sócios, executivos, etc.) que compartilham a responsabilidade principal pelo desempenho, pelos resultados e pela definição dos rumos da empresa.
<br />
<br />
<b>E</b>
<br />
<b>Estratégia:</b><br /> caminho escolhido para posicionar a empresa de forma competitiva e garantir sua continuidade no logo prazo, com a subseqüente definição de atividades e competências inter-relacionadas para adicionar valor de maneira diferenciada às partes interessadas. É um conjunto de decisões que orientam a definição das ações a serem executadas pela empresa. As estratégias podem conduzir a novos produtos, novos mercados, crescimento de receitas, redução de custos, aquisições, fusões e novas alianças ou parcerias. Podem ser dirigidas a tornar a empresa um fornecedor preferencial, um produtor de baixo custo, um inovador no mercado e/ou um provedor de serviços exclusivos e individualizados. As estratégias podem depender ou exigir que a empresa desenvolva diferentes tipos de capacidades, tais como agilidade de resposta, individualização, compreensão do mercado, manufatura enxuta ou virtual, rede de relacionamentos, inovação rápida, gestão tecnológica, alavancagem de ativos e gestão da informação.
<br />
<br />
<b>F</b>
<br />
<b>Fornecedor:</b><br /> qualquer empresa que forneça bens e serviços. A utilização desses bens e serviços pode ocorrer em qualquer estágio do projeto, produção e uso dos produtos. Assim, fornecedores podem incluir distribuidores, revendedores, prestadores de serviço terceirizados, transportadores, contratados e franquias, bem como os que suprem a organização com materiais e componentes. São também fornecedores os prestadores de serviços das áreas de saúde, treinamento e educação.
<br />
<br />
<b>I</b>
<br />
<b>Indicadores:</b><br /> dados ou informações numéricas que quantificam as entradas (recursos ou insumos), saídas (produtos) e o desempenho de processos, produtos e da empresa como um todo. Os indicadores são usados para acompanhar e melhorar o resultado ao longo do tempo e podem ser classificados em: simples (decorrentes de uma única medição) ou compostos; diretos ou indiretos em relação à característica medida; específicos (atividades ou processos específicos) ou globais (resultados pretendidos pela organização); e direcionadores (drivers) ou resultantes (outcomes).
<br />
<b>Informações:</b><br /> tratamento padronizado de dados, por meio de sistemas de informação, informatizados ou não.
<br />
<b>Informações comparativas pertinentes:</b><br /> informações oriundas de referenciais selecionados de forma lógica, não casual. Podem ser representadas por informações sobre resultados alcançados por outras empresas, assim como pela forma de funcionamento das práticas de gestão, e características e desempenhos de produtos. Existem quatro tipos básicos de referencial: competitivo (por exemplo, informações dos concorrentes); similar (baseado em dados de empresas que, embora não sejam concorrentes, apresentam características similares de porte, tecnologia ou outras); de excelência (organização de reconhecida competência, classe mundial); e de grande grupo (dados baseados em muitas empresas não similares, obtidos, por exemplo, de grupos de benchmarking).
<br />
<b>Inovação:</b><br /> Segundo o Manual de Oslo1, inovação é a implementação de um produto (bem ou serviço) novo ou significativamente melhorado, ou um processo, ou um novo método de marketing, ou um novo método organizacional, mas práticas de negócios, e na organização local do trabalho ou nas relações externas.
<br />
<br />
<b>M</b>
<br />
<b>Metas:</b><br /> níveis de desempenho pretendidos para determinado período de tempo.
<br />
<b>Missão:</b><br /> razão de ser de uma empresa, necessidades sociais a que ela atende e seu foco fundamental de atividades.
<br />
<br />
<b>P</b>
<br />
<b>PCMSO:</b><br /> Programa de Controle Médico de Saúde Ocupacional. Sua implantação visa à prevenção da saúde do trabalhador.
<br />
<b>PPRA:</b><br /> Programa de Prevenção de Riscos Ambientais que tem por objetivo definir uma metodologia de ação que garanta a preservação da saúde e integridade dos trabalhadores face aos riscos existentes nos ambientes de trabalho.
<br />
<b>Planos de ação:</b><br /> principais propulsores organizacionais, resultantes do desdobramento das estratégias de curto e longo prazo. De maneira geral, os planos de ação são estabelecidos para realizar aquilo que a organização deve fazer bem feito para que sua estratégia seja bem sucedida. O desenvolvimento dos planos de ação é de fundamental importância no processo de planejamento para que os objetivos estratégicos e as metas sejam entendidos e desdobrados para toda a empresa. O desdobramento dos planos de ação requer uma análise do montante de recursos necessários e a adoção de medidas de alinhamento para todas as unidades de trabalho. O desdobramento pode também exigir a capacitação de algumas pessoas da força de trabalho ou do recrutamento de novas pessoas.
<br />
<b>Processo:</b><br /> conjunto de recursos e atividades inter-relacionados que transformam insumos (entradas) em produtos (saídas). Essa transformação deve agregar valor na percepção dos clientes do processo e exige certo conjunto de recursos. Estes podem incluir pessoal, finanças, instalações, equipamentos, métodos e técnicas, numa seqüência de etapas ou ações sistemáticas. O processo poderá exigir a documentação da seqüência de etapas por meio de especificações, procedimentos e instruções de trabalho, bem como a definição adequada das etapas de medição e controle.
<br />
<b>Processos de apoio:</b><br /> são aqueles que dão suporte direto aos processos relativos ao produto (projeto, produção e entrega).
<br />
<b>Processos principais do negócio:</b><br /> processos que geram os produtos finais da empresa e que contribuem diretamente para a criação de valor para os clientes. Envolvem tanto a fabricação de bens como a prestação de serviços. É parte do conjunto dos processos relativos ao produto.
<br />
<br />
<b>Q</b>
<br />
<b>Qualidade:</b><br /> totalidade das características de uma entidade (atividade ou processo, produto, organização, ou uma combinação destes), que lhe confere a capacidade de satisfazer as necessidades explícitas e implícitas dos clientes e demais partes interessadas.
<br />
<br />
<b>R</b>
<br />
<b>Reconhecimento:</b><br /> atividade de destacar pessoas, individualmente ou em grupo, pela sua contribuição especial à organização (trata do aspecto motivacional).
<br />
<b>Requisitos:</b><br /> tradução das necessidades dos clientes ou das demais interessadas, expressas de maneira formal ou informal, em características objetivas para o produto ou sua entrega. Exemplos de requisitos incluem prazo de entrega, tempo de garantia, especificação técnica, tempo de atendimento, qualificação de pessoal, preço e condições de pagamento.
<br />
<br />
<b>S</b>
<br />
<b>Sistema:</b><br /> conjunto de elementos com uma finalidade comum, que se relacionam entre si, formando um todo dinâmico.
<br />
<b>Sistema de aprendizado:</b><br /> conjunto de recursos e práticas voltado para facilitar e estimular o aprendizado organizacional em suas diversas instâncias, incluindo aspectos formais e informais.
<br />
<b>Sistema de liderança:</b><br /> conjunto de atividades e práticas voltado para o exercício da liderança, isto é, procedimentos, critérios e a maneira como as principais decisões são tomadas, comunicadas e conduzidas, em todos os níveis da empresa.
<br />
<br />
<b>V</b>
<br />
<b>Valores:</b><br /> princípios que regem comportamentos e atitudes das pessoas nas empresas, e sobre os quais todas as relações do negócio estão baseadas. Por exemplo: confiança e ética.
<br />
<b>Visão:</b><br /> estado que a empresa deseja atingir no futuro. A visão busca propiciar o direcionamento dos rumos de uma empresa.
                </td>
            </tr>
        </table>
    </fieldset>
</asp:Content>