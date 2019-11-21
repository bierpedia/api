using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
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
				Slug = Slug,
				Name = Name,
				Description = Description,
				Breweries = this.BeerBreweries?.Select(bb => bb.Brewery.ToDTO(urlHelper)).ToList(),
				BeerTypes = this.BeerBeerTypes?.Select(bb => bb.BeerType.ToDTO(urlHelper)).ToList(),
				Links = new DTO.Beer.BeerLinks {
					Self = urlHelper.ActionLink((Controller.Beers b) => b.Get(this.Slug)),
					Breweries = urlHelper.ActionLink((Controller.Beers b) => b.Breweries(this.Slug)),
					BeerTypes = urlHelper.ActionLink((Controller.Beers b) => b.BeerTypes(this.Slug)),
				}
			};
		}
	}
}
