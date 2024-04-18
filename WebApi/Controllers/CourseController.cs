using Infrastructure.Contexts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Controllers;


[Route("api/[controller]")]
[ApiController]

public class CourseController : ControllerBase
{
	private readonly DataContexts _context;
	public CourseController(DataContexts context)
	{
		_context = context;
	}


	[HttpGet]
	public async Task<IActionResult> GetAllCourses()
	{
		try
		{
			var courseList = await _context.Courses.ToListAsync();
			if (courseList.Count != 0)
			{
				return Ok(courseList);
			}
			return NotFound();
		}
		catch (Exception ex)
		{
			return Problem("unable to subscribe " + ex.Message);
		}

	}

	[HttpGet("{id}")]
	public async Task<IActionResult> GetOneCourse(int id)
	{
		var course = await _context.Courses.FirstOrDefaultAsync(x => x.Id == id);
		if (course != null)
		{
			return Ok(course);

		}
		return NotFound();
	}
}
