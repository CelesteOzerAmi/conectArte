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
	}
}

