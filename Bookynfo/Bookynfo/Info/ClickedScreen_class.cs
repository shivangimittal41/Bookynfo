using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace Bookynfo.Info
{
    class ClickedScreen_class
    {
        public async static Task<Clicked_RootObject> GetClicked_details(int isbn)
           
        {
            var http = new HttpClient();

            var response = await http.GetAsync(App.URL + ":" + isbn);
            //Console.WriteLine("URL MERA Choice : " + App.primaryDomain + "/" + App.currentSelectedSurveyID + "/pages/" + App.currentSelectedPageID + "/questions/" + App.currentQID);
            var result = await response.Content.ReadAsStringAsync();
            var Serializer = new DataContractJsonSerializer(typeof(Clicked_RootObject));

            var ms = new MemoryStream(Encoding.UTF8.GetBytes(result));
            var data = (Clicked_RootObject)Serializer.ReadObject(ms);

            return data;
        }
    }
    [DataContract]
    public class Clicked_IndustryIdentifier
    {
        [DataMember]
        public string type { get; set; }
        [DataMember]
        public string identifier { get; set; }
    }
    [DataContract]
    public class Clicked_ReadingModes
    {
        [DataMember]
        public bool text { get; set; }
        [DataMember]
        public bool image { get; set; }
    }
    [DataContract]
    public class Clicked_ImageLinks
    {
        [DataMember]
        public string smallThumbnail { get; set; }
        [DataMember]
        public string thumbnail { get; set; }
    }
    [DataContract]
    public class Clicked_VolumeInfo
    {
        [DataMember]
        public string title { get; set; }
        [DataMember]
        public List<string> authors { get; set; }
        [DataMember]
        public string publisher { get; set; }
        [DataMember]
        public string publishedDate { get; set; }
        [DataMember]
        public string description { get; set; }
        [DataMember]
        public List<Clicked_IndustryIdentifier> industryIdentifiers { get; set; }
        [DataMember]
        public Clicked_ReadingModes readingModes { get; set; }
        [DataMember]
        public int pageCount { get; set; }
        [DataMember]
        public string printType { get; set; }
        [DataMember]
        public List<string> categories { get; set; }
        [DataMember]
        public int averageRating { get; set; }
        [DataMember]
        public int ratingsCount { get; set; }
        [DataMember]
        public string maturityRating { get; set; }
        [DataMember]
        public bool allowAnonLogging { get; set; }
        [DataMember]
        public string contentVersion { get; set; }
        [DataMember]
        public ImageLinks imageLinks { get; set; }
        [DataMember]
        public string language { get; set; }
        [DataMember]
        public string previewLink { get; set; }
        [DataMember]
        public string infoLink { get; set; }
        [DataMember]
        public string canonicalVolumeLink { get; set; }
    }
    [DataContract]
    public class Clicked_SaleInfo
    {
        [DataMember]
        public string country { get; set; }
        [DataMember]
        public string saleability { get; set; }
        [DataMember]
        public bool isEbook { get; set; }
    }
    [DataContract]
    public class Clicked_Epub
    {
        [DataMember]
        public bool isAvailable { get; set; }
    }
    [DataContract]
    public class Clicked_Pdf
    {
        [DataMember]
        public bool isAvailable { get; set; }
    }
    [DataContract]
    public class Clicked_AccessInfo
    {
        [DataMember]
        public string country { get; set; }
        [DataMember]
        public string viewability { get; set; }
        [DataMember]
        public bool embeddable { get; set; }
        [DataMember]
        public bool publicDomain { get; set; }
        [DataMember]
        public string textToSpeechPermission { get; set; }
        [DataMember]
        public Clicked_Epub epub { get; set; }
        [DataMember]
        public Pdf pdf { get; set; }
        [DataMember]
        public string webReaderLink { get; set; }
        [DataMember]
        public string accessViewStatus { get; set; }
        [DataMember]
        public bool quoteSharingAllowed { get; set; }
    }
    [DataContract]
    public class Clicked_SearchInfo
    {
        [DataMember]
        public string textSnippet { get; set; }
    }
    [DataContract]
    public class Clicked_Item
    {
        [DataMember]
        public string kind { get; set; }
        [DataMember]
        public string id { get; set; }
        [DataMember]
        public string etag { get; set; }
        [DataMember]
        public string selfLink { get; set; }
        [DataMember]
        public VolumeInfo volumeInfo { get; set; }
        [DataMember]
        public Clicked_SaleInfo saleInfo { get; set; }
        [DataMember]
        public Clicked_AccessInfo accessInfo { get; set; }
        [DataMember]
        public Clicked_SearchInfo searchInfo { get; set; }
    }
    [DataContract]
    public class Clicked_RootObject
    {
        [DataMember]
        public string kind { get; set; }
        [DataMember]
        public int totalItems { get; set; }
        [DataMember]
        public List<Item> items { get; set; }
    }
}
