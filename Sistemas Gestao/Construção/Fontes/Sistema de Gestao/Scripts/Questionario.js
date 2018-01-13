function mostraAjuda(objDiv) {
    document.getElementById(objDiv).style.display = "block";
    return false;
}

function escondeAjuda(objDiv) {
    document.getElementById(objDiv).style.display = "none";
    return false;
}

function mostraJustificativa() {
    var justificativa = "ContentPlaceHolder1_UCPerguntaMultiplaEscolha4Opcoes1_divJustificativa";
    if (document.getElementById(justificativa) == undefined) {
        justificativa = "ctl00_ContentPlaceHolder1_UCPerguntaMultiplaEscolha4Opcoes1_divJustificativa";
    }
    document.getElementById(justificativa).style.display = "block";
    return false;
}

function escondeJustificativa() {
    var justificativa = "ContentPlaceHolder1_UCPerguntaMultiplaEscolha4Opcoes1_divJustificativa";
    if (document.getElementById(justificativa) == undefined) {
        justificativa = "ctl00_ContentPlaceHolder1_UCPerguntaMultiplaEscolha4Opcoes1_divJustificativa";
    }
    document.getElementById(justificativa).style.display = "none";
    return false;
}

function DesabilitaCampoUnico(txt1) {
    document.getElementById(txt1).disabled = true;
    document.getElementById(txt1).style.backgroundColor = '#E8E8E8';
}

function HabilitaCampoUnico(txt1) {
    document.getElementById(txt1).disabled = false;
    document.getElementById(txt1).style.backgroundColor = '#FFFFFF';
}

function DesabilitaCampos(txt1, txt2, txt3) {
    document.getElementById(txt1).disabled = true;
    document.getElementById(txt1).style.backgroundColor = '#E8E8E8';
    document.getElementById(txt2).disabled = true;
    document.getElementById(txt2).style.backgroundColor = '#E8E8E8';
    document.getElementById(txt3).disabled = true;
    document.getElementById(txt3).style.backgroundColor = '#E8E8E8';
}

function HabilitaCampos(txt1, txt2, txt3) {
    document.getElementById(txt1).disabled = false;
    document.getElementById(txt1).style.backgroundColor = '#FFFFFF';
    document.getElementById(txt2).disabled = false;
    document.getElementById(txt2).style.backgroundColor = '#FFFFFF';
    document.getElementById(txt3).disabled = false;
    document.getElementById(txt3).style.backgroundColor = '#FFFFFF';
}

function salvaJustificativa() {
    var nomeCampo = "ContentPlaceHolder1_UCPerguntaMultiplaEscolha4Opcoes1_TxtJustificativa";
    var nomeCampoHidden = "ContentPlaceHolder1_UCPerguntaMultiplaEscolha4Opcoes1_HddnFldJustificativa";
    var botaoAnterior = "ContentPlaceHolder1_UCPerguntaMultiplaEscolha4Opcoes1_botaoAnterior";
    var botaoProximo = "ContentPlaceHolder1_UCPerguntaMultiplaEscolha4Opcoes1_botaoProximo";
    var divJustificativa = "ContentPlaceHolder1_UCPerguntaMultiplaEscolha4Opcoes1_divJustificativa";
    if (document.getElementById(nomeCampo) == undefined) {
        nomeCampo = "ctl00_ContentPlaceHolder1_UCPerguntaMultiplaEscolha4Opcoes1_TxtJustificativa";
        botaoAnterior = "ctl00_ContentPlaceHolder1_UCPerguntaMultiplaEscolha4Opcoes1_botaoAnterior";
        botaoProximo = "ctl00_ContentPlaceHolder1_UCPerguntaMultiplaEscolha4Opcoes1_botaoProximo";
        divJustificativa = "ctl00_ContentPlaceHolder1_UCPerguntaMultiplaEscolha4Opcoes1_divJustificativa";
        nomeCampoHidden = "ctl00_ContentPlaceHolder1_UCPerguntaMultiplaEscolha4Opcoes1_HddnFldJustificativa";
    }
    if (document.getElementById(nomeCampo).value == '' || document.getElementById(nomeCampo).value == ' ' || document.getElementById(nomeCampo).value == '  ') {
        alert('Insira uma justificativa');
        return false;
    } else {
        document.getElementById(divJustificativa).style.display = "none";
        document.getElementById(nomeCampoHidden).value = document.getElementById(nomeCampo).value;
    }

    document.getElementById(botaoAnterior).style.display = 'block';
    document.getElementById(botaoProximo).style.display = 'block';
    return true;
}

