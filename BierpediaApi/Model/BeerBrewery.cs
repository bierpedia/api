using Newtonsoft.Json;

namespace Bierpedia.Api.Model {

	/// <summary>
	/// 
	/// </summary>
	/// <remarks>
	/// EF Core does not support many-to-many relationships yet, see
	/// https://github.com/aspnet/EntityFrameworkCore/issues/1368
	/// /// </remarks>
	public class BeerBrewery {
		[JsonIgnore]
		public int BeerId { get; set; }
		[JsonIgnore]
		public virtual Beer Beer { get; set; }
		[JsonIgnore]
		public int BreweryId { get; set; }
		public virtual Brewery Brewery { get; set; }
	}
}
