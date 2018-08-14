using System;
using System.Collections.Generic;
using System.Text;

namespace Bookynfo.Info
{
    class ISBN_List_Class
    {
        public static List<string> GetISBN_List()
        {
            //var ISBNList= new List<string>()
            var ISBN_Number = new List<String>()
            { "9781451648546", "9780439358071", "9780060935467", "9781500602062",
                "9781605544649", "9781605542744", "9780876596517", "9780996980807",
                "9781781453148", "9783858819154" };

            return ISBN_Number;
        }
    }
}


