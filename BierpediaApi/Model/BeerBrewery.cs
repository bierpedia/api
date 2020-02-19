
namespace Bierpedia.Api.Model {

	/// <summary>
 	/// Many-To-Many relationship between Beer and Brewery

	/// </summary>
	/// <remarks>
	/// EF Core does not support many-to-many relationships yet, see
	/// https://github.com/aspnet/EntityFrameworkCore/issues/1368
	/// /// </remarks>
	public class BeerBrewery {
		public int BeerId { get; set; }
		public virtual Beer Beer { get; set; }
		public int BreweryId { get; set; }
		public virtual Brewery Brewery { get; set; }
	}
}
