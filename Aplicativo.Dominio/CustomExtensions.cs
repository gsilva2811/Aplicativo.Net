using System;

namespace Aplicativo.Dominio
{
    public static class CustomExtensions
    {
        public static string ToValue(this decimal obj, int precision)
        {
            return obj.ToString("F" + precision);
        }

        public static string ToReal(this decimal obj)
        {
            return "R$"+obj.ToString("F2");
        }

        public static string ToNumberField(this decimal obj)
        {
            return obj.ToString().Replace(",", ".");
        }

        public static decimal ToNumberField(this string obj)
        {
            return Convert.ToDecimal(obj.Replace(".", ",")); ;
        }

        public static string Right(this string sValue, int iMaxLength)
        {
            //Check if the value is valid
            if (string.IsNullOrEmpty(sValue))
            {
                //Set valid empty string as string could be null
                sValue = string.Empty;
            }
            else if (sValue.Length > iMaxLength)
            {
                //Make the string no longer than the max length
                sValue = sValue.Substring(sValue.Length - iMaxLength, iMaxLength);
            }

            //Return the string
            return sValue;
        }
    }
}