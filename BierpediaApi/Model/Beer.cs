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
					Self = urlHelper.GetPathByControllerAction<Controller.Beers>(nameof(Controller.Beers.Get), 
						values: new { id = this.Id }),
					Breweries = urlHelper.GetPathByControllerAction<Controller.Beers>(nameof(Controller.Beers.Breweries), 
						values: new { id = this.Id }),
					BeerTypes = urlHelper.GetPathByControllerAction<Controller.Beers>(nameof(Controller.Beers.BeerTypes), 
						values: new { id = this.Id }),
				}
			};
		}
	}
}
