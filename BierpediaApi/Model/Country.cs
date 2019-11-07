using System.ComponentModel.DataAnnotations;

namespace Bierpedia.Api.Model {
	public class Country {
		public int Id { get; set; }

		[Required]
		public string Name { get; set; }

		[Required]
		public string Slug { get; set; }
		
		public string Description { get; set; }
		
	}
}
