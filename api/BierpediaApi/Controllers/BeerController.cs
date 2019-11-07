using System.Collections.Generic;
using System.Threading.Tasks;
using Bierpedia.Api.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Bierpedia.Api {

	[ApiVersion("1.0")]
	[ApiController]
	[Route("api/v{version:apiVersion}/[controller]")]
	public class BeersController : ControllerBase {

		private readonly ApiContext apiContext;
		public BeersController(ApiContext apiContext) {
			this.apiContext = apiContext;
		}
		
		[HttpGet]
		public async Task<ActionResult<IEnumerable<Beer>>> ListBeers() => 
			await apiContext.Beers.ToListAsync();

		[HttpGet("{id}")]
		public async Task<ActionResult<Beer>> GetBeer(int id) =>
			await apiContext.Beers.FindAsync(id);
	}
}
