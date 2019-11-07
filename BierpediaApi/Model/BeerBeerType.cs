namespace Bierpedia.Api.Model {

	/// <summary>
	/// 
	/// </summary>
	/// <remarks>
	/// EF Core does not support many-to-many relationships yet, see
	/// https://github.com/aspnet/EntityFrameworkCore/issues/1368
	/// /// </remarks>
	public class BeerBeerType {
		public int BeerId { get; set; }
		public Beer Beer { get; set; }
		public int BeerTypeId { get; set; }
		public BeerType BeerType { get; set; }
	}
}
