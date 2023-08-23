using Microsoft.AspNetCore.Mvc;

namespace Nox.ClientApi.Tests.Tests
{
    public static class ActionResultExtensions
    {
        public static T ExtractResult<T>(this ActionResult<T> actionResult)
        {
            var mvcResult = (ObjectResult)actionResult.Result!;
            return (T)mvcResult.Value!;
        }
    }
}
