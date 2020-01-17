using System.Linq;
using System.Text.RegularExpressions;

namespace FavoriteExtensionMethods
{
    public static class ValidationsMethods
    {
        public static bool IsCPF(string cpf)
        {
            if (cpf.Distinct().Count() == 1)
            {
                return false;
            }

            cpf = cpf.PadLeft(11, '0');

            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            int soma = 0;

            string tempCpf = cpf.Substring(0, 9);

            bool cpfIgual = true;
            for (int i = 0; i < 10; i++)
            {
                cpfIgual = (cpfIgual && (cpf[i] == cpf[i + 1]));
            }

            if (cpfIgual)
                return false;

            for (int i = 0; i < 9; i++)
            {
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
            }

            int resto = soma % 11;

            if (resto < 2)
            {
                resto = 0;
            }
            else
            {
                resto = 11 - resto;
            }

            string digito = resto.ToString();

            tempCpf = tempCpf + digito;

            soma = 0;

            for (int i = 0; i < 10; i++)
            {
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
            }

            resto = soma % 11;

            if (resto < 2)
            {
                resto = 0;
            }
            else
            {
                resto = 11 - resto;
            }

            digito = digito + resto.ToString();

            return cpf.EndsWith(digito);
        }

        public static bool IsCNPJ(string cnpj)
        {
            if (!Regex.IsMatch(cnpj, @"^\d{2,3}.?\d{3}.?\d{3}/?\d{4}-?\d{2}$"))
            {
                return false;
            }

            cnpj = cnpj.Replace("-", "").Replace(".", "").Replace("/", "");

            if (cnpj.Length != 14)
            {
                return false;
            }

            int[] multiplicador1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

            int[] multiplicador2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

            string tempCnpj = cnpj.Substring(0, 12);

            int soma = 0;

            for (int i = 0; i < 12; i++)
            {
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador1[i];
            }

            int resto = (soma % 11);

            if (resto < 2)
            {
                resto = 0;
            }
            else
            {
                resto = 11 - resto;
            }

            string digito = resto.ToString();

            tempCnpj = tempCnpj + digito;

            soma = 0;

            for (int i = 0; i < 13; i++)
            {
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador2[i];
            }

            resto = (soma % 11);

            if (resto < 2)
            {
                resto = 0;
            }
            else
            {
                resto = 11 - resto;
            }

            digito = digito + resto.ToString();

            return cnpj.EndsWith(digito);
        }

        public static bool IsMail(string email)
        {
            return Regex.IsMatch(email, @"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$");
        }

        public static bool IsUrl(string url)
        {
            //return Regex.IsMatch(url, @"^((http(s)?)|(ftp)){1}://([\w-]+\.)+[\w-]+(/[\w- ./?@%&=]*)?");
            return Regex.IsMatch(url, @"^(^|[ \t\r\n])((ftp|http|https|gopher|mailto|news|nntp|telnet|wais|file|prospero|aim|webcal):(([A-Za-z0-9$_.+!*(),;/?:@&~=-])|%[A-Fa-f0-9]{2}){2,}(#([a-zA-Z0-9][a-zA-Z0-9$_.+!*(),;/?:@&~=%-]*))?([A-Za-z0-9$_+!*();/?:~-]))?");
        }
    }
}
