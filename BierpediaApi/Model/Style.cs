using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace Bierpedia.Api.Model {
	public class Style {
		public int Id { get; set; }
		
		[Required]
		public string Name { get; set; }

		[Required]
		public string Slug { get; set; }
		
		[Required]
		public string Description { get; set; }

		public int? ParentId { get; set; }
		
		public virtual Style Parent { get; set; }
	}
}
