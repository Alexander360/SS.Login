﻿using System.Web.UI.HtmlControls;
using SiteServer.Plugin;

namespace SS.Login.Core.Parse
{
    public class StlRegister
    {
        private StlRegister() { }
        public const string ElementName = "stl:register";

        public static string Parse(IParseContext context)
        {
            ParseUtils.RegisterBodyHtml(context);

            var stlAnchor = new HtmlAnchor();

            foreach (var name in context.StlAttributes.AllKeys)
            {
                var value = context.StlAttributes[name];
                stlAnchor.Attributes.Add(name, value);
            }

            stlAnchor.InnerHtml = Context.ParseApi.Parse(context.StlInnerHtml, context);
            stlAnchor.HRef = "javascript:;";
            stlAnchor.Attributes.Add("onclick", ParseUtils.OnClickRegister);

            return Utils.GetControlRenderHtml(stlAnchor);
        }

        //public static object Register(IRequest request)
        //{
        //    var userName = request.GetPostString("userName");
        //    var displayName = request.GetPostString("displayName");
        //    var email = request.GetPostString("email");
        //    var mobile = request.GetPostString("mobile");
        //    var password = request.GetPostString("password");

        //    var userInfo = Context.UserApi.NewInstance();
        //    userInfo.UserName = userName;
        //    userInfo.DisplayName = displayName;
        //    userInfo.Email = email;
        //    userInfo.Mobile = mobile;

        //    string errorMessage;
        //    if (!Context.UserApi.Insert(userInfo, password, out errorMessage))
        //    {
        //        throw new Exception(errorMessage);
        //    }

        //    return new object();
        //}
    }
}