using System;
using System.Collections.Generic;
using System.Text;

namespace Bookynfo.Info
{
    class ISBN_List_Class
    {
        public static List<long> GetISBN_List()
        {
            //var ISBNList= new List<string>()
            var ISBN_Number = new List<long>()
            { 9781451648546,  9781500602062, 9780321563842,  9780393979503,  9781565923065,

                9781593276034,  9781449359362, 9780071809252, 9781605544649, 9781605542744, 9780876596517 };

            return ISBN_Number;
        }
    }
}


