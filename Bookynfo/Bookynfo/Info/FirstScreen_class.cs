﻿using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.IO;
using System.Net.Http.Headers;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;

namespace Bookynfo.Info
{
    class FirstScreen_class
    {
        public async static Task<FirstRootObject> GetFirst_details()
        {
            var http = new HttpClient();

            var response = await http.GetAsync(App.URL + ":" + App.ISBN);
            //Console.WriteLine("URL MERA Choice : " + App.primaryDomain + "/" + App.currentSelectedSurveyID + "/pages/" + App.currentSelectedPageID + "/questions/" + App.currentQID);
            var result = await response.Content.ReadAsStringAsync();
            var Serializer = new DataContractJsonSerializer(typeof(FirstRootObject));

            var ms = new MemoryStream(Encoding.UTF8.GetBytes(result));
            var data = (FirstRootObject)Serializer.ReadObject(ms);

            return data;
        }
    }



//public class IndustryIdentifier
//{
//    public string type { get; set; }
//    public string identifier { get; set; }
//}

//public class ReadingModes
//{
//    public bool text { get; set; }
//    public bool image { get; set; }
//}

public class ImageLinks
{
    public string smallThumbnail { get; set; }
    public string thumbnail { get; set; }
}

public class VolumeInfo
{
    public string title { get; set; }
    public List<string> authors { get; set; }
    //public string publisher { get; set; }
    //public string publishedDate { get; set; }
    //public string description { get; set; }
    //public List<IndustryIdentifier> industryIdentifiers { get; set; }
    //public ReadingModes readingModes { get; set; }
    //public int pageCount { get; set; }
    //public string printType { get; set; }
    public List<string> categories { get; set; }
    //public double averageRating { get; set; }
    //public int ratingsCount { get; set; }
    //public string maturityRating { get; set; }
    //public bool allowAnonLogging { get; set; }
    //public string contentVersion { get; set; }
    public ImageLinks imageLinks { get; set; }
    //public string language { get; set; }
    public string previewLink { get; set; }
    //public string infoLink { get; set; }
    //public string canonicalVolumeLink { get; set; }
}

//public class SaleInfo
//{
//    public string country { get; set; }
//    public string saleability { get; set; }
//    public bool isEbook { get; set; }
//}

//public class Epub
//{
//    public bool isAvailable { get; set; }
//}

public class Pdf
{
    public bool isAvailable { get; set; }
}

//public class AccessInfo
//{
//    public string country { get; set; }
//    public string viewability { get; set; }
//    public bool embeddable { get; set; }
//    public bool publicDomain { get; set; }
//    public string textToSpeechPermission { get; set; }
//    public Epub epub { get; set; }
//    public Pdf pdf { get; set; }
//    public string webReaderLink { get; set; }
//    public string accessViewStatus { get; set; }
//    public bool quoteSharingAllowed { get; set; }
//}

//public class SearchInfo
//{
//    public string textSnippet { get; set; }
//}

public class Item
{
    public string kind { get; set; }
    public string id { get; set; }
    //public string etag { get; set; }
    public string selfLink { get; set; }
    public VolumeInfo volumeInfo { get; set; }
    //public SaleInfo saleInfo { get; set; }
    //public AccessInfo accessInfo { get; set; }
    //public SearchInfo searchInfo { get; set; }
}

public class FirstRootObject
{
    public string kind { get; set; }
    public int totalItems { get; set; }
    public List<Item> items { get; set; }
}
}