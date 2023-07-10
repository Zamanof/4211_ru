using Microsoft.AspNetCore.Mvc.Filters;

namespace Filters_.Filters
{
    public class DateTimeExecAttribute : Attribute, IResultFilter
    {
        public void OnResultExecuted(ResultExecutedContext context)
        {}

        public void OnResultExecuting(ResultExecutingContext context)
        {
            context
                .HttpContext
                .Response
                .Headers
                .Add("DateTime", DateTime.Now.ToString("ddd-dd-MMM-yyyy"));
        }
    }
}
