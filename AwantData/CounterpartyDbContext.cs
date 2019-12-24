using System;
using System.Collections.Generic;
using System.Text;
using LiteDB;

namespace AwantData
{
    public class CounterpartyDbContext : IDisposable
    {
        public LiteDatabase Database;
        public CounterpartyDbContext(string path)
        {
            Database = new LiteDatabase(path);
            var col = Database.GetCollection<Counterparty>();

            if (!Database.CollectionExists(typeof(Counterparty).Name))
            {
                col.Insert(new Counterparty()
                {
                    Name = "ПАО СБЕРБАНК",
                    FullName = "ПУБЛИЧНОЕ АКЦИОНЕРНОЕ ОБЩЕСТВО \"СБЕРБАНК РОССИИ\"",
                    INN = 7707083893,
                    KPP = 540602001,
                    CounterpartyType = CounterpartyTypeEnum.LEGAL
                });

                col.Insert(new Counterparty()
                {
                    Name = "БАЙКАЛЬСКИЙ БАНК ПАО СБЕРБАНК",
                    FullName = "БАЙКАЛЬСКИЙ БАНК ПАО СБЕРБАНК",
                    INN = 7707083893,
                    KPP = 380843001,
                    CounterpartyType = CounterpartyTypeEnum.LEGAL
                });

                col.Insert(new Counterparty()
                {
                    Name = "ИП Чех Илья Викторович",
                    FullName = "Индивидуальный предприниматель Чех Илья Викторович",
                    INN = 784806113663,
                    CounterpartyType = CounterpartyTypeEnum.INDIVIDUAL
                });
            }
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
