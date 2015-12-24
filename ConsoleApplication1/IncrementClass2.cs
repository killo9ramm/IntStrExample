using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class IncrementClass2
    {
        public static string Inc(string inputValue)
        {
            IntString intString = IntString.Create(inputValue);

            if (intString.IsZero)
            {
                return intString.ToString();
            }

            for (int i = intString.End; i >= intString.Begin; i--)
            {
                if (intString.IsPositive)
                {
                    IncrementChar(intString,i);
                }
                else
                {
                    DecrementChar(intString,i);
                }
                if (!intString.IsNeedExtraDigit)
                { break; }
            }
            return intString.ToString();
        }

        unsafe private static void DecrementChar(IntString intString, int i)
        {
            fixed (char* ch = intString.IntStr)
            {
                int _ch = (int)ch[i]-1;
                if (_ch == 47)
                {
                    intString.IsNeedExtraDigit = true;
                    ch[i] = '9';
                }
                else
                {
                    intString.IsNeedExtraDigit = false;
                    ch[i] = (char)_ch;
                }
            }
        }

        unsafe private static void IncrementChar(IntString intString,int i)
        {
            fixed (char* ch = intString.IntStr)
            {
                int _ch = 1 + (int)ch[i];
                if (_ch == 58)
                {
                    intString.IsNeedExtraDigit = true;
                    ch[i] = '0';
                }
                else
                {
                    intString.IsNeedExtraDigit = false;
                    ch[i] = (char)_ch;
                }
            }
        }

        public class IntString 
        {
            public const char UNPRINTED='#';

            public string IntStr { get; set; }
            public int Begin { get; set; }
            public int End { get; set; }
            public bool IsPositive
            {
                get
                {
                    if (Sign == null || Sign == '+')
                    { return true; }
                    else
                    {
                        return false;
                    }
                }
            }

            public bool IsNeedExtraDigit { get; set; }
            public char? Sign { get; set; }
            public bool IsZero { get; set; }

            private IntString(){}
            public static IntString Create(string _string)
            {
                CheckInputString(_string);
                IntString intString = new IntString();
                intString.IntStr = _string;
                intString.GetSign();
                intString.SplitDrobPart();
                intString.SplitZeroes();
                if(!intString.IsZero)
                    intString.SelfCheck();
                return intString;
            }

            private void SelfCheck()
            {
                if (Begin >= End)
                {
                    if (End == 0 || End==-1)
                    {
                        throw new ArgumentException("wrong string format");
                    }
                    if (Begin - End == 1)
                    {
                        IsZero = true;
                    }
                }
                for (int i = Begin; i <= End;i++)
                {
                    IsDigit(IntStr[i]);
                }
            }

            private static void CheckInputString(string _string)
            {
                if (String.IsNullOrEmpty(_string))
                { throw new ArgumentException("string is not valid"); }
                foreach (var ch in _string)
                {
                    IsValid(ch);
                }
            }

            public void SplitDrobPart()
            {
                int j=this.IntStr.IndexOfAny(new char[]{',','.'});
                int k = j;

                if (j != -1)
                {
                    this.End = j-1;
                    unsafe
                    {
                        fixed (char* ch = this.IntStr)
                        {
                            int i = 0;
                            while (j < this.IntStr.Length)
                            {
                                if (j > k)
                                { IsDigit(ch[j]); }
                                ch[j] = UNPRINTED;
                                //char* ch1 = ch + j;
                                //*ch1 = UNPRINTED;
                                j++;
                            }
                        }
                    }
                }
                else
                {
                    this.End=this.IntStr.Length-1;
                }
            }

            
            private static void IsValid(char v)
            {
                if (v == '+' || v == '-' || v=='.' || v==',') return;
                IsDigit(v);
            }

            private static void IsDigit(char v)
            {
                var ich = (int)v;
                if (!(ich >= 48 && ich <= 57))
                {
                    throw new ArgumentException("string is not valid");
                }
            }

            unsafe public void SplitZeroes()
            {
                int i = Begin;
                int j = 0;
                fixed(char* ch=this.IntStr)
                {
                    while (ch[i] == '0')
                    {
                        ch[i] = UNPRINTED;
                        i++;
                        j++;
                    }
                }
                if (j == 1) IsZero = true;
                this.Begin=i;
            }

            unsafe public void GetSign()
            {
                fixed (char* ch = this.IntStr)
                {
                    if (*ch == '-')
                    { 
                        this.Sign = *ch;
                        *ch = UNPRINTED;
                        this.Begin = 1;
                    }
                    if (*ch == '+')
                    { 
                        this.Sign = *ch;
                        *ch = UNPRINTED;
                        this.Begin = 1;
                    }
                }
            }
            public override string ToString()
            {
                if (IsZero)
                    return "1";
                if (IsPositive)
                {
                    if (IsNeedExtraDigit)
                    { return '1' + this.IntStr.Substring(Begin, End + 1 - Begin); }
                    else
                    {
                        this.SplitZeroes();
                        return this.IntStr.Substring(Begin, End + 1 - Begin);
                    }
                }
                else
                {
                    this.SplitZeroes();
                    return this.Sign + this.IntStr.Substring(Begin, End + 1 - Begin);
                }
            }
        }
    }
}
