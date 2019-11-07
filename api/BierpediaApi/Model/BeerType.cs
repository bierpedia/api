using System.ComponentModel.DataAnnotations;

namespace Bierpedia.Api.Model {
	public class BeerType {
		public int Id { get; set; }
		
		[Required]
		public string Name { get; set; }

		[Required]
		public string Slug { get; set; }
		
		[Required]
		public string Description { get; set; }

		public BeerType Parent { get; set; }
	}
}
