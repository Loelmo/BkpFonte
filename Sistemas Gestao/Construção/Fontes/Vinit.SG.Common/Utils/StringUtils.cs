using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using System.Security.Cryptography;

namespace Vinit.SG.Common
{
    public class StringUtils
    {

        /// <summary>
        /// Remove caracteres acentuados e cedilha.
        /// </summary>
        /// <param name="texto">Texto com acento.</param>
        /// <returns>Texto sem acento.</returns>
        public static string RemoverAcento(string texto)
        {
            string comAcentos = "ÄÅÁÂÀÃäáâàãåÉÊËÈéêëèÍÎÏÌíîïìÖÓÔÒÕöóôòõÜÚÛÙüúûùÇçñÑÿýÝ";

            string semAcentos = "AAAAAAaaaaaaEEEEeeeeIIIIiiiiOOOOOoooooUUUUuuuuCcnNyyY";

            for (int i = 0; i < comAcentos.Length; i++)
            {
                texto = texto.Replace(comAcentos[i].ToString(), semAcentos[i].ToString());
            }

            return texto;
        }

        /// <summary>
        /// Cryptografar.
        /// </summary>
        /// <param name="texto">Texto a ser cryptografado.</param>
        public static System.String EncryptPassword(System.String aValue)
        {

            // Primeiro passo, calcular o MD5 hash a partir da string
            MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(aValue);
            byte[] hash = md5.ComputeHash(inputBytes);

            // Segundo passo, converter o array de bytes em uma string haxadecimal
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString();
        }

        /// <summary>
        /// Converte string para inteiro, se a conversão falhar retorna o valor default.
        /// </summary>
        /// <param name="valor">String a ser convertida.</param>
        /// <param name="def">Valor default.</param>
        /// <returns>Retorna o valor convertido para inteiro.</returns>
        public static int StrToIntDef(string valor, int def)
        {
            int valorInt;
            if (int.TryParse(valor, out valorInt))
            {
                return valorInt;
            }

            return def;
        }

        public static System.String ExtractChar(System.String AValue, System.String AGroup)
        {
            System.String sTemp;
            System.Int32 nTemp;
            System.Int32 nCount = 0;
            sTemp = System.String.Empty;

            if (AValue != null)
            {
                nCount = AValue.Length;
            }

            for (nTemp = 0; nTemp < nCount; nTemp++)
            {
                if (AGroup.IndexOf(AValue[nTemp]) >= 0)
                {
                    sTemp = sTemp + AValue[nTemp];
                }
            }
            return sTemp;

        }

        public static System.String OnlyNumbers(System.String AValue)
        {
            return ExtractChar(AValue, "0123456789");
        }

        public static System.String OnlyNumbersNeg(System.String AValue)
        {
            return ExtractChar(AValue, "-0123456789");
        }

        public static System.String OnlyNumbersDouble(System.String AValue)
        {
            return ExtractChar(AValue, "0123456789.,");
        }

        public static System.String FormatTime(System.String AValue)
        {
            return String.Format("{0:00:00}", Convert.ToInt32(AValue));
        }

        public static System.Boolean IsEmpty(System.String AValue)
        {
            return System.String.IsNullOrEmpty(AValue);
        }

        public static String NewGuidKey()
        {
            return DateTime.Now.Ticks.ToString();
        }

        public static System.Int32 ToInt(System.String AValue)
        {
            System.String aString = OnlyNumbers(AValue);
            if (IsEmpty(aString))
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(aString);
            }
        }

