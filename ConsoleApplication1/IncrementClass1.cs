using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class IncrementClass1
    {
        public static string Inc(string inputValue)
        {
            CheckStringIsNotNull(inputValue);
            bool? sign = CheckFirstSign(inputValue);
            string inputString = "";
            if (sign == null)
            {
                inputString = ReplaceZeroes(inputValue);
            }
            else
            {
                inputString = ReplaceZeroes(inputValue.Substring(1));
            }
            inputString = CropNonDeecimalPart(inputString);

            StringBuilder sb = new StringBuilder();

            bool needAdd = false;
            bool stopLoop = false;
            char newChar;
            int i,j = 0;
            for (i = inputString.Length - 1; i >= 0; i--)
            {
                CheckCharIsValid(inputString[i]);
                if (!stopLoop)
                {
                    if (sign==null || (bool)sign)
                    {
                        newChar = IncrementChar(inputString[i], ref needAdd);
                    }
                    else
                    {
                        newChar = DecrementChar(inputString[i], ref needAdd);
                    }

                    sb.Append(newChar);
                    if (!needAdd)
                    {
                        stopLoop=true;
                        j = i;
                    }
                }
            }
            if (needAdd)
            {
                if (sign == null || (bool)sign)
                {
                    return '1' + Reverse(sb);
                }
                else
                {
                    return '-'+ReplaceZeroes(Reverse(sb));
                }
            }
            else
            {
                if (sign == null || (bool)sign)
                { return Replace(inputString, j, Reverse(sb)); }
                else
                {
                    return '-'+ReplaceZeroes(Replace(inputString, j, Reverse(sb)));
                }
            }
        }

        private static string CropNonDeecimalPart(string inputString)
        {
            int index = inputString.IndexOfAny(new char[] { ',', '.' });
            if (index != -1)
            { return inputString.Substring(0, inputString.IndexOfAny(new char[] { ',', '.' })); }
            return inputString;
        }

        private static string ReplaceZeroes(string str)
        {
            int i = 0;
            for(i = 0; i <str.Length; i++)
            {
                if (str[i] != '0')
                    break;
            }
            if (i == 0) { return str; }
            return str.Substring(i);
        }

        /// <summary>
        /// ready
        /// </summary>
        /// <param name="inputValue"></param>
        private static void CheckStringIsNotNull(string inputValue)
        {
            if (String.IsNullOrEmpty(inputValue))
            { throw new ArgumentException("String is null or empty", "inputValue"); }
        }
        /// <summary>
        /// ready
        /// </summary>
        /// <param name="inputValue"></param>
        /// <returns></returns>
        private static bool? CheckFirstSign(string inputValue)
        {
            char firstSign = inputValue[0];
            CheckCharIsValid(firstSign);
            if (firstSign == '-')
            {
                return false;
            }
            if (firstSign == '+')
            { return true; }
            return null;

        }
        /// <summary>
        /// ready
        /// </summary>
        /// <param name="v"></param>
        private static void CheckCharIsValid(char v)
        {
            if (v == '+' || v == '-') return;
            var ich = (int)v;

            if (!(ich>=48 && ich <= 57))
            {
                throw new ArgumentException("string is not valid");
            }
        }

        /// <summary>
        /// ready
        /// </summary>
        /// <param name="inputValue"></param>
        /// <param name="i"></param>
        /// <param name="newString"></param>
        /// <returns></returns>
        private static string Replace(string inputValue, int i, string newString)
        {
            return inputValue.Substring(0, i) + newString;
        }
        /// <summary>
        /// ready
        /// </summary>
        /// <param name="sb"></param>
        /// <returns></returns>
        private static string Reverse(StringBuilder sb)
        {
            StringBuilder sb1 = new StringBuilder();
            for (int i = sb.Length - 1; i >= 0; i--)
            {
                sb1.Append(sb[i]);
            }
            return sb1.ToString();
        }

        private static char IncrementChar(char Char, ref bool needAdd)
        {
            int ch = 1 + (int)Char;
            if (ch == 58)
            {
                needAdd = true;
                return '0';
            }
            else
            {
                needAdd = false;
            }
            return (char)ch;
        }
        private static char DecrementChar(char Char, ref bool needAdd)
        {
            int ch = (int)Char-1;
            if (ch == 47)
            {
                needAdd = true;
                return '9';
            }
            else
            {
                needAdd = false;
            }
            return (char)ch;
        }
    }
}
