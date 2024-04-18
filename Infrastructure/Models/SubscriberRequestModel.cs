using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebApi.Models;

public class SubscriberRequestModel
{
	[Required]
	[EmailAddress]
	[Display(Name = "Subscribe",Prompt ="Enter your email adress.")]
	public string Email { get; set; } = null!;
}