function cancelaJustificativa() {
    var nomeCampo = "ContentPlaceHolder1_UCPerguntaMultiplaEscolha4Opcoes1_TxtJustificativa";
    var nomeCampoHidden = "ContentPlaceHolder1_UCPerguntaMultiplaEscolha4Opcoes1_HddnFldJustificativa";
    var botaoAnterior = "ContentPlaceHolder1_UCPerguntaMultiplaEscolha4Opcoes1_botaoAnterior";
    var botaoProximo = "ContentPlaceHolder1_UCPerguntaMultiplaEscolha4Opcoes1_botaoProximo";
    var divJustificativa = "ContentPlaceHolder1_UCPerguntaMultiplaEscolha4Opcoes1_divJustificativa";
    if (document.getElementById(nomeCampo) == undefined) {
        nomeCampo = "ctl00_ContentPlaceHolder1_UCPerguntaMultiplaEscolha4Opcoes1_TxtJustificativa";
        botaoAnterior = "ctl00_ContentPlaceHolder1_UCPerguntaMultiplaEscolha4Opcoes1_botaoAnterior";
        botaoProximo = "ctl00_ContentPlaceHolder1_UCPerguntaMultiplaEscolha4Opcoes1_botaoProximo";
        divJustificativa = "ctl00_ContentPlaceHolder1_UCPerguntaMultiplaEscolha4Opcoes1_divJustificativa";
        nomeCampoHidden = "ctl00_ContentPlaceHolder1_UCPerguntaMultiplaEscolha4Opcoes1_HddnFldJustificativa";
    }

    document.getElementById(nomeCampo).value = document.getElementById(nomeCampoHidden).value;

    if (document.getElementById(nomeCampo).value != '' && document.getElementById(nomeCampo).value != ' ' && document.getElementById(nomeCampo).value != '  ') {
        document.getElementById(botaoAnterior).style.display = 'block';
        document.getElementById(botaoProximo).style.display = 'block';
    }

    document.getElementById(divJustificativa).style.display = "none";

    return false;
}

function cancelaDevolucao() {
    var nomeCampo = "ContentPlaceHolder1_divDevolucao";
    if (document.getElementById(nomeCampo) == undefined) {
        nomeCampo = "ctl00_ContentPlaceHolder1_divDevolucao";
    }
    document.getElementById(nomeCampo).style.display = "none";

    return false;
}

