using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Contexts;

public class DataContexts : DbContext
{
	public DataContexts(DbContextOptions<DataContexts> options) : base(options)
	{
	}


	public DbSet<SubscriberEntity> Subscribers { get; set; }
	public DbSet<CourseEntity> Courses { get; set; }
}
