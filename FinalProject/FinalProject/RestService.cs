using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    public class RestService : IRestService
    {
        HttpClient _client;

        const string _API_KEY = "AacQG5BZOmferauzYtTVVCmkXSxaaqBTRdrFNtjw";

        public RestService()
        {
            _client = new HttpClient();
            
        }

        public async Task<APIImage> getPhotoByDateID(string date, string id)
        {
            List<APIImage> images = await getPhotoListForDay(date);

            APIImage targetImage = null;

            foreach(APIImage image in images)
            {
                if(image.PhotoID.ToString().Equals(id))
                {
                    targetImage = image;
                }
            }

            return targetImage;
        }

        public async Task<List<APIImage>> getPhotoListForDay(string date)
        {
            var uri =
                $@"https://api.nasa.gov/mars-photos/api/v1/rovers/curiosity/photos?earth_date={date}&api_key={_API_KEY}";

            var response = await _client.GetStringAsync(uri);

            var responseObject = JObject.Parse(response);

            List<APIImage> temp = (List<APIImage>)await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<IEnumerable<APIImage>>(responseObject["photos"].ToString()));

            Debug.WriteLine(temp.Count);

            return temp;

        }
    }
}
