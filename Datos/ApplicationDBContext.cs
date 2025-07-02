using System;
using Microsoft.EntityFrameworkCore;
using conectArte.Models;

namespace conectArte.Datos
{
	public class ApplicationDBContext: DbContext
	{
		public ApplicationDBContext(DbContextOptions<ApplicationDBContext> opciones): base(opciones)
		{
		}

		public DbSet<Tarea> Tareas { get; set; }

		public DbSet<Teacher> Teachers { get; set; }

		public DbSet<Coordinator> Coordinators { get; set; }

		public DbSet<Center> Centers { get; set; }

        public DbSet<Resource> Resources { get; set; }

    }
}

