using System;
using System.Text.RegularExpressions;

namespace FavoriteExtensionMethods
{
    public static class FormatMethods
    {
        public const int NUM_DIGITOS_CNPJ = 14;
        public const int NUM_DIGITOS_CPF = 11;

        public static string FormataCEP(string strValor, bool pUseSepar)
        {
            string recep = null;

            if (((strValor != null) && strValor.Length > 0))
            {
                strValor = strValor.PadLeft(8, '0');
                if ((pUseSepar))
                {
                    recep = "(\\d{5})(\\d{3})$";
                    strValor = Regex.Replace(strValor, recep, "$1-$2");
                }
            }
            return strValor;
        }

        public static string FormataCPF(string pCpf, bool pUseSepar)
        {
            if (String.IsNullOrEmpty(pCpf))
            {
                return String.Empty;
            }

            string reCpf = null;

            if (((pCpf != null) && pCpf.Length > 0))
            {
                pCpf = pCpf.PadLeft(NUM_DIGITOS_CPF, '0');

                if ((pUseSepar))
                {
                    reCpf = "(\\d{3})(\\d{3})(\\d{3})(\\d{2})$";
                    pCpf = Regex.Replace(pCpf, reCpf, "$1.$2.$3-$4");
                }
            }

            return pCpf;
        }

        public static string FormatarPIS(string pis)
        {
            if (String.IsNullOrEmpty(pis))
            {
                return String.Empty;
            }

            string rePis = null;

            if (((pis != null) && pis.Length > 0))
            {
                pis = pis.PadLeft(NUM_DIGITOS_CPF, '0');

                rePis = "(\\d{3})(\\d{5})(\\d{2})(\\d{1})$";
                pis = Regex.Replace(pis, rePis, "$1.$2.$3-$4");
            }

            return pis;
        }

        public static string FormataCNPJ(string pCnpj, bool pUseSepar)
        {
            string reCnpj = null;

            if (((pCnpj != null) && pCnpj.Length > 0))
            {
                pCnpj = pCnpj.PadLeft(NUM_DIGITOS_CNPJ, '0');
                if ((pUseSepar))
                {
                    reCnpj = "(\\d{2})(\\d{3})(\\d{3})(\\d{4})(\\d{2})$";
                    pCnpj = Regex.Replace(pCnpj, reCnpj, "$1.$2.$3/$4-$5");
                }
            }
            return pCnpj;
        }

        public static string LimpaCpfCnpj(string _cpfcnpj)
        {
            if (string.IsNullOrEmpty(_cpfcnpj))
            {
                return string.Empty;
            }

            return _cpfcnpj.Replace(".", "").Replace("/", "").Replace("-", "");
        }

        public static string FormataTelefone(string strValor, bool pUseSepar, bool comDDD = true)
        {
            string retelefone = null;

            var exp11 = comDDD ? "(\\d{2})(\\d{5})(\\d{4})" : "(\\d{5})(\\d{4})";
            var exp = comDDD ? "(\\d{2})(\\d{4})(\\d{4})" : "(\\d{4})(\\d{4})";

            if (((strValor != null) && strValor.Length > 0))
            {
                if ((pUseSepar))
                {
                    if (strValor.Length == 11)
                    {
                        retelefone = exp11;
                    }
                    else
                    {
                        strValor = comDDD ? strValor.PadLeft(10, '0') : strValor.PadLeft(8, '0');
                        retelefone = exp;
                    }

                    strValor = Regex.Replace(strValor, retelefone, comDDD ? "($1) $2-$3" : "$1-$2");
                }
            }
            return strValor;
        }
    }
}
