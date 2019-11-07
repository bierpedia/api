using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Bierpedia.Api.Model {
	
	public class Beer {
		public int Id { get; set; }

		[Required]
		public string Name { get; set; }

		[Required]
		public string Slug { get; set; }
		
		public virtual ICollection<BeerBrewery> BeerBreweries { get; set; }

		public virtual ICollection<BeerBeerType> BeerBeerTypes { get; set; }

		public string Description { get; set; }
	}
}
