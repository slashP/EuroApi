using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EuroApi.Context;

namespace EuroApi.Controllers
{
    public class BaseController : Controller
    {
        private readonly FootyFeudContext _db = new FootyFeudContext();
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if(!User.Identity.IsAuthenticated)
            {
                base.OnActionExecuting(filterContext);
                return;
            }
            var user = _db.Users.FirstOrDefault(x => x.Username == User.Identity.Name);
            var guestbookCount = _db.Guestbooks.Count();
            if (user != null) ViewBag.GuestbookCountNotRead = guestbookCount - (user.GuestbookCount ?? 0);
            base.OnActionExecuting(filterContext);
        }
    }
}
