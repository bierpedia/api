namespace Bierpedia.Api.Model {

	/// <summary>
	/// 
	/// </summary>
	/// <remarks>
	/// EF Core does not support many-to-many relationships yet, see
	/// https://github.com/aspnet/EntityFrameworkCore/issues/1368
	/// /// </remarks>
	public class BeerBrewery {
		public int BeerId { get; set; }
		public Beer Beer { get; set; }
		public int BreweryId { get; set; }
		public Brewery Brewery { get; set; }
	}
}
