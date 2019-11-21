using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace Bierpedia.Api.Model {
	public class BeerType : IDTOMappable<DTO.BeerType> {
		public int Id { get; set; }
		
		[Required]
		public string Name { get; set; }

		[Required]
		public string Slug { get; set; }
		
		[Required]
		public string Description { get; set; }

		public int? ParentId { get; set; }
		public virtual BeerType Parent { get; set; }

		public DTO.BeerType ToDTO(IUrlHelper urlHelper) {
			
			return new DTO.BeerType {
				Slug = Slug,
				Name = Name,
				Description = Description,
				Links = new DTO.BeerType.BeerTypeLinks {
					Self = urlHelper.ActionLink((Controller.BeerTypes b) => b.Get(this.Slug)),
					Parent = this.ParentId.HasValue ? urlHelper.ActionLink((Controller.BeerTypes b) => b.Get(this.Parent.Slug)) : null
				}
			};
		}
	}
}
