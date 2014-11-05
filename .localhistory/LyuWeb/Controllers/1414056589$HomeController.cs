using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LyuWeb.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
           // DoesTypeImplementOpenGeneric()
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        private  bool DoesTypeImplementOpenGeneric(Type type, Type openGeneric)
        {
            try
            {
                var genericTypeDefinition = openGeneric.GetGenericTypeDefinition();
                foreach (var implementedInterface in type.FindInterfaces((objType, objCriteria) => true, null))
                {
                    if (!implementedInterface.IsGenericType)
                        continue;

                    var isMatch = genericTypeDefinition.IsAssignableFrom(implementedInterface.GetGenericTypeDefinition());
                    return isMatch;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}