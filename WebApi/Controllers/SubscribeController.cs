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

		
		//Create
		[HttpPost]
		public async Task<IActionResult> Subscribe(SubscriberEntity subscriber)
		{
			try
			{
				if (ModelState.IsValid)
				{
					if (!await _context.Subscribers.AnyAsync(x => x.Email == subscriber.Email))
					{
						_context.Subscribers.Add(subscriber);
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


	}
}
