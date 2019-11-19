using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using MiaPlaza.ExpressionUtils.Evaluating;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace Bierpedia.Api {
	public static class UrlHelperExtensions {

	/// <summary>
	/// Strongly typed link generation. The action is passed as lamda.
	/// </summary>
	public static string ActionLink<TController, T>(this IUrlHelper urlHelper, Expression<Func<TController, T>> d) where TController : ControllerBase {
			var methodCallExpression = (MethodCallExpression)d.Body;
			var methodInfo = methodCallExpression.Method;

			var values = new Dictionary<string, object>();
			// Take the API version from the request
			values.Add("version", urlHelper.ActionContext.RouteData.Values["version"]);
			
			var argNames = methodInfo.GetParameters();
			for(int i = 0; i < argNames.Length; i++) {
				values.Add(argNames[i].Name, evaluate(methodCallExpression.Arguments[i]));
			}
			
			return urlHelper.ActionLink(controller: typeof(TController).Name, action: methodInfo.Name, values: values);
		}

		private static object evaluate(Expression e) {
			return ((IExpressionEvaluator)CachedExpressionCompiler.Instance).Evaluate(e);
		}
	}
}
