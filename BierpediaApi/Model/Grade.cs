namespace Bierpedia.Api.Model {
	public class Rating {
		public int Id { get; set; }

		public virtual Beer Beer { get; set; }

		public int Grade { get; set; }
		
	}
}
