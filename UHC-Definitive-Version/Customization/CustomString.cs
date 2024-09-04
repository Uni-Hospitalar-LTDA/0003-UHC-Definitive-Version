using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace UHC3_Definitive_Version.Customization
{
    public static class CustomString
    {
        public static string substituirCaracteresEspeciais(this string palavra)
        {
            string novaPalavra = palavra;

            // Substituir letras com diacríticos
            novaPalavra = novaPalavra.Replace("á", "a");
            novaPalavra = novaPalavra.Replace("à", "a");
            novaPalavra = novaPalavra.Replace("â", "a");
            novaPalavra = novaPalavra.Replace("ã", "a");
            novaPalavra = novaPalavra.Replace("ç", "c");
            novaPalavra = novaPalavra.Replace("é", "e");
            novaPalavra = novaPalavra.Replace("ê", "e");
            novaPalavra = novaPalavra.Replace("í", "i");
            novaPalavra = novaPalavra.Replace("ó", "o");
            novaPalavra = novaPalavra.Replace("ô", "o");
            novaPalavra = novaPalavra.Replace("õ", "o");
            novaPalavra = novaPalavra.Replace("ú", "u");
            novaPalavra = novaPalavra.Replace("ü", "u");

            // Substituir pontuação
            novaPalavra = novaPalavra.Replace(".", "");
            novaPalavra = novaPalavra.Replace(",", "");
            novaPalavra = novaPalavra.Replace(";", "");
            novaPalavra = novaPalavra.Replace(":", "");
            novaPalavra = novaPalavra.Replace("-", "");
            novaPalavra = novaPalavra.Replace("_", "");
            novaPalavra = novaPalavra.Replace("(", "");
            novaPalavra = novaPalavra.Replace(")", "");
            novaPalavra = novaPalavra.Replace("[", "");
            novaPalavra = novaPalavra.Replace("]", "");
            novaPalavra = novaPalavra.Replace("{", "");
            novaPalavra = novaPalavra.Replace("}", "");
            novaPalavra = novaPalavra.Replace("?", "");
            novaPalavra = novaPalavra.Replace("!", "");
            novaPalavra = novaPalavra.Replace("\"", "");
            novaPalavra = novaPalavra.Replace("'", "");
            novaPalavra = novaPalavra.Replace("`", "");
            novaPalavra = novaPalavra.Replace("´", "");

            return novaPalavra;
        }

        public static string applyDocumentMask(this string document)
        {
            // Remove qualquer caractere não numérico
            string digitsOnly = Regex.Replace(document, @"\D", "");

            if (digitsOnly.Length == 11)
            {
                return ApplyCpfMask(digitsOnly);
            }
            else if (digitsOnly.Length == 14)
            {
                return ApplyCnpjMask(digitsOnly);
            }
            else
            {
                return document; // Retorna a string original se não for nem CPF nem CNPJ
            }
        }
        private static string ApplyCpfMask(string cpf)
        {
            return Regex.Replace(cpf, @"(\d{3})(\d{3})(\d{3})(\d{2})", "$1.$2.$3-$4");
        }

        private static string ApplyCnpjMask(string cnpj)
        {
            return Regex.Replace(cnpj, @"(\d{2})(\d{3})(\d{3})(\d{4})(\d{2})", "$1.$2.$3/$4-$5");
        }
    }
}
