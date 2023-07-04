using System;
using System.Collections.Generic;
using System.Text;
using AkademiPlusMicroserviceProje.Shared.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace AkademiPlusMicroserviceProje.Shared.ControllerBases
{
    public class CustomBaseController:ControllerBase
    {
        public IActionResult CreateActionResultInstance<T>(Response<T> response)
        {
            return new ObjectResult(response)
            {
                StatusCode = response.StatusCode,
            };
        }
    }
}
