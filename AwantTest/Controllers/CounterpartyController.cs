using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AwantData;
using AwantTest.Services;
using AwantTest.Model;
using LiteDB;

namespace AwantTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CounterpartyController : ControllerBase
    {
        /// <summary>
        /// Получает список всех контрагентов в базе
        /// </summary>
        /// <returns code="200">
        /// список контрагентов 
        /// </returns>
        /// <returns code="503">неизвестная внутренняя ошибка. </returns>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Counterparty>), 200)]
        [ProducesResponseType(503)]
        public ActionResult Get([FromServices] CounterpartyDbContext ctx)
        {
            try
            {
                var col = ctx.Database.GetCollection<Counterparty>("Counterparty");
                var result = col.FindAll();
                return new JsonResult(result);
            } 
            catch(Exception e)
            {
                return StatusCode(503);
            }
        }

        /// <summary>
        /// Добавляет контрагента
        /// </summary>
        /// <param name="counterparty">вводимый контрагент</param>
        /// <returns code="200">
        /// сохраненый в бд контрагент
        /// </returns>
        /// <returns code="404">данные введены не правильно</returns>
        [HttpPost]
        [ProducesResponseType(typeof(Counterparty), 200)]
        [ProducesResponseType(typeof(string), 404)]
        public ActionResult Post([FromServices] ICounterpartyDataService dadataService, [FromServices] CounterpartyDbContext ctx, [FromBody] CounterpartyForm counterparty)
        {
            try
            {
                Sugestion fromDadata;
                if (counterparty.KPP.HasValue)
                {
                     fromDadata =  dadataService.GetLegalData(counterparty.INN, counterparty.KPP.GetValueOrDefault());
                }
                else
                {
                    fromDadata = dadataService.GetIndividalData(counterparty.INN);
                }

                if (fromDadata == null)
                { 
                    return NotFound(404); 
                }

                var localCounterparty = ctx.Database.GetCollection<Counterparty>()
                    .FindOne(Query.And(Query.EQ("KPP", counterparty.KPP), Query.EQ("INN", counterparty.INN)));

                if (localCounterparty == null)
                {
                    localCounterparty = new Counterparty();
                }

                localCounterparty.KPP = counterparty.KPP.GetValueOrDefault();
                localCounterparty.INN = counterparty.INN;
                localCounterparty.FullName = fromDadata.FullName;
                localCounterparty.Name = fromDadata.Name;

                var col = ctx.Database.GetCollection<Counterparty>();
                col.Upsert(localCounterparty);

                return new JsonResult(localCounterparty);
            }
            catch (Exception e)
            {
                return StatusCode(503);
            }
        }
    }
}