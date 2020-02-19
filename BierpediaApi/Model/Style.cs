
namespace Bierpedia.Api.Model {
	public class Style : Entity {

		public int? ParentId { get; set; }

		public virtual Style? Parent { get; set; }

		public Style(string name, string slug, string description) : base(name, slug, description) { } 
	}
}
