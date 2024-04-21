using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities;

public class SubscriberEntity
{
	[Key]
	public string Email { get; set; } = null!;
	public bool DailyNewsletter { get; set; }
	public bool AdvertisingUpdates { get; set; }
	public bool WeekinReview { get; set; }
	public bool EventUpdates { get; set; }
	public bool StartupsWeekly { get; set; }
	public bool Podcasts { get; set; }

}
