
namespace Bierpedia.Api.Model {

	/// <summary>
	/// Many-To-Many relationship between Beer and Style
	/// </summary>
	/// <remarks>
	/// EF Core does not support many-to-many relationships yet, see
	/// https://github.com/aspnet/EntityFrameworkCore/issues/1368
	/// </remarks>
	public class BeerStyle {
		public int BeerId { get; set; }
		public virtual Beer Beer { get; set; }
		public int StyleId { get; set; }
		
		public virtual Style Style { get; set; }
	}
}
