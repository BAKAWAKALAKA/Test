using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DadataClient;
using AwantTest.Model;

namespace AwantTest.Services
{
    public class DadataService: ICounterpartyDataService
    {
        private SuggestClient client;
        public DadataService(string path, string token)
        {
            client = new SuggestClient(path, token);
        }

        public Sugestion GetIndividalData(long inn)
        {
            var suggestion = client.Get(inn);
            if(suggestion != null)
            {
                return new Sugestion()
                {
                    Name = suggestion.Data.Name.Short,
                    FullName = suggestion.Data.Name.FullWithOpf
                };
            }
            return null;
        }

        public Sugestion GetLegalData(long inn, long kpp)
        {
            var suggestion = client.Get(inn, kpp);
            if (suggestion != null)
            {
                return new Sugestion()
                {
                    Name = suggestion.Data.Name.ShortWithOpf,
                    FullName = suggestion.Data.Name.FullWithOpf
                };
            }
            return null;
        }
    }
}
