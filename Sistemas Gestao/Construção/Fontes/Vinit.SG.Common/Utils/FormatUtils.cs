using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vinit.SG.Common
{
    public class FormatUtils
    {

        public static String FormatCPF(String AValue)
        {
            String CPF = StringUtils.OnlyNumbers(AValue);

            if (CPF.Length == 11)
            {
                return CPF.Substring(0, 3) + "." + CPF.Substring(3, 3) + "." + CPF.Substring(6, 3) + "-" + CPF.Substring(9, 2);
            }
            else
            {
                return AValue;
            }
        }

        public static String FormatCNPJ(String AValue)
        {
            String CNPJ = StringUtils.OnlyNumbers(AValue);

            if (CNPJ.Length == 14)
            {
                return CNPJ.Substring(0, 2) + "." + CNPJ.Substring(2, 3) + "." + CNPJ.Substring(5, 3) + "/" + CNPJ.Substring(8, 4) + "-" + CNPJ.Substring(12, 2);
            }
            else
            {
                return AValue;
            }
        }

        public static String FormataCNPJ_CPF(String AValue)
        {
            String CNPJ_CPF = StringUtils.OnlyNumbers(AValue);

            if (CNPJ_CPF.Length == 11)
            {
                return FormatCPF(CNPJ_CPF);
            }
            else
                if (CNPJ_CPF.Length == 14)
                {
                    return FormatCNPJ(CNPJ_CPF);
                }
                else
                {
                    return AValue;
                }


        }

        public static String FormatTelefone(String AValue)
        {
            String telefone = StringUtils.OnlyNumbers(AValue);

            if (telefone.Length == 10)
            {
                return "(" + telefone.Substring(0, 2) + ") " + telefone.Substring(2, 4) + "-" + telefone.Substring(6, 4);
            }
            else
            {
                return telefone;
            }
        }

        public static String FormatCEP(String AValue)
        {
            String CEP = StringUtils.OnlyNumbers(AValue);

            if (CEP.Length == 8)
            {
                return CEP.Substring(0, 5) + "-" + CEP.Substring(5, 3);
            }
            else
            {
                return AValue;
            }
        }

        public static String FormatBoolean(Boolean AValue)
        {
            if (AValue)
                return "Sim";
            else
                return "Não";
        }

        public static String FormatPontuacaoRanking(double AValue)
        {
            System.Globalization.CultureInfo ptBR = new System.Globalization.CultureInfo("pt-BR");

            return AValue.ToString("N2", ptBR) + "%";
        }

        public static String FormatLetraQuestao(Int32 AValue)
        {
            switch (AValue)
            {
                case 1:
                    return "A";
                case 2:
                    return "B";
                case 3:
                    return "C";
                case 4:
                    return "D";
            }
            return "";
        }

        public static String FormatCell(Boolean AValue)
        {
            if (AValue == null || !AValue)
            {
                return "#FC8879";
            }
            else
            {
                return "#79FC7D";
            }
        }
    }
}
