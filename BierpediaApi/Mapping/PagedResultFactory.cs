using System.Collections.Generic;
using System.Linq;
using Bierpedia.Api.Controller;
using Bierpedia.Api.Model;
using Microsoft.AspNetCore.Mvc;

namespace Bierpedia.Api.Mapping {

	public static class PagedResultFactory {

		public static DTO.PagedResult<T> Create<T>(int page, int perPage, int total, List<T> result, IUrlHelper urlHelper) where T : DTO.DTOBase {
			int totalPages = total/perPage;

			return new DTO.PagedResult<T>{
				Page = page,
				PerPage = perPage,
				Total = total,
				TotalPages = totalPages,
				Result = result,
				Links = new DTO.PagedResult<T>.PageLinks{
					Previous = page > 1 ? urlHelper.ActionLink((Beers b) => b.List(page-1, perPage)) : null,
					Next = page < totalPages ? urlHelper.ActionLink((Beers b) => b.List(page+1, perPage)) : null,
					First = urlHelper.ActionLink((Beers b) => b.List(1, perPage)),
					Last = urlHelper.ActionLink((Beers b) => b.List(totalPages, perPage)),
				},
			};
		}
	}
}
