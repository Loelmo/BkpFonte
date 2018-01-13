//  keeps track of the delete button for the row
//  that is going to be removed
var _source;
// keep track of the popup div
var _popup;

function showConfirm(source) {
    this._source = source;
    this._popup = $find('mdlPopup');

    //  find the confirm ModalPopup and show it    
    this._popup.show();
}

function okClick() {
    //  find the confirm ModalPopup and hide it    
    this._popup.hide();
    //  use the cached button as the postback source
    __doPostBack(this._source.name, '');
}

function cancelClick() {
    //  find the confirm ModalPopup and hide it 
    this._popup.hide();
    //  clear the event source
    this._source = null;
    this._popup = null;
}

function mensagem() {
    window.alert("Bem-vindo ao site: Macoratti.net.")
}

function Alert(msg) {
//    csscody.alert(msg);
    return false;
}

function Error(msg) {
//    csscody.error(msg);
    var campos = document.getElementsByTagName("select");

    for (i = 0; i < campos.length; i++) {
        campos[i].style.display = "block";
    }
    return false;
}

function Confirm(msg) {
//    csscody.confirm(msg);
    return false;
}

function Verifica_campo_CPF(campo) {
    var CPF = campo.value; // Recebe o valor digitado no campo
    CPF = CPF.replace('.', '').replace('.', '').replace('-', '')

    if (CPF == '11111111111' || CPF == '22222222222' || CPF == '33333333333' || CPF == '44444444444' || CPF == '55555555555' || CPF == '66666666666' || CPF == '77777777777' || CPF == '88888888888' || CPF == '99999999999' || CPF == '00000000000') {
        alert('CPF inválido');
        campo.value = '';
        //campo.focus();
        return false;
    }

    if (CPF.length > 0) {
        // Aqui começa a checagem do CPF
        var POSICAO, I, SOMA, DV, DV_INFORMADO;
        var DIGITO = new Array(10);
        DV_INFORMADO = CPF.substr(9, 2); // Retira os dois últimos dígitos do número informado

        // Desemembra o número do CPF na array DIGITO
        for (I = 0; I <= 8; I++) {
            DIGITO[I] = CPF.substr(I, 1);
        }

        // Calcula o valor do 10º dígito da verificação
        POSICAO = 10;
        SOMA = 0;
        for (I = 0; I <= 8; I++) {
            SOMA = SOMA + DIGITO[I] * POSICAO;
            POSICAO = POSICAO - 1;
        }
        DIGITO[9] = SOMA % 11;
        if (DIGITO[9] < 2) {
            DIGITO[9] = 0;
        }
        else {
            DIGITO[9] = 11 - DIGITO[9];
        }

        // Calcula o valor do 11º dígito da verificação
        POSICAO = 11;
        SOMA = 0;
        for (I = 0; I <= 9; I++) {
            SOMA = SOMA + DIGITO[I] * POSICAO;
            POSICAO = POSICAO - 1;
        }
        DIGITO[10] = SOMA % 11;
        if (DIGITO[10] < 2) {
            DIGITO[10] = 0;
        }
        else {
            DIGITO[10] = 11 - DIGITO[10];
        }

        // Verifica se os valores dos dígitos verificadores conferem
        DV = DIGITO[9] * 10 + DIGITO[10];
        if (DV != DV_INFORMADO) {
            alert('CPF inválido');
            campo.value = '';
            //campo.focus();
            return false;
        }
    }

}

function Verifica_campo_CNPJ(c) {

    var numeros, digitos, soma, i, resultado, pos, tamanho, digitos_iguais, cnpj = c.value.replace(/\D+/g, '');
    if (cnpj.length > 0) {
        digitos_iguais = 1;
        if (cnpj.length != 14) {
            alert('CNPJ inválido');
            c.value = '';
            //c.focus();
            return false;
        }

        for (i = 0; i < cnpj.length - 1; i++)
            if (cnpj.charAt(i) != cnpj.charAt(i + 1)) {
                digitos_iguais = 0;
                break;
            }
        if (!digitos_iguais) {
            tamanho = cnpj.length - 2
            numeros = cnpj.substring(0, tamanho);
            digitos = cnpj.substring(tamanho);
            soma = 0;
            pos = tamanho - 7;
            for (i = tamanho; i >= 1; i--) {
                soma += numeros.charAt(tamanho - i) * pos--;
                if (pos < 2)
                    pos = 9;
            }
            resultado = soma % 11 < 2 ? 0 : 11 - soma % 11;
            if (resultado != digitos.charAt(0)) {
                alert('CNPJ inválido');
                c.value = '';
                //c.focus();
                return false;
            }

            tamanho = tamanho + 1;
            numeros = cnpj.substring(0, tamanho);
            soma = 0;
            pos = tamanho - 7;
            for (i = tamanho; i >= 1; i--) {
                soma += numeros.charAt(tamanho - i) * pos--;
                if (pos < 2)
                    pos = 9;
            }
            resultado = soma % 11 < 2 ? 0 : 11 - soma % 11;
            if (resultado != digitos.charAt(1)) {
                alert('CNPJ inválido');
                c.value = '';
                //c.focus();
                return false;
            }
            else {
                // alert('CNPJ  OK !');
                return true;
            }
        }
        else {
            alert('CNPJ inválido');
            c.value = '';
            //c.focus();
            return false;
        }
    }
}



function Verifica_campo_CPF_CNPJ(campo) {
    var c = campo.value.replace(/\D+/g, '');
    if (c.length > 0) {
        if (c.length != 11 && c.length != 14) {
            alert('Campo Incompleto');
        }
        else
            if (c.length == 11) {
                Verifica_campo_CPF(campo);
            }
            else {
                Verifica_campo_CNPJ(campo);
            }
    }
}

function Verifica_Telefone(campo) {
    var c = campo.value.replace(/\D+/g, '');
    if (c.length != 10 && c.length != 0) {
        campo.value = '';
        alert('Telefone Inválido');
    }
}

function Verifica_CEP(campo) {
    var c = campo.value.replace(/\D+/g, '');
    if (c.length != 8 && c.length != 0) {
        campo.value = '';
        alert('CEP Inválido!');
    }
}

function ValidaEmail(campo) {
    var txt = campo.value;
    if ((txt.length != 0) && ((txt.indexOf("@") < 1) )) {
        alert('E-mail incorreto');
        campo.focus();
    }
}

function fechaAlerta() {
    var alerta = "ContentPlaceHolder1_divJustificativa";
    if (document.getElementById(alerta) == undefined) {
        alerta = "ctl00_ContentPlaceHolder1_divJustificativa";
    }
    document.getElementById(alerta).style.display = "none";
    return false;
}

function getBaseURL() {
    var url = location.href;  // entire url including querystring - also: window.location.href;
    var baseURL = url.substring(0, url.indexOf('/', 14));


    if (baseURL.indexOf('http://localhost') != -1) {
        // Base Url for localhost
        var url = location.href;  // window.location.href;
        var pathname = location.pathname;  // window.location.pathname;
        var index1 = url.indexOf(pathname);
        var index2 = url.indexOf("/", index1 + 1);
        var baseLocalUrl = url.substr(0, index2);

        return baseLocalUrl + "/";
    }
    else {
        // Root Url for domain name
        return baseURL + "/";
    }
}

function dosub() {
    editor = top.document.getElementById(editorId);
    editor.value = richeditor.toHtmlString();
}
