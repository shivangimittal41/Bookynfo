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
using Bookynfo.LocalData;

namespace Bookynfo.Info
{
    class FirstScreen_class
    {
        public async static Task<FirstRootObject> GetFirst_details(string ID , string SearchType)
        {
            var url = "";
            var http = new HttpClient();
            if (SearchType == "ISBN")
            {
                url = App.URL + "isbn" + ":" + ID;
            }
            else
            {
                url = App.URL + ID.Replace(" ", "%20");
            }
              
            var response = await http.GetAsync(url);
            //Console.WriteLine("URL MERA Choice : " + App.primaryDomain + "/" + App.currentSelectedSurveyID + "/pages/" + App.currentSelectedPageID + "/questions/" + App.currentQID);
            var result = await response.Content.ReadAsStringAsync();
            FirstRootObject data = JsonConvert.DeserializeObject<FirstRootObject>(result);

            //var Serializer = new DataContractJsonSerializer(typeof(FirstRootObject));

            //var ms = new MemoryStream(Encoding.UTF8.GetBytes(result));
            //var data = (FirstRootObject)Serializer.ReadObject(ms);

            return data;
        }
    }
          
        public class ImageLinks
    {
           
             [JsonProperty( NullValueHandling = NullValueHandling.Ignore )]
            public string smallThumbnail { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string thumbnail { get; set; }
    }
    public class IndustryIdentifier
    {
      
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string type { get; set; }
  
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string identifier { get; set; }
    }
    public class VolumeInfo
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
      
        public string title { get; set; }
    
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public List<string> authors { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public List<IndustryIdentifier> industryIdentifiers { get; set; }
      
        [JsonProperty("categories", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> categories { get; set; }
  
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public ImageLinks imageLinks { get; set; }
        //public string language { get; set; }
        //[DataMember]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string previewLink { get; set; }
        //public string infoLink { get; set; }
        //public string canonicalVolumeLink { get; set; }
    }

  
    public class Pdf
    {
        //[DataMember]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public bool isAvailable { get; set; }
    }
    //[DataContract]
    public class AccessInfo
    {

      
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public Pdf pdf { get; set; }
  
    }

    public class SearchInfo
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string textSnippet { get; set; }
    }
    //[DataContract]
    public class Item
    {
        //[DataMember]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string kind { get; set; }
        //[DataMember]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string id { get; set; }
        //public string etag { get; set; }
        //[DataMember]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string selfLink { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        //[DataMember]
        public VolumeInfo volumeInfo { get; set; }
        //public SaleInfo saleInfo { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public AccessInfo accessInfo { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public SearchInfo searchInfo { get; set; }
    }
    //[DataContract]
    public class FirstRootObject
    {
        //[DataMember]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string kind { get; set; }
        //[DataMember]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int totalItems { get; set; }
        //[DataMember]
        [JsonProperty( NullValueHandling = NullValueHandling.Ignore)]
        public List<Item> items { get; set; }
    }
}