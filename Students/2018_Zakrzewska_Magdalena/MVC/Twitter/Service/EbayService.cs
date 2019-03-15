using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Xml.Serialization;
using Twitter.Models.Ebay;

namespace Twitter.Service
{
    public class EbayService
    {
        private static string endpoint = "http://svcs.sandbox.ebay.com/services/search/FindingService/v1";
        private static string appId = "Magdalen-Tweeter-SBX-47141958a-8775a0d8";
 //       private static string devId = "485eaaee-f6c5-42ad-aa63-0b43a186c450";
 //       private static string certId = "SBX-7141958a17c0-6987-4d36-b427-bf3e";
 //       private static string token = "AgAAAA**AQAAAA**aAAAAA**zF8WWw**nY+sHZ2PrBmdj6wVnY+sEZ2PrA2dj6wFk4agD5KDpAydj6x9nY+seQ**Q50EAA**AAMAAA**YHdbmEAANLuaoF/sTvFDQDVNZl5J8vb3Np/pra7yYSkwgDMj8tPWkjTmzxvrFMK4SRQfmMAOV5JOn7JEh+/eiKFsSnvqxszE9inrSbSntv/NbaaOffMHyk3YNe6G5OZ1NbEeYdqnLvXiYJ/MI1P1jIBQs8sBv43hCnIs9bIVcOKG7XkHjwpVOH1Jh5MIeS8dDvYiGP7bWXHRQ1+jpvuW1wHeatOVAzahL/rO7Lml8H+Pkk/eal1d7UJ0P3Z5Elxm1eDSTifs+ghee2Z5UMxZPSNjpymIhnrsZPDZO8RuejDstzHQ0WQzvqQ2VwZCxD5b1JaVYuluilPw+0LM9cm4uTNCctA0x8w0MFI+wO8nlzfmi49BqAaCXARNEs13NgngQ4VYFt6MUMLvM4q6SU5yBuNw+Teo5hb3eOHBYVNFPpGAFrE1q6G+38t4VlyLwMtyE95POjDM61+GyGCIoyUl0Gj81KUPmvNPiMObBZloH70FPozbwO2EMDkoF6DW3SFHK1QXAcb5Sb6ciHBJtwlsXtnCjtRzMiHJjLCJwNcxSu6ywMuFgRCcRNjghIpKZqPp0Y5TPS8+zfsES0e9D7GCpm9torIz9QHHwmuev8VNVoGaulimE1ihDvHnKZQW4TyUog/oGkou0/rCvWhBgdloIPE5oSTRzIGnqdGccEX1sz9pGH9U5SBc837gZ2bPA0dtT4xsRGEooRkXIYZ9+hOWQVDrs9OYRfhd1pBoTVR9jtqigpZeqKG7HCd7pmp+yXuK";
        private static string version = "1.0.0";

        public async Task<Items> GetEbayCall(string call)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/xml"));

            string requestUrl = endpoint
                + "?OPERATION-NAME=" + call
                + "&SERVICE-VERSION=" + version
                + "&SECURITY-APPNAME=" + appId
                + "&RESPONSE-DATA-FORMAT=XML"
                + "&categoryId=31388"
                + "&itemFilter(0).name=MinPrice"
                + "&itemFilter(0).value=50.00"
                + "&itemFilter(1).name=MaxPrice"
                + "&itemFilter(1).value=75.00"
                + "&paginationInput.entriesPerPage=2"
                + "&routing=default";
            
            HttpResponseMessage response = await client.GetAsync(requestUrl);

            if (response.IsSuccessStatusCode)
            {
                var textAsync = await response.Content.ReadAsStringAsync();
                var text = Regex.Replace(textAsync, " [^<?;]+>", ">");


                XmlSerializer xmlSerializer = new XmlSerializer(typeof(Items));
                Items result;

                using (TextReader reader = new StringReader(text))
                {
                    result = (Items)xmlSerializer.Deserialize(reader);
                }

                return result;
            }

            throw new FieldAccessException();
        }
    }
}