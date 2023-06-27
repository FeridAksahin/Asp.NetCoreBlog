using Blog.AdminPanel.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace ProgrammersBlog.Mvc.Filters
{
    public class ExceptionFilter : IExceptionFilter
    {
        private readonly IHostEnvironment _environment;
        private readonly IModelMetadataProvider _modelMetadataProvider;

        public ExceptionFilter(IModelMetadataProvider modelMetadataProvider, IHostEnvironment environment)
        {
            _modelMetadataProvider = modelMetadataProvider;
            _environment = environment;
        }

        public void OnException(ExceptionContext context)
        {
            if (_environment.IsDevelopment())
            {
                context.ExceptionHandled = true;
                //var mvcErrorModel = new ErrorModel();
                //switch (context.Exception)
                //{
                //    case SqlNullValueException:
                //        mvcErrorModel.Message = ".";
                //        mvcErrorModel.Detail = context.Exception.Message;
                //        break;
                //    case NullReferenceException:
                //        mvcErrorModel.Message = ".";
                //        mvcErrorModel.Detail = context.Exception.Message;
                //        break;
                //    default:
                //        mvcErrorModel.Message = $".";
                //        break;
                //}

                var result = new ViewResult() { ViewName = "Error" };
                //result.StatusCode = 404;
                //result.ViewData = new ViewDataDictionary(_modelMetadataProvider, context.ModelState);
                //result.ViewData.Add("MvcErrorModel", mvcErrorModel);
                context.Result = result;
            }
        }
    }
}
