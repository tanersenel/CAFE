using CAFE.API.Functions;
using CAFE.API.Models;
using ExpressionBuilderCore.Common;
using ExpressionBuilderCore.Operations;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using static CAFE.API.Enums.Types;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CAFE.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurrencyController : ControllerBase
    {
        // GET: api/<CurrencyController>
        [HttpGet("Get/{currency}")]
        public ExchangeRateModel Get(string currency)
        {
            List<FilterModel> filters = new List<FilterModel>()
        {
                        new FilterModel()
                        {
                            FilterColumn = PropertyNames.CurrencyCode,
                            FilterValue1 = currency,
                            Condition = Operation.EqualTo,
                            GroupConnector = Connector.And
                        }
                    };
            var sorting = new SortingModel()
            {
                SortingColumn = PropertyNames.CurrencyCode,
                SortingType = SortingTypes.ASC
            };
            
            return CurrencyFunctions.GetTodayExhangeRate(sorting, filters).ObjectResult;
            

            
        }

    }
}