function verificaComentariosAvaliador() {
    var pontoForte = "ContentPlaceHolder1_UCListaQuestionariosAvaliacao1_UCPerguntaAvaliar1_TxtPontoForte";
    var oportunidadeMelhoria = "ContentPlaceHolder1_UCListaQuestionariosAvaliacao1_UCPerguntaAvaliar1_TxtOportunidade";
    var opcaoA = "ContentPlaceHolder1_UCListaQuestionariosAvaliacao1_UCPerguntaAvaliar1_UCPerguntaMultiplaEscolha4Opcoes1_radioA";
    var opcaoB = "ContentPlaceHolder1_UCListaQuestionariosAvaliacao1_UCPerguntaAvaliar1_UCPerguntaMultiplaEscolha4Opcoes1_radioB";
    var opcaoC = "ContentPlaceHolder1_UCListaQuestionariosAvaliacao1_UCPerguntaAvaliar1_UCPerguntaMultiplaEscolha4Opcoes1_radioC";
    var opcaoD = "ContentPlaceHolder1_UCListaQuestionariosAvaliacao1_UCPerguntaAvaliar1_UCPerguntaMultiplaEscolha4Opcoes1_radioD";
    if (document.getElementById(pontoForte) == undefined) {
        pontoForte = "ctl00_ContentPlaceHolder1_UCListaQuestionariosAvaliacao1_UCPerguntaAvaliar1_TxtPontoForte";
        oportunidadeMelhoria = "ctl00_ContentPlaceHolder1_UCListaQuestionariosAvaliacao1_UCPerguntaAvaliar1_TxtOportunidade";
        opcaoA = "ctl00_ContentPlaceHolder1_UCListaQuestionariosAvaliacao1_UCPerguntaAvaliar1_UCPerguntaMultiplaEscolha4Opcoes1_radioA";
        opcaoB = "ctl00_ContentPlaceHolder1_UCListaQuestionariosAvaliacao1_UCPerguntaAvaliar1_UCPerguntaMultiplaEscolha4Opcoes1_radioB";
        opcaoC = "ctl00_ContentPlaceHolder1_UCListaQuestionariosAvaliacao1_UCPerguntaAvaliar1_UCPerguntaMultiplaEscolha4Opcoes1_radioC";
        opcaoD = "ctl00_ContentPlaceHolder1_UCListaQuestionariosAvaliacao1_UCPerguntaAvaliar1_UCPerguntaMultiplaEscolha4Opcoes1_radioD";
    }
    if (document.getElementById(opcaoA).checked == true) {
        if (document.getElementById(oportunidadeMelhoria).value == '' || document.getElementById(oportunidadeMelhoria).value == ' ' || document.getElementById(oportunidadeMelhoria).value == '  ') {
            alert("Insira uma Oportunidade de Melhoria");
            document.getElementById(oportunidadeMelhoria).focus();
            return false;
        }
    } else if (document.getElementById(opcaoB).checked == true) {
        if (document.getElementById(oportunidadeMelhoria).value == '' || document.getElementById(oportunidadeMelhoria).value == ' ' || document.getElementById(oportunidadeMelhoria).value == '  ') {
            alert("Insira uma Oportunidade de Melhoria");
            document.getElementById(oportunidadeMelhoria).focus();
            return false;
        }
    } else if (document.getElementById(opcaoC).checked == true) {
        if (document.getElementById(pontoForte).value == '' || document.getElementById(pontoForte).value == ' ' || document.getElementById(pontoForte).value == '  ') {
            alert("Insira um Ponto Forte");
            document.getElementById(pontoForte).focus();
            return false;
        }
    } else if (document.getElementById(opcaoD).checked == true) {
        if (document.getElementById(pontoForte).value == '' || document.getElementById(pontoForte).value == ' ' || document.getElementById(pontoForte).value == '  ') {
            alert("Insira um Ponto Forte");
            document.getElementById(pontoForte).focus();
            return false;
        }
    }
    return true;
}

