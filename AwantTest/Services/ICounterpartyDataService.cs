using AwantTest.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AwantTest.Services
{
    public interface ICounterpartyDataService
    {
        Sugestion GetIndividalData(long inn);
        Sugestion GetLegalData(long inn, long kpp);
    }
}
