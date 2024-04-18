namespace WebApi.Models
{
	public class SubscriberModel
	{
		public string Id { get; set; } = Guid.NewGuid().ToString();
		public string Email { get; set; } = null!;
	}
}
