﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SPbSU.VK.TimeTable.IRepositories;
using SPbSU.VK.TimeTable.IServices;
using SPbSU.VK.TimeTable.Repositories;
using SPbSU.VK.TimeTable.Services;

namespace SPbSU.VK.TimeTable
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			var connection = Configuration.GetConnectionString("DefaultConnection");
			services.AddDbContext<VkTimeTableContext>(options => options.UseSqlServer(connection));
			services.AddScoped<ICalendarRepository, CalendarRepository>();
			services.AddScoped<IUserRepository, UserRepository>();
			services.AddScoped<IUserCalendarRepository, UserCalendarRepository>();
			services.AddScoped<IEventRepository, EventRepository>();
			services.AddSingleton<ICalendarService, CalendarService>();

			services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseMvc();
		}
	}
}