        public static System.Int32 ToIntNeg(System.String AValue)
        {
            System.String aString = OnlyNumbersNeg(AValue);
            if (IsEmpty(aString))
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(aString);
            }
        }

        public static System.Int64 ToInt64(System.String AValue)
        {
            System.String sString = StringUtils.OnlyNumbers(AValue);

            if (StringUtils.IsEmpty(sString))
            {
                return 0;
            }
            else
            {
                return Convert.ToInt64(sString);
            }
        }

        public static System.Object ToObject(System.String AValue)
        {
            if (IsEmpty(AValue))
            {
                return DBNull.Value;
            }
            else
            {
                return AValue;
            }
        }

        public static System.DateTime ToDate(System.String AValue)
        {
            CultureInfo provider = CultureInfo.InvariantCulture;
            if (!(AValue == System.String.Empty) && (DateUtils.IsValid(AValue)))
            {
                return DateTime.ParseExact(AValue, "dd/MM/yyyy", provider);
            }
            else
            {
                return DateTime.ParseExact("01/01/1954", "dd/MM/yyyy", provider);
            }
        }

        public static System.DateTime ToDateFim(System.String AValue)
        {
            CultureInfo provider = CultureInfo.InvariantCulture;
            if (!(AValue == System.String.Empty) && (DateUtils.IsValid(AValue)))
            {
                DateTime temp = DateTime.ParseExact(AValue, "dd/MM/yyyy", provider);
                temp = temp.AddHours(23);
                temp = temp.AddMinutes(59);
                temp = temp.AddSeconds(59);
                return temp;
            }
            else
            {
                return System.DateTime.Now;
            }
        }

        public static System.Double ToDouble(System.String AValue)
        {
            AValue = AValue.Replace(".", "");
            System.Double NewValue;
            if (! DoubleUtils.IsValid(AValue, out NewValue))
            {
                return 0;
            }
            else
            {
                return NewValue;
            }
        }

        public static System.String Complete(System.String AValue, System.Int32 iMaxLength, System.Char cChar, System.Boolean bLeft)
        {
            System.String sAux = "";

            for (System.Int32 iTemp = 1; iTemp < (iMaxLength - (AValue.Length - 1)); iTemp++)
            {
                sAux = sAux + cChar;
            }

            if (bLeft)
            {
                return sAux + AValue;
            }
            else
            {
                return AValue + sAux;
            }
        }

        public static System.Boolean ToBoolean(System.String AValue)
        {
            Boolean res = false;
            if (AValue == "1" || AValue == "True")
            {
                res = true;
            }
            return res;
        }

        public static System.DateTime ToTime(System.String AValue)
        {
            System.DateTime dateValid;

            if (!(StringUtils.IsEmpty(AValue)) && DateUtils.IsValidTime(AValue))
            {
                System.DateTime.TryParseExact(AValue, "HH:mm:ss", new CultureInfo("pt-BR"), DateTimeStyles.None, out dateValid);
                return System.DateTime.MinValue.AddHours(dateValid.TimeOfDay.TotalHours);
            }
            else
            {
                return System.DateTime.MinValue;
            }
        }

        public static Tipo ToEnum<Tipo>(String Value)
        {
            return (Tipo)Enum.Parse(typeof(Tipo), Value);
        }


    //    public static Tipo<T> ToEnum (T tipoEnum, String value)
    //{
    //    return <T>Value;
    //}

        public static System.String Concatenar(Enum Tabela, Enum Acao)
        {
            return Tabela + " " + Acao;
        }

        public static String trataCpfCnpj(String cpfCnpj)
        {
            String res = "";
            if (cpfCnpj.Length == 11)
            {
                res = cpfCnpj.Substring(0, 3) + "." + cpfCnpj.Substring(3, 3) + "." + cpfCnpj.Substring(6, 3) + "-" + cpfCnpj.Substring(9, 2);
            }
            else if (cpfCnpj.Length == 14)
            {
                res = cpfCnpj.Substring(0, 2) + "." + cpfCnpj.Substring(2, 3) + "." + cpfCnpj.Substring(5, 3) + "/" + cpfCnpj.Substring(8, 4) + "-" + cpfCnpj.Substring(12, 2);
            }

            return res;
        }

        public static String removePontuacaoCpfCnpj(String cpfCnpj)
        {
            cpfCnpj = cpfCnpj.Replace(".", "");
            cpfCnpj = cpfCnpj.Replace("-", "");
            cpfCnpj = cpfCnpj.Replace("/", "");

            return cpfCnpj;
        }

        public static Boolean ValidaCPF(String vrCPF)
        {
            String valor = vrCPF.Replace(".", "");
            valor = valor.Replace("-", "");

            if (valor.Length != 11)
                return false;

            if (valor == "11111111111" || valor == "22222222222" || valor == "33333333333" || valor == "44444444444" || valor == "55555555555" || valor == "66666666666" || valor == "77777777777" || valor == "88888888888" || valor == "99999999999" || valor == "00000000000") {
                return false;
            }
            Boolean igual = true;

            for (int i = 1; i < 11 && igual; i++)
                if (valor[i] != valor[0])
                    igual = false;

            if (igual || valor == "12345678909")
                return false;

            int[] numeros = new int[11];

            for (int i = 0; i < 11; i++)
                numeros[i] = int.Parse(valor[i].ToString());

            int soma = 0;

            for (int i = 0; i < 9; i++)
                soma += (10 - i) * numeros[i];

            int resultado = soma % 11;

            if (resultado == 1 || resultado == 0)
            {
                if (numeros[9] != 0)
                    return false;
            }
            else if (numeros[9] != 11 - resultado)
                return false;

            soma = 0;

            for (int i = 0; i < 10; i++)
                soma += (11 - i) * numeros[i];

            resultado = soma % 11;

            if (resultado == 1 || resultado == 0)
            {
                if (numeros[10] != 0)
                    return false;
            }
            else
                if (numeros[10] != 11 - resultado)
                    return false;

            return true;
        }

        public static Boolean ValidaCNPJ(String vrCNPJ)
        {

            String CNPJ = vrCNPJ.Replace(".", "");
            CNPJ = CNPJ.Replace("/", "");
            CNPJ = CNPJ.Replace("-", "");
            int[] digitos, soma, resultado;
            int nrDig;
            String ftmt;
            Boolean[] CNPJOk;
            ftmt = "6543298765432";
            digitos = new int[14];
            soma = new int[2];
            soma[0] = 0;
            soma[1] = 0;
            resultado = new int[2];
            resultado[0] = 0;
            resultado[1] = 0;
            CNPJOk = new Boolean[2];
            CNPJOk[0] = false;
            CNPJOk[1] = false;

            try
            {
                for (nrDig = 0; nrDig < 14; nrDig++)
                {
                    digitos[nrDig] = int.Parse(
                        CNPJ.Substring(nrDig, 1));

                    if (nrDig <= 11)
                        soma[0] += (digitos[nrDig] * int.Parse(ftmt.Substring(nrDig + 1, 1)));

                    if (nrDig <= 12)
                        soma[1] += (digitos[nrDig] * int.Parse(ftmt.Substring(nrDig, 1)));
                }

                for (nrDig = 0; nrDig < 2; nrDig++)
                {
                    resultado[nrDig] = (soma[nrDig] % 11);

                    if ((resultado[nrDig] == 0) || (resultado[nrDig] == 1))
                        CNPJOk[nrDig] = (digitos[12 + nrDig] == 0);
                    else
                        CNPJOk[nrDig] = (digitos[12 + nrDig] == (11 - resultado[nrDig]));
                }
                return (CNPJOk[0] && CNPJOk[1]);
            }
            catch
            {
                return false;
            }
        }


        public static String Random(Int32 iTamanho)
        {
            StringBuilder builder = new StringBuilder();
            Random random = new Random();
            char ch;
            for (int i = 0; i < iTamanho; i++)
            {
                if ((i % 2) == 0)
                {
                    ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                }
                else
                {
                    ch = Convert.ToChar(random.Next(48,57));
                }

                builder.Append(ch);
            }

            return builder.ToString();
        }

        public static String TrataNoticiaTipoUsuario(Boolean boolTipoUsuario)
        {
            String res = "";
            if (boolTipoUsuario)
            {
                res = "Usuários Administrativos";
            }
            else
            {
                res = "Empresas";
            }
            return res;
        }

        public static String TrataCorpoNoticiaPrincipal(String noticia)
        {
            String res = "";
            while (res.Length < 300)
            {
                String temp = noticia.Substring(0, noticia.IndexOf(" ") + 1);
                noticia = noticia.Substring(noticia.IndexOf(" ") + 1);
                res = res + temp;
            }
            return res;
        }

    }
}
