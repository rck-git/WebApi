﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities;

public class CourseEntity
{
	public int Id { get; set; }
	public string Title { get; set; }
	public string? Price { get; set; }
	public string? DiscountPrice { get; set; }
	public string? Hours { get; set; }
	public bool IsBestseller { get; set; }
	public string? LikesInNumbers { get; set; }
	public string? LikesInProcent { get; set; }
	public string? Author { get; set; }
	public string Image { get; set; } = null!;
}