function selecionaResposta(letra) {
    var lblResposta1 = "ContentPlaceHolder1_UCPerguntaMultiplaEscolha4Opcoes1_coluna1Resposta" + letra;
    var lblResposta1A = "ContentPlaceHolder1_UCPerguntaMultiplaEscolha4Opcoes1_coluna1RespostaA";
    var lblResposta1B = "ContentPlaceHolder1_UCPerguntaMultiplaEscolha4Opcoes1_coluna1RespostaB";
    var lblResposta1C = "ContentPlaceHolder1_UCPerguntaMultiplaEscolha4Opcoes1_coluna1RespostaC";
    var lblResposta1D = "ContentPlaceHolder1_UCPerguntaMultiplaEscolha4Opcoes1_coluna1RespostaD";
    var lblResposta2 = "ContentPlaceHolder1_UCPerguntaMultiplaEscolha4Opcoes1_coluna2Resposta" + letra;
    var lblResposta2A = "ContentPlaceHolder1_UCPerguntaMultiplaEscolha4Opcoes1_coluna2RespostaA";
    var lblResposta2B = "ContentPlaceHolder1_UCPerguntaMultiplaEscolha4Opcoes1_coluna2RespostaB";
    var lblResposta2C = "ContentPlaceHolder1_UCPerguntaMultiplaEscolha4Opcoes1_coluna2RespostaC";
    var lblResposta2D = "ContentPlaceHolder1_UCPerguntaMultiplaEscolha4Opcoes1_coluna2RespostaD";
    var respostaA = "ContentPlaceHolder1_UCPerguntaMultiplaEscolha4Opcoes1_respostaA";
    var respostaB = "ContentPlaceHolder1_UCPerguntaMultiplaEscolha4Opcoes1_respostaB";
    var respostaC = "ContentPlaceHolder1_UCPerguntaMultiplaEscolha4Opcoes1_respostaC";
    var respostaD = "ContentPlaceHolder1_UCPerguntaMultiplaEscolha4Opcoes1_respostaD";
    var respostaLetra = "ContentPlaceHolder1_UCPerguntaMultiplaEscolha4Opcoes1_resposta" + letra;
    var respostaSelecionada = "ContentPlaceHolder1_UCPerguntaMultiplaEscolha4Opcoes1_respostaSelecionada";
    var respostaLetraJust = "ContentPlaceHolder1_UCPerguntaMultiplaEscolha4Opcoes1_hdnResposta" + letra + "_Just";
    var botaoAnterior = "ContentPlaceHolder1_UCPerguntaMultiplaEscolha4Opcoes1_botaoAnterior";
    var botaoProximo = "ContentPlaceHolder1_UCPerguntaMultiplaEscolha4Opcoes1_botaoProximo";
    var botaoJustificativa = "ContentPlaceHolder1_UCPerguntaMultiplaEscolha4Opcoes1_botaoJustificativa";
    if (document.getElementById(respostaA) == undefined) {
        lblResposta1 = "ctl00_ContentPlaceHolder1_UCPerguntaMultiplaEscolha4Opcoes1_coluna1Resposta" + letra;
        lblResposta1A = "ctl00_ContentPlaceHolder1_UCPerguntaMultiplaEscolha4Opcoes1_coluna1RespostaA";
        lblResposta1B = "ctl00_ContentPlaceHolder1_UCPerguntaMultiplaEscolha4Opcoes1_coluna1RespostaB";
        lblResposta1C = "ctl00_ContentPlaceHolder1_UCPerguntaMultiplaEscolha4Opcoes1_coluna1RespostaC";
        lblResposta1D = "ctl00_ContentPlaceHolder1_UCPerguntaMultiplaEscolha4Opcoes1_coluna1RespostaD";
        lblResposta2 = "ctl00_ContentPlaceHolder1_UCPerguntaMultiplaEscolha4Opcoes1_coluna2Resposta" + letra;
        lblResposta2A = "ctl00_ContentPlaceHolder1_UCPerguntaMultiplaEscolha4Opcoes1_coluna2RespostaA";
        lblResposta2B = "ctl00_ContentPlaceHolder1_UCPerguntaMultiplaEscolha4Opcoes1_coluna2RespostaB";
        lblResposta2C = "ctl00_ContentPlaceHolder1_UCPerguntaMultiplaEscolha4Opcoes1_coluna2RespostaC";
        lblResposta2D = "ctl00_ContentPlaceHolder1_UCPerguntaMultiplaEscolha4Opcoes1_coluna2RespostaD";
        respostaA = "ctl00_ContentPlaceHolder1_UCPerguntaMultiplaEscolha4Opcoes1_respostaA";
        respostaB = "ctl00_ContentPlaceHolder1_UCPerguntaMultiplaEscolha4Opcoes1_respostaB";
        respostaC = "ctl00_ContentPlaceHolder1_UCPerguntaMultiplaEscolha4Opcoes1_respostaC";
        respostaD = "ctl00_ContentPlaceHolder1_UCPerguntaMultiplaEscolha4Opcoes1_respostaD";
        respostaLetra = "ctl00_ContentPlaceHolder1_UCPerguntaMultiplaEscolha4Opcoes1_resposta" + letra;
        respostaSelecionada = "ctl00_ContentPlaceHolder1_UCPerguntaMultiplaEscolha4Opcoes1_respostaSelecionada";
        respostaLetraJust = "ctl00_ContentPlaceHolder1_UCPerguntaMultiplaEscolha4Opcoes1_hdnResposta" + letra + "_Just";
        botaoAnterior = "ctl00_ContentPlaceHolder1_UCPerguntaMultiplaEscolha4Opcoes1_botaoAnterior";
        botaoProximo = "ctl00_ContentPlaceHolder1_UCPerguntaMultiplaEscolha4Opcoes1_botaoProximo";
        botaoJustificativa = "ctl00_ContentPlaceHolder1_UCPerguntaMultiplaEscolha4Opcoes1_botaoJustificativa";
    }
    if (navigator.appName == "Microsoft Internet Explorer") {
        document.getElementById(respostaA).childNodes[0].style.display = 'none';
        document.getElementById(respostaB).childNodes[0].style.display = 'none';
        document.getElementById(respostaC).childNodes[0].style.display = 'none';
        document.getElementById(respostaD).childNodes[0].style.display = 'none';
        document.getElementById(respostaLetra).childNodes[0].style.display = 'block';
        document.getElementById(respostaSelecionada).value = letra;
    } else {
        document.getElementById(respostaA).childNodes[1].style.display = 'none';
        document.getElementById(respostaB).childNodes[1].style.display = 'none';
        document.getElementById(respostaC).childNodes[1].style.display = 'none';
        document.getElementById(respostaD).childNodes[1].style.display = 'none';
        document.getElementById(respostaLetra).childNodes[1].style.display = 'block';
        document.getElementById(respostaSelecionada).value = letra;
    }
    if (document.getElementById(respostaLetraJust).value == 'True') {
        document.getElementById(botaoJustificativa).style.display = 'block';
        document.getElementById(botaoAnterior).style.display = 'none';
        document.getElementById(botaoProximo).style.display = 'none';
    } else {
        document.getElementById(botaoJustificativa).style.display = 'none';
        document.getElementById(botaoAnterior).style.display = 'block';
        document.getElementById(botaoProximo).style.display = 'block';
    }
    document.getElementById(lblResposta1A).style.backgroundColor = '#DBDFDD';
    document.getElementById(lblResposta1B).style.backgroundColor = '#DBDFDD';
    document.getElementById(lblResposta1C).style.backgroundColor = '#DBDFDD';
    document.getElementById(lblResposta1D).style.backgroundColor = '#DBDFDD';
    document.getElementById(lblResposta1).style.backgroundColor = '#89AFF5';
    document.getElementById(lblResposta2A).style.backgroundColor = '#E1EEEE';
    document.getElementById(lblResposta2B).style.backgroundColor = '#E1EEEE';
    document.getElementById(lblResposta2C).style.backgroundColor = '#E1EEEE';
    document.getElementById(lblResposta2D).style.backgroundColor = '#E1EEEE';
    document.getElementById(lblResposta2).style.backgroundColor = '#89AFF5';
    document.getElementById(respostaA).style.backgroundColor = '#E1EEEE';
    document.getElementById(respostaB).style.backgroundColor = '#E1EEEE';
    document.getElementById(respostaC).style.backgroundColor = '#E1EEEE';
    document.getElementById(respostaD).style.backgroundColor = '#E1EEEE';
    document.getElementById(respostaLetra).style.backgroundColor = '#89AFF5';
}

