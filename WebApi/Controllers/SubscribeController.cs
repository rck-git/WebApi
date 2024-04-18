using Infrastructure.Contexts;
using Infrastructure.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using WebApi.Models;

namespace WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class SubscribeController : ControllerBase
	{
		private readonly DataContexts _context;
		public SubscribeController(DataContexts context)
		{
			_context = context;
		}

		private static List<SubscriberModel> _subscribers = new List<SubscriberModel>
		{
			new SubscriberModel {Email = "firstEmail@email.com"},
			new SubscriberModel {Email = "2ndEmail@email.com"}
		};

		//Create
		[HttpPost]
		public async Task<IActionResult> Subscribe(SubscriberRequestModel subscriber)
		{
			try
			{
				if (ModelState.IsValid)
				{
					if (!await _context.Subscribers.AnyAsync(x => x.Email == subscriber.Email))
					{
						var subscriberEntity = new SubscriberEntity { Email = subscriber.Email };
						_context.Subscribers.Add(subscriberEntity);
						await _context.SaveChangesAsync();

						return Created();
					}
					return Conflict("There is already  a subscription for this email address");
				}
				return BadRequest();

			}
			catch (Exception ex)
			{
				return Problem("unable to subscribe " + ex.Message);
			}
		}

		[HttpDelete]
		public async Task<IActionResult> Unsubscribe(string email)
		{
			try
			{
				if (ModelState.IsValid)
				{
					var subscriber = await _context.Subscribers.FirstOrDefaultAsync(x => x.Email == email);

					if (subscriber != null)
					{
						_context.Subscribers.Remove(subscriber);
						_context.SaveChanges();
						return Ok();
					}
					return NotFound();
				}
				return BadRequest();
			}
			catch (Exception ex)
			{
				return Problem("unable to subscribe " + ex.Message);
			}
		}


		//Read
		[HttpGet]
		public async Task<IActionResult> GetAllSubscribers()
		{
			var subscriberList = await _context.Subscribers.ToListAsync();
			if (subscriberList.Count != 0)
			{
				return Ok(subscriberList);
			}
			return NotFound();

		}



		//[HttpGet("{id}")]
		//public async Task<IActionResult> GetOneSubscriber(int id)
		//{
		//	var subscriber = await _context.Subscribers.FirstOrDefaultAsync(x => x.Id == id);
		//          if (subscriber != null) 
		//	{
		//		return Ok(subscriber);

		//	}
		//	return NotFound();
		//}



		//[HttpPut("{id}")]
		//public async Task<IActionResult> UpdateSubscriber(int id,string email)
		//{
		//	var subscriber = await _context.Subscribers.FirstOrDefaultAsync(x => x.Id == id);

		//	if (subscriber != null)
		//	{
		//		subscriber.Email = email;
		//		_context.Subscribers.Update(subscriber);

		//		//_context.Entry(subscriber).CurrentValues.SetValues(email);

		//		_context.SaveChanges();
		//		return Ok(subscriber);
		//	}
		//	return NotFound();
		//}

	}
}
