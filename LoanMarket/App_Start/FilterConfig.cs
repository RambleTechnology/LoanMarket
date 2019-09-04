using LoanMarket.PublicClass;
using System.Web;
using System.Web.Mvc;

namespace LoanMarket
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            //filters.Add(new HandleErrorAttribute());
        }
    }

    /// <summary>
    /// 登录 过滤器
    /// </summary>
    public class IsLoginAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //base.OnActionExecuting(filterContext);
            PublicModels.User user = SessionTool.Get<PublicModels.User>("user");
            if (user == null)
            {
                filterContext.Result = new RedirectResult("/Me/Login");
            }
        }

    }





}
