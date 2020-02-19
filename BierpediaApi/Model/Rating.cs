using System.ComponentModel.DataAnnotations;
using HotChocolate;

namespace Bierpedia.Api.Model {
	public class Rating {

		[GraphQLIgnore]
		[Key]
		public int Id { get; set; }

		public int BeerId { get; set; }
		public virtual Beer Beer { get; set; } = null!;

		public int Grade { get; set; }
		
	}
}