function selecionaRespostaEspecial(letra) {
    var lblResposta1 = "ContentPlaceHolder1_UCPerguntaEspecialGestao32_1_coluna1Resposta" + letra;
    var lblResposta1A = "ContentPlaceHolder1_UCPerguntaEspecialGestao32_1_coluna1RespostaA";
    var lblResposta1B = "ContentPlaceHolder1_UCPerguntaEspecialGestao32_1_coluna1RespostaB";
    var lblResposta1C = "ContentPlaceHolder1_UCPerguntaEspecialGestao32_1_coluna1RespostaC";
    var lblResposta1D = "ContentPlaceHolder1_UCPerguntaEspecialGestao32_1_coluna1RespostaD";
    var lblResposta2 = "ContentPlaceHolder1_UCPerguntaEspecialGestao32_1_coluna2Resposta" + letra;
    var lblResposta2A = "ContentPlaceHolder1_UCPerguntaEspecialGestao32_1_coluna2RespostaA";
    var lblResposta2B = "ContentPlaceHolder1_UCPerguntaEspecialGestao32_1_coluna2RespostaB";
    var lblResposta2C = "ContentPlaceHolder1_UCPerguntaEspecialGestao32_1_coluna2RespostaC";
    var lblResposta2D = "ContentPlaceHolder1_UCPerguntaEspecialGestao32_1_coluna2RespostaD";
    var respostaA = "ContentPlaceHolder1_UCPerguntaEspecialGestao32_1_respostaA";
    var respostaB = "ContentPlaceHolder1_UCPerguntaEspecialGestao32_1_respostaB";
    var respostaC = "ContentPlaceHolder1_UCPerguntaEspecialGestao32_1_respostaC";
    var respostaD = "ContentPlaceHolder1_UCPerguntaEspecialGestao32_1_respostaD";
    var respostaLetra = "ContentPlaceHolder1_UCPerguntaEspecialGestao32_1_resposta" + letra;
    var respostaSelecionada = "ContentPlaceHolder1_UCPerguntaEspecialGestao32_1_respostaSelecionada";
    var respostaLetraJust = "ContentPlaceHolder1_UCPerguntaEspecialGestao32_1_hdnResposta" + letra + "_Just";
    var botaoAnterior = "ContentPlaceHolder1_UCPerguntaEspecialGestao32_1_botaoAnterior";
    var botaoProximo = "ContentPlaceHolder1_UCPerguntaEspecialGestao32_1_botaoProximo";
    var txt1 = "ContentPlaceHolder1_UCPerguntaEspecialGestao32_1_tx1_31";
    var txt2 = "ContentPlaceHolder1_UCPerguntaEspecialGestao32_1_tx2_31";
    var txt3 = "ContentPlaceHolder1_UCPerguntaEspecialGestao32_1_tx3_31";
    if (document.getElementById(respostaA) == undefined) {
        lblResposta1 = "ctl00_ContentPlaceHolder1_UCPerguntaEspecialGestao32_1_coluna1Resposta" + letra;
        lblResposta1A = "ctl00_ContentPlaceHolder1_UCPerguntaEspecialGestao32_1_coluna1RespostaA";
        lblResposta1B = "ctl00_ContentPlaceHolder1_UCPerguntaEspecialGestao32_1_coluna1RespostaB";
        lblResposta1C = "ctl00_ContentPlaceHolder1_UCPerguntaEspecialGestao32_1_coluna1RespostaC";
        lblResposta1D = "ctl00_ContentPlaceHolder1_UCPerguntaEspecialGestao32_1_coluna1RespostaD";
        lblResposta2 = "ctl00_ContentPlaceHolder1_UCPerguntaEspecialGestao32_1_coluna2Resposta" + letra;
        lblResposta2A = "ctl00_ContentPlaceHolder1_UCPerguntaEspecialGestao32_1_coluna2RespostaA";
        lblResposta2B = "ctl00_ContentPlaceHolder1_UCPerguntaEspecialGestao32_1_coluna2RespostaB";
        lblResposta2C = "ctl00_ContentPlaceHolder1_UCPerguntaEspecialGestao32_1_coluna2RespostaC";
        lblResposta2D = "ctl00_ContentPlaceHolder1_UCPerguntaEspecialGestao32_1_coluna2RespostaD";
        respostaA = "ctl00_ContentPlaceHolder1_UCPerguntaEspecialGestao32_1_respostaA";
        respostaB = "ctl00_ContentPlaceHolder1_UCPerguntaEspecialGestao32_1_respostaB";
        respostaC = "ctl00_ContentPlaceHolder1_UCPerguntaEspecialGestao32_1_respostaC";
        respostaD = "ctl00_ContentPlaceHolder1_UCPerguntaEspecialGestao32_1_respostaD";
        respostaLetra = "ctl00_ContentPlaceHolder1_UCPerguntaEspecialGestao32_1_resposta" + letra;
        respostaSelecionada = "ctl00_ContentPlaceHolder1_UCPerguntaEspecialGestao32_1_respostaSelecionada";
        respostaLetraJust = "ctl00_ContentPlaceHolder1_UCPerguntaEspecialGestao32_1_hdnResposta" + letra + "_Just";
        botaoAnterior = "ctl00_ContentPlaceHolder1_UCPerguntaEspecialGestao32_1_botaoAnterior";
        botaoProximo = "ctl00_ContentPlaceHolder1_UCPerguntaEspecialGestao32_1_botaoProximo";
        txt1 = "ctl00_ContentPlaceHolder1_UCPerguntaEspecialGestao32_1_tx1_31";
        txt2 = "ctl00_ContentPlaceHolder1_UCPerguntaEspecialGestao32_1_tx2_31";
        txt3 = "ctl00_ContentPlaceHolder1_UCPerguntaEspecialGestao32_1_tx3_31";
    }
    if (navigator.appName == "Microsoft Internet Explorer") {
        document.getElementById(respostaA).childNodes[0].style.display = 'none';
        document.getElementById(respostaB).childNodes[0].style.display = 'none';
        document.getElementById(respostaC).childNodes[0].style.display = 'none';
        document.getElementById(respostaD).childNodes[0].style.display = 'none';
        document.getElementById(respostaLetra).childNodes[0].style.display = 'block';
        document.getElementById(respostaSelecionada).value = letra;
    } else {
        document.getElementById(respostaA).childNodes[1].style.display = 'none';
        document.getElementById(respostaB).childNodes[1].style.display = 'none';
        document.getElementById(respostaC).childNodes[1].style.display = 'none';
        document.getElementById(respostaD).childNodes[1].style.display = 'none';
        document.getElementById(respostaLetra).childNodes[1].style.display = 'block';
        document.getElementById(respostaSelecionada).value = letra;
    }
    if (document.getElementById(respostaLetraJust).value == 'True' && document.getElementById(txt1) != undefined) {
        document.getElementById(txt1).disabled = false;
        document.getElementById(txt1).style.backgroundColor = '#FFFFFF';
        document.getElementById(txt2).disabled = false;
        document.getElementById(txt2).style.backgroundColor = '#FFFFFF';
        document.getElementById(txt3).disabled = false;
        document.getElementById(txt3).style.backgroundColor = '#FFFFFF';
    } else if (document.getElementById(txt1) != undefined) {
        document.getElementById(txt1).disabled = true;
        document.getElementById(txt1).style.backgroundColor = '#E8E8E8';
        document.getElementById(txt2).disabled = true;
        document.getElementById(txt2).style.backgroundColor = '#E8E8E8';
        document.getElementById(txt3).disabled = true;
        document.getElementById(txt3).style.backgroundColor = '#E8E8E8';
    }
    document.getElementById(lblResposta1A).style.backgroundColor = '#DBDFDD';
    document.getElementById(lblResposta1B).style.backgroundColor = '#DBDFDD';
    document.getElementById(lblResposta1C).style.backgroundColor = '#DBDFDD';
    document.getElementById(lblResposta1D).style.backgroundColor = '#DBDFDD';
    document.getElementById(lblResposta1).style.backgroundColor = '#89AFF5';
    document.getElementById(lblResposta2A).style.backgroundColor = '#E1EEEE';
    document.getElementById(lblResposta2B).style.backgroundColor = '#E1EEEE';
    document.getElementById(lblResposta2C).style.backgroundColor = '#E1EEEE';
    document.getElementById(lblResposta2D).style.backgroundColor = '#E1EEEE';
    document.getElementById(lblResposta2).style.backgroundColor = '#89AFF5';
    document.getElementById(respostaA).style.backgroundColor = '#E1EEEE';
    document.getElementById(respostaB).style.backgroundColor = '#E1EEEE';
    document.getElementById(respostaC).style.backgroundColor = '#E1EEEE';
    document.getElementById(respostaD).style.backgroundColor = '#E1EEEE';
    document.getElementById(respostaLetra).style.backgroundColor = '#89AFF5';
}

