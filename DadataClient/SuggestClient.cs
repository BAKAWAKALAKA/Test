using RestSharp;
using Newtonsoft.Json;
using DadataClient.Model;

namespace DadataClient
{
    public class SuggestClient
    {
        string _path { get; set; }
        string _token { get; set; }
        public SuggestClient(string path, string authKey)
        {
            _token = authKey;
            _path = path;
        }

        /// <summary>
        /// get main suggestion by company inn
        /// </summary>
        /// <param name="inn"></param>
        /// <returns></returns>
        public Suggestion Get(long inn)
        {
            var client = new RestSharp.RestClient(_path);
            var req = new RestRequest();

            req.Method = Method.POST;
            req.AddHeader("Authorization", $"Token {_token}");
            req.AddHeader("Content-Type", "application/json");
            req.AddHeader("Accept", "application/json");

            var body = JsonConvert.SerializeObject(
                new
                {
                    query = inn,
                    type = "INDIVIDUAL"
                }
                );
            req.AddJsonBody(body);

            var response = client.Execute(req);
            if (response.IsSuccessful)
            {
                var result = JsonConvert.DeserializeObject<Party>(response.Content);
                if(result?.Suggestions?.Length>0)
                {
                    return result.Suggestions[0];
                }
                return null;
            }
            return null;
        }

        /// <summary>
        /// get current company suggestion by inn and kpp
        /// </summary>
        /// <param name="inn"></param>
        /// <param name="kpp"></param>
        /// <returns></returns>
        public Suggestion Get(long inn, long kpp)
        {
            var client = new RestSharp.RestClient(_path);
            var req = new RestRequest();

            req.Method = Method.POST;
            req.AddHeader("Authorization", $"Token {_token}");
            req.AddHeader("Content-Type", "application/json");
            req.AddHeader("Accept", "application/json");

            var body = JsonConvert.SerializeObject(
                new
                {
                    query = inn,
                    kpp = kpp,
                    type = "LEGAL"
                }
                );
            req.AddJsonBody(body);

            var response = client.Execute(req);
            if (response.IsSuccessful)
            {
                var result = JsonConvert.DeserializeObject<Party>(response.Content);
                if (result?.Suggestions?.Length > 0)
                {
                    return result.Suggestions[0];
                }
                return null;
            }
            return null;
        }
    }
}
