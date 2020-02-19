using System.ComponentModel.DataAnnotations;
using HotChocolate;

namespace Bierpedia.Api.Model {

	/// <summary>
	/// An entity that was navigatable in wordpress and therefore has a name, a url slug and a description
	/// </summary>
	public abstract class Entity  {
		
		/// <summary>
		/// Never expose internal IDs to the outside, e.g. in the graphql API
		/// </summary>
		[GraphQLIgnore]
		[Key]
		public int Id { get; set; }
		
		public string Name { get; set; }

		public string Slug { get; set; }
		
		public string Description { get; set; } 

		public Entity(string name, string slug, string description) {
			this.Name = name;
			this.Slug = slug;
			this.Description = description;
		}
	}
}
