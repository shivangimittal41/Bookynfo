using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.IO;
using System.Net.Http.Headers;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using Newtonsoft.Json;
namespace Bookynfo.Info
{
    class FirstScreen_class
    {
        public async static Task<FirstRootObject> GetFirst_details(long ISBN)
        {
            var http = new HttpClient();

            var response = await http.GetAsync(App.URL + ":" + ISBN);
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
           
             [JsonProperty( NullValueHandling = NullValueHandling.Ignore )]
            public string smallThumbnail { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string thumbnail { get; set; }
    }
    //[DataContract]
    public class VolumeInfo
    {
        //[DataMember]
        public string title { get; set; }
        //[DataMember]
        public List<string> authors { get; set; }
        //public string publisher { get; set; }
        //public string publishedDate { get; set; }
        //public string description { get; set; }
        //public List<IndustryIdentifier> industryIdentifiers { get; set; }
        //public ReadingModes readingModes { get; set; }
        //public int pageCount { get; set; }
        //public string printType { get; set; }
        //[DataMember]
        public List<string> categories { get; set; }
        //public double averageRating { get; set; }
        //public int ratingsCount { get; set; }
        //public string maturityRating { get; set; }
        //public bool allowAnonLogging { get; set; }
        //public string contentVersion { get; set; }
        //[DataMember]
        public ImageLinks imageLinks { get; set; }
        //public string language { get; set; }
        //[DataMember]
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

    //[DataContract]
    public class Pdf
    {
        //[DataMember]
        public bool isAvailable { get; set; }
    }
    //[DataContract]
    public class AccessInfo
    {

        //    public string country { get; set; }
        //    public string viewability { get; set; }
        //    public bool embeddable { get; set; }
        //    public bool publicDomain { get; set; }
        //    public string textToSpeechPermission { get; set; }
        //    public Epub epub { get; set; }

        //[DataMember]
        public Pdf pdf { get; set; }
    //    public string webReaderLink { get; set; }
    //    public string accessViewStatus { get; set; }
    //    public bool quoteSharingAllowed { get; set; }
    }

    //public class SearchInfo
    //{
    //    public string textSnippet { get; set; }
    //}
    //[DataContract]
    public class Item
    {
        //[DataMember]
        public string kind { get; set; }
        //[DataMember]
        public string id { get; set; }
        //public string etag { get; set; }
        //[DataMember]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string selfLink { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        //[DataMember]
        public VolumeInfo volumeInfo { get; set; }
        //public SaleInfo saleInfo { get; set; }
        public AccessInfo accessInfo { get; set; }
        //public SearchInfo searchInfo { get; set; }
    }
    //[DataContract]
    public class FirstRootObject
    {
        //[DataMember]
        public string kind { get; set; }
        //[DataMember]
        public int totalItems { get; set; }
        //[DataMember]
        public List<Item> items { get; set; }
    }
}