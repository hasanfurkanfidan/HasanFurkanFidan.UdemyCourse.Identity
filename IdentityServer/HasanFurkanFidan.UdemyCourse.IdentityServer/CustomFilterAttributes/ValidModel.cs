using HasanFurkanFidan.UdemyCourse.SHARED.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HasanFurkanFidan.UdemyCourse.IdentityServer.CustomFilterAttributes
{
    public class ValidModel: ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                var response = Response<NoContent>.Fail("Validasyonlar başarıyla geçilmedi", 404);

                context.Result = new ObjectResult(response)
                {
                    StatusCode = response.StatusCode,

                };
            }

        }
    }
}
