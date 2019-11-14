using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Bierpedia.Api.Mapping;
using Microsoft.AspNetCore.Routing;

namespace Bierpedia.Api.Controller {
	public class Beers : BeerpediaApiController {
		private readonly ApiContext apiContext;
		private readonly LinkGenerator linkGenerator;
		public Beers(ApiContext apiContext, LinkGenerator linkGenerator) {
			this.apiContext = apiContext;
			this.linkGenerator = linkGenerator;
		}
		
		[HttpGet]
		public async Task<ActionResult<IEnumerable<DTO.Beer>>> List() =>
			await apiContext.Beers.ToDTO(this.Url).ToListAsync();

		[HttpGet("{id}")]
		public async Task<ActionResult<DTO.Beer>> Get(int id) {
			return await apiContext.Beers.Where(b => b.Id == id)
				.ToDTO(this.Url)
				.SingleAsync();
		}

		[HttpGet("{id}/breweries")]
		public async Task<ActionResult<IEnumerable<DTO.Brewery>>> Breweries(int id) =>
			 await apiContext.Beers
				.Include(beer => beer.BeerBreweries)
				.ThenInclude(bb => bb.Brewery)
				.Where(beer => beer.Id == id)
				.SelectMany(beer => beer.BeerBreweries)
				.Select(bb => bb.Brewery)
				.ToDTO(this.Url)
				.ToListAsync();

		[HttpGet("{id}/beerTypes")]
		public async Task<ActionResult<IEnumerable<DTO.BeerType>>> BeerTypes(int id) =>
			 await apiContext.Beers
				.Include(beer => beer.BeerBeerTypes)
				.ThenInclude(bb => bb.BeerType)
				.Where(beer => beer.Id == id)
				.SelectMany(beer => beer.BeerBeerTypes)
				.Select(bb => bb.BeerType)
				.ToDTO(this.Url)
				.ToListAsync();
	}
}
