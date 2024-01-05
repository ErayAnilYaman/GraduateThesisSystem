﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Constants.Messages
{
    public  class Messages
    {
        public static string Listed = "Listelendi!!";





        public static string ErrorEncountered = "HATAYLA KARSILASILDI!!";
    }
    public  class ThesisMessages : Messages
    {
        public static string ThesesListed = "Tezler Listelendi!!";
        public static string ThesisNotFound = "Tez Bulunamadi!!";
        public static string ThesisFound = "Tez Bulundu!!";
    }
}
