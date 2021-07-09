using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Test_IBAGruop_RVS.Models;
using Test_IBAGruop_RVS.Functional;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Test_IBAGruop_RVS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FixationSystemDataController : ControllerBase
    {
     
        // GET api/FixationSystemData/byName/
        [HttpGet("byName")]
        public ActionResult<List<FixationSystemData>> Get(DateTime dateTime, string travelSpeed)
        {
            if (RequestProcessingTime.TimeChek())
            {
                DateTime plug;
                bool flag1;
                bool flag = DateTime.TryParseExact(dateTime.ToString(), ValidationOfInputData.DataTimeFormat, null, DateTimeStyles.None, out plug);
                if (travelSpeed == null)
                {
                    flag1 = true;
                }
                else
                {
                    string temp = travelSpeed.Length == 4 ? ValidationOfInputData.SeepdFormat4 : ValidationOfInputData.SeepdFormat5;
                    flag1 = Regex.IsMatch(travelSpeed, temp);
                }
                if (flag && flag1)
                {
                    List<FixationSystemData> listFixations;

                    FixationSystemData fixation = new FixationSystemData(new DateTime(),
                        ValidationOfInputData.CarNumberDefault, ValidationOfInputData.SeepdDefault);

                    fixation.DateTime = dateTime;
                    listFixations = SearchData.SearchByDataAndSpeed(fixation, travelSpeed);
                    if (listFixations != null)
                    {
                        return listFixations;
                    }
                    else
                    {
                        return NotFound("Data not found");
                    }

                }
                return NotFound("Data not found");
            }
            else
            {
                return NotFound();
            }
        }

        // POST api/FixationSystemData/
        [HttpPost]
        public ActionResult<FixationSystemData> Post([FromBody] FixationSystemData fixationSystemData)
        {
            DateTime plug;
            bool flag = DateTime.TryParseExact(fixationSystemData.DateTime.ToString(), ValidationOfInputData.DataTimeFormat, null, DateTimeStyles.None, out plug);
            bool flag1 = Regex.IsMatch(fixationSystemData.CarNumber, ValidationOfInputData.CarNumberFormat);
            string temp = fixationSystemData.TravelSpeed.Length == 4 ? ValidationOfInputData.SeepdFormat4 : ValidationOfInputData.SeepdFormat5;
            bool flag2 = Regex.IsMatch(fixationSystemData.TravelSpeed, temp);

            if (flag && flag1 && flag2)
            {
                WriteData.WriteInDataBase(fixationSystemData);
                return fixationSystemData;
            }
            return NotFound("Data not found");
        }

    }
}
