using System.Linq;
using System.Web.Http;

namespace Boilerplate
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();

            //Disable XML support, rmove as needed.
            var appXmlType = config.Formatters.XmlFormatter.SupportedMediaTypes.FirstOrDefault(m => m.MediaType == "application/xml");
            config.Formatters.XmlFormatter.SupportedMediaTypes.Remove(appXmlType);
        }
    }
}