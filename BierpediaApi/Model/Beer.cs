using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Newtonsoft.Json;

namespace Bierpedia.Api.Model {
	
	public class Beer : IDTOMappable<DTO.Beer> {
		
		public int Id { get; set; }

		[Required]
		public string Name { get; set; }

		[Required]
		public string Slug { get; set; }
		
		public virtual ICollection<BeerBrewery> BeerBreweries { get; set; }

		public virtual ICollection<BeerBeerType> BeerBeerTypes { get; set; }

		public string Description { get; set; }

		public DTO.Beer ToDTO(IUrlHelper urlHelper) {
			
			return new DTO.Beer {
				Id = Id,
				Name = Name,
				Description = Description,
				_Links = new DTO.Beer.Links {
					Self = urlHelper.ActionLink((Controller.Beers b) => b.Get(this.Id)),
					Breweries = urlHelper.ActionLink((Controller.Beers b) => b.Breweries(this.Id)),
					BeerTypes = urlHelper.ActionLink((Controller.Beers b) => b.BeerTypes(this.Id)),
				}
			};
		}
	}
}
