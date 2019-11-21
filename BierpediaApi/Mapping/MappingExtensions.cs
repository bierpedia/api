using System.Collections.Generic;
using System.Linq;
using Bierpedia.Api.Controller;
using Bierpedia.Api.Model;
using Microsoft.AspNetCore.Mvc;

namespace Bierpedia.Api.Mapping {

	/// <summary>
	/// Extension methods for mapping database entities to data-transfer-objects (DTO)
	/// </summary>
	public static class MappingExtensions {

		/// <summary>
		/// Map <see cref="IQueryable{IDTOMappable{T}}" /> to their DTO
		/// </summary>
		public static IQueryable<T> ToDTO<T>(this IQueryable<IDTOMappable<T>> queryable, IUrlHelper urlHelper) where T : DTO.DTOBase {
			return queryable.Select(q => q.ToDTO(urlHelper));
		}
	}
}
