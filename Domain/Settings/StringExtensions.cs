using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public static class StringExtensions
    {
        public static string After(this string @string, string after)
        {
            var search = @string.IndexOf(after, StringComparison.Ordinal);

            if (search < 0)
            {
                return string.Empty;
            }

            var startIndex = search + after.Length;
            var length = @string.Length - startIndex;

            if (length <= 0)
            {
                return string.Empty;
            }

            return @string.Substring(startIndex, length);
        }

        public static string Before(this string @string, string before)
        {
            var length = @string.IndexOf(before, StringComparison.Ordinal);

            if (length <= 0)
            {
                return string.Empty;
            }

            return @string.Substring(0, length);
        }

        public static string BeforeLast(this string @string, string before)
        {
            var length = @string.LastIndexOf(before, StringComparison.Ordinal);

            if (length <= 0)
            {
                return string.Empty;
            }

            return @string.Substring(0, length);
        }

        public static string EnsureEndsWith(this string str, char c, StringComparison comparisonType)
        {
            if (str == null)
            {
                throw new ArgumentNullException(nameof(str));
            }

            if (str.EndsWith(c.ToString(), comparisonType))
            {
                return str;
            }

            return str + c;
        }

        public static string EnsureNotStartsWith(this string str, char c)
        {
            return EnsureNotStartsWith(str, c, StringComparison.Ordinal);
        }

        private static string EnsureNotStartsWith(string str, char c, StringComparison comparisonType)
        {
            if (str == null)
            {
                throw new ArgumentNullException(nameof(str));
            }

            if (str.StartsWith(c.ToString(), comparisonType))
            {
                return str.Substring(1);
            }

            return str;
        }

        public static string EnsureEndsWith(this string str, char c)
        {
            return EnsureEndsWith(str, c, StringComparison.Ordinal);
        }

        public static string RemovePostFix(this string s, string suffix)
        {
            if (s.EndsWith(suffix))
            {
                return s.Substring(0, s.Length - suffix.Length);
            }
            else
            {
                return s;
            }
        }

        public static string RemoverAcentos(this string texto)
        {
            string comAcentos = "ÄÅÁÂÀÃäáâàãÉÊËÈéêëèÍÎÏÌíîïìÖÓÔÒÕöóôòõÜÚÛüúûùÇç";
            string semAcentos = "AAAAAAaaaaaEEEEeeeeIIIIiiiiOOOOOoooooUUUuuuuCc";

            for (int i = 0; i < comAcentos.Length; i++)
            {
                texto = texto.Replace(comAcentos[i].ToString(), semAcentos[i].ToString());
            }
            return texto;
        }

        public static bool ComecaComNumero(this string str)
        {
            if (string.IsNullOrEmpty(str))
                return false;
            return char.IsNumber(Convert.ToChar(str.Substring(0, 1)));
        }

        public static string TiraAcentuacao(this string s)
        {
            if (string.IsNullOrEmpty(s.Trim()))
                return string.Empty;
            else
            {
                byte[] array = Encoding.GetEncoding("iso-8859-8").GetBytes(s);
                return Encoding.UTF8.GetString(array);
            }
        }

        public static bool SomenteNumero(this string s)
        {
            var retorno = s.Replace(" ", "");
            foreach (var item in retorno)
            {
                if (!char.IsNumber(item))
                    return false;
            }
            return true;
        }
    }
}
