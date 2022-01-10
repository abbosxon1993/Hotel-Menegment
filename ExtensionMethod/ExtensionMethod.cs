﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.ExtensionMethod
{
    public static class ExtensionMethod
    {
        //extension method of capilazing input data
        public static string Capitalize(this string text)
        {
            if (Char.IsLower(text[0]))
            {
                char capital = char.ToUpper(text[0]);
                text = text.Remove(0, 1);
                text = text.Insert(0, capital.ToString());
            }
            return text;
        }
    }
}
