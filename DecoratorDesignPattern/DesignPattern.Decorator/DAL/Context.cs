﻿using Microsoft.EntityFrameworkCore;

namespace DesignPattern.Decorator.DAL
{
	public class Context:DbContext
	{
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer("server=DESKTOP-3OD251U\\SQLEXPRESS;initial catalog=DesignPattern11;integrated security=true;");
		}

		public DbSet<Message> Messages { get; set; }
		public DbSet<Notifier> Notifiers { get; set; }
	}
}
