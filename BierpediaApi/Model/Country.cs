using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace Bierpedia.Api.Model {
	public class Country : IDTOMappable<DTO.Country> {
		public int Id { get; set; }

		[Required]
		public string Name { get; set; }

		[Required]
		public string Slug { get; set; }
		
		public string Description { get; set; }
		
		public DTO.Country ToDTO(IUrlHelper urlHelper) {
			
			return new DTO.Country {
				Id = Id,
				Name = Name,
				Description = Description,
				_Links = new DTO.BeerType.Links {
					Self = urlHelper.ActionLink((Controller.Countries b) => b.Get(this.Slug)),
				}
			};
		}
	}
}
