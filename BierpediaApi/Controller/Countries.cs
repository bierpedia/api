using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Bierpedia.Api.Mapping;

namespace Bierpedia.Api.Controller {

	public class Countries : BeerpediaApiController {
		private readonly ApiContext apiContext;
		public Countries(ApiContext apiContext) {
			this.apiContext = apiContext;
		}
		
		[HttpGet]
		public async Task<ActionResult<IEnumerable<DTO.Country>>> Get() => 
			await apiContext.Countries.ToDTO(this.Url).ToListAsync();

		[HttpGet("{id}")]
		public async Task<ActionResult<DTO.Country>> Get(int id) {
			return await apiContext.Countries.Where(b => b.Id == id)
				.ToDTO(this.Url).SingleAsync();
		}
	}
}