function mostraResultadoTesteAutoavaliacao() {
    var selecao1 = "ContentPlaceHolder1_RdBttnLstPergunta1_0";
    var selecao2 = "ContentPlaceHolder1_RdBttnLstPergunta2_0";
    var selecao3 = "ContentPlaceHolder1_RdBttnLstPergunta3_0";
    var selecao4 = "ContentPlaceHolder1_RdBttnLstPergunta4_0";
    var selecao5 = "ContentPlaceHolder1_RdBttnLstPergunta1_1";
    var selecao6 = "ContentPlaceHolder1_RdBttnLstPergunta2_1";
    var selecao7 = "ContentPlaceHolder1_RdBttnLstPergunta3_1";
    var selecao8 = "ContentPlaceHolder1_RdBttnLstPergunta4_1";
    var tabelaResultados = "ContentPlaceHolder1_tabelaResposta";
    var tabelaColuna1 = "";
    var tabelaColuna2 = "";
    var linha1Coluna1 = "ContentPlaceHolder1_linha1Coluna1";
    var linha1Coluna2 = "ContentPlaceHolder1_linha1Coluna2";
    var linha2Coluna1 = "ContentPlaceHolder1_linha2Coluna1";
    var linha2Coluna2 = "ContentPlaceHolder1_linha2Coluna2";
    var linha3Coluna1 = "ContentPlaceHolder1_linha3Coluna1";
    var linha3Coluna2 = "ContentPlaceHolder1_linha3Coluna2";
    if (document.getElementById(selecao1) == undefined) {
        selecao1 = "ctl00_ContentPlaceHolder1_RdBttnLstPergunta1_0";
        selecao2 = "ctl00_ContentPlaceHolder1_RdBttnLstPergunta2_0";
        selecao3 = "ctl00_ContentPlaceHolder1_RdBttnLstPergunta3_0";
        selecao4 = "ctl00_ContentPlaceHolder1_RdBttnLstPergunta4_0";
        selecao5 = "ctl00_ContentPlaceHolder1_RdBttnLstPergunta1_1";
        selecao6 = "ctl00_ContentPlaceHolder1_RdBttnLstPergunta2_1";
        selecao7 = "ctl00_ContentPlaceHolder1_RdBttnLstPergunta3_1";
        selecao8 = "ctl00_ContentPlaceHolder1_RdBttnLstPergunta4_1";
        tabelaResultados = "ctl00_ContentPlaceHolder1_tabelaResposta";
        linha1Coluna1 = "ctl00_ContentPlaceHolder1_linha1Coluna1";
        linha1Coluna2 = "ctl00_ContentPlaceHolder1_linha1Coluna2";
        linha2Coluna1 = "ctl00_ContentPlaceHolder1_linha2Coluna1";
        linha2Coluna2 = "ctl00_ContentPlaceHolder1_linha2Coluna2";
        linha3Coluna1 = "ctl00_ContentPlaceHolder1_linha3Coluna1";
        linha3Coluna2 = "ctl00_ContentPlaceHolder1_linha3Coluna2";
    }
    if ((document.getElementById(selecao1).checked || document.getElementById(selecao5).checked) && (document.getElementById(selecao2).checked || document.getElementById(selecao6).checked) && (document.getElementById(selecao3).checked || document.getElementById(selecao7).checked) && (document.getElementById(selecao4).checked || document.getElementById(selecao8).checked)) {
        document.getElementById(tabelaResultados).style.display = 'block';
    } else {
        document.getElementById(tabelaResultados).style.display = 'none';
    }
    var numSim = 0;
    if (document.getElementById(selecao1).checked){
        numSim = numSim + 1;
    }
    if(document.getElementById(selecao2).checked){
        numSim = numSim + 1;
    }
    if(document.getElementById(selecao3).checked){
        numSim = numSim + 1;
    }
    if(document.getElementById(selecao4).checked && numSim < 3) {
        numSim = numSim + 1;
    }

    document.getElementById(linha1Coluna1).style.background = "#FFFFFF";
    document.getElementById(linha1Coluna2).style.background = "#FFFFFF";
    document.getElementById(linha2Coluna1).style.background = "#FFFFFF";
    document.getElementById(linha2Coluna2).style.background = "#FFFFFF";
    document.getElementById(linha3Coluna1).style.background = "#FFFFFF";
    document.getElementById(linha3Coluna2).style.background = "#FFFFFF";

    if (numSim == 1) {
        document.getElementById(linha1Coluna1).style.background = "#58ACFA";
        document.getElementById(linha1Coluna2).style.background = "#58ACFA";
    }
    else if (numSim == 2) {
        document.getElementById(linha2Coluna1).style.background = "#58ACFA";
        document.getElementById(linha2Coluna2).style.background = "#58ACFA";
    }
    else if (numSim >= 3) {
        document.getElementById(linha3Coluna1).style.background = "#58ACFA";
        document.getElementById(linha3Coluna2).style.background = "#58ACFA";
    }

    return false;
}
