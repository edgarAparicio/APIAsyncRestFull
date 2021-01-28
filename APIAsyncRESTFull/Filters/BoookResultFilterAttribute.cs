using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIAsyncRESTFull.Filters
{
    public class BoookResultFilterAttribute : ResultFilterAttribute
    {
        public override async Task ResultadoEjecucionAsync(ResultExecutingContext contexto, ResultExecutionDelegate siguiente)
        {
            var resultado = contexto.Result as ObjectResult;
            if (resultado?.Value == null || resultado.StatusCode < 200 || resultado.StatusCode >= 300)
            {
                await siguiente();
                return;
            }
            await siguiente();
        }
    }
}
