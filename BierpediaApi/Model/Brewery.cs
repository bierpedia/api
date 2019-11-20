using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace Bierpedia.Api.Model {
	public class Brewery : IDTOMappable<DTO.Brewery> {
		public int Id { get; set; }
			
		[Required]
		public string Name { get; set; }

		[Required]
		public string Slug { get; set; }

		public int CountryId { get; set; }

		[Required]
		public virtual Country Country { get; set; }

		public DTO.Brewery ToDTO(IUrlHelper urlHelper) {
			return new DTO.Brewery {
				Id = Id,
				Name = Name,
				_Links = new DTO.Brewery.Links {
					Self = urlHelper.ActionLink((Controller.Breweries b) => b.Get(this.Slug)),
					Country = urlHelper.ActionLink((Controller.Countries b) => b.Get(this.Country.Slug)),
				}
			};
		}
	}
}
