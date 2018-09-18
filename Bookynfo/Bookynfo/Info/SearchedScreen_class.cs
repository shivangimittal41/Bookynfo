using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Bookynfo.Info
{
    class SearchedScreen_class
    {
        public async static Task<Searched_RootObject> GetClicked_details()

        {
            var http = new HttpClient();

            var response = await http.GetAsync(App.URL +  App.SearchBookName.Replace(" ", "%20"));
            //Console.WriteLine("URL MERA Choice : " + App.primaryDomain + "/" + App.currentSelectedSurveyID + "/pages/" + App.currentSelectedPageID + "/questions/" + App.currentQID);
            var result = await response.Content.ReadAsStringAsync();
            var Serializer = new DataContractJsonSerializer(typeof(Searched_RootObject));

            var ms = new MemoryStream(Encoding.UTF8.GetBytes(result));
            var data = (Searched_RootObject)Serializer.ReadObject(ms);

            return data;
        }
    }
    public class Searched_IndustryIdentifier
    {
        //[DataMember]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string type { get; set; }
        //[DataMember]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string identifier { get; set; }
    }
    //[DataContract]
    public class Searched_ReadingModes
    {
        //[DataMember]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public bool text { get; set; }
        //[DataMember]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public bool image { get; set; }
    }
    //[DataContract]
    public class Searched_ImageLinks
    {
        //[DataMember]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string smallThumbnail { get; set; }
        //[DataMember]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string thumbnail { get; set; }
    }
    //[DataContract]
    public class Searched_VolumeInfo
    {
        //[DataMember]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string title { get; set; }
        //[DataMember]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public List<string> authors { get; set; }
        //[DataMember]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string publisher { get; set; }
        //[DataMember]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string publishedDate { get; set; }
        //[DataMember]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string description { get; set; }
        //[DataMember]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public List<Searched_IndustryIdentifier> industryIdentifiers { get; set; }
        //[DataMember]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public Searched_ReadingModes readingModes { get; set; }
        //[DataMember]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int pageCount { get; set; }
        //[DataMember]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string printType { get; set; }
        //[DataMember]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public List<string> categories { get; set; }
        //[DataMember]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int averageRating { get; set; }
        //[DataMember]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int ratingsCount { get; set; }
        //[DataMember]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string maturityRating { get; set; }
        //[DataMember]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public bool allowAnonLogging { get; set; }
        //[DataMember]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string contentVersion { get; set; }
        //[DataMember]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public Searched_ImageLinks imageLinks { get; set; }
        //[DataMember]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string language { get; set; }
        //[DataMember]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string previewLink { get; set; }
        //[DataMember]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string infoLink { get; set; }
        //[DataMember]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string canonicalVolumeLink { get; set; }
    }
    //[DataContract]
    public class Searched_SaleInfo
    {
        //[DataMember]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string country { get; set; }
        //[DataMember]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string saleability { get; set; }
        //[DataMember]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public bool isEbook { get; set; }
    }
    //[DataContract]
    public class Searched_Epub
    {
        //[DataMember]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public bool isAvailable { get; set; }
    }
    //[DataContract]
    public class Searched_Pdf
    {
        //[DataMember]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public bool isAvailable { get; set; }
    }
    //[DataContract]
    public class Searched_AccessInfo
    {
        //[DataMember]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string country { get; set; }
        //[DataMember]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string viewability { get; set; }
        //[DataMember]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public bool embeddable { get; set; }
        //[DataMember]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public bool publicDomain { get; set; }
        //[DataMember]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string textToSpeechPermission { get; set; }
        //[DataMember]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public Clicked_Epub epub { get; set; }
        //[DataMember]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public Clicked_Pdf pdf { get; set; }
        //[DataMember]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string webReaderLink { get; set; }
        //[DataMember]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string accessViewStatus { get; set; }
        //[DataMember]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public bool quoteSharingAllowed { get; set; }
    }
    //[DataContract]
    public class Searched_SearchInfo
    {
        //[DataMember]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string textSnippet { get; set; }
    }
    //[DataContract]
    public class Searched_Item
    {
        //[DataMember]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string kind { get; set; }
        //[DataMember]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string id { get; set; }
        //[DataMember]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string etag { get; set; }
        //[DataMember]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string selfLink { get; set; }
        //[DataMember]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public Searched_VolumeInfo volumeInfo { get; set; }
        //[DataMember]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public Searched_SaleInfo saleInfo { get; set; }
        //[DataMember]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public Searched_AccessInfo accessInfo { get; set; }
        //[DataMember]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public Searched_SearchInfo searchInfo { get; set; }
    }
    //[DataContract]
    public class Searched_RootObject
    {
        //[DataMember]
        public string kind { get; set; }
        //[DataMember]
        public int totalItems { get; set; }
        //[DataMember]
        public List<Searched_Item> items { get; set; }
    }

}
