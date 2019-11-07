using System.ComponentModel.DataAnnotations;

namespace Bierpedia.Api.Model {
	public class Brewery {
		public int Id { get; set; }
			
		[Required]
		public string Name { get; set; }

		[Required]
		public string Slug { get; set; }

		[Required]
		public Country Country { get; set; }
	}
}
