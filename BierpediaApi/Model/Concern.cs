using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace Bierpedia.Api.Model {
	public class Concern : Entity {
		
		public virtual List<Beer> Beers { get; set; } = null!;

		public Concern(string name, string slug, string description) : base(name, slug, description) { }
	}
}
