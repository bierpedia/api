using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace Bierpedia.Api {
	public static class UrlHelperExtensions {
		public static string GetPathByControllerAction<T>(this IUrlHelper urlHelper, string action, object values = null) where T : ControllerBase {
			var valuesDict = new RouteValueDictionary(values);
			// Take the API version from the request if not speficied
			if (!valuesDict.ContainsKey("version")) {
				valuesDict["version"] = urlHelper.ActionContext.RouteData.Values["version"];
			}
		 	return urlHelper.ActionLink(controller: typeof(T).Name, action: action, values: valuesDict);
		}
	}
}
