using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Newtonsoft.Json;

namespace Bierpedia.Api.Model {
	
	public class Beer {
		
		public int Id { get; set; }

		[Required]
		public string Name { get; set; }

		[Required]
		public string Slug { get; set; }
		
		public string Description { get; set; }

		public decimal ABV { get; set; }

		public int ConcernId { get; set; }
		public virtual Concern Concern { get; set; }

		public virtual ICollection<BeerBrewery> BeerBreweries { get; set; }

		public virtual ICollection<BeerStyle> BeerStyles { get; set; }
	}
}
