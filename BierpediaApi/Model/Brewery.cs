using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace Bierpedia.Api.Model {
	public class Brewery : Entity {

		public int CountryId { get; set; }

		public virtual Country Country { get; set; } = null!;

		public Brewery(string name, string slug, string description) : base(name, slug, description) { }
	}
}
