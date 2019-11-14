using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace Bierpedia.Api.Model {
	public interface IDTOMappable<T> where T : DTO.DTOBase {
		T ToDTO(IUrlHelper urlHelper);
	}
}
