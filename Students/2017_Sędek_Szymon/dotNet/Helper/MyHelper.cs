using System;
using System.Linq.Expressions;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using dotNet.Models.User;


namespace dotNet.Helper
{
    public static class MyHelper
    {
        //public static MvcHtmlString TextFormat(Expression<Func<RoleViewModel, string>> expression)
        //{
        //    Func <RoleViewModel, string> compiledDelegate = expression.Compile();

        //    var html = " <tr><th>" + compiledDelegate.Invoke(new RoleViewModel()) +"</th></tr>";
        //    return MvcHtmlString.Create(html);
        //}
        public static MvcHtmlString TextFormatBegin()
        {
            const string html = " <tr><th>";
            return MvcHtmlString.Create(html);
        }
        public static MvcHtmlString TextFormatEnd()
        {
            const string html = " </th></tr>";
            return MvcHtmlString.Create(html);
        }

    }
}