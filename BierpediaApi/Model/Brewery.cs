using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace Bierpedia.Api.Model {
	public class Brewery {
		public int Id { get; set; }
			
		[Required]
		public string Name { get; set; }

		[Required]
		public string Slug { get; set; }

		public int CountryId { get; set; }

		[Required]
		public virtual Country Country { get; set; }

	}
}
