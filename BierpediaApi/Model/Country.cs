using System.Collections.Generic;

namespace Bierpedia.Api.Model {
	public class Country : Entity {

		public virtual List<Brewery> Breweries { get; set; } = null!;
		
		public Country(string name, string slug, string description) : base(name, slug, description) { }
	}
}
