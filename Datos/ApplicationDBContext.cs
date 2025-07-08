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


		public DbSet<Teacher> Teachers { get; set; }

		public DbSet<Coordinator> Coordinators { get; set; }

		public DbSet<Center> Centers { get; set; }

        public DbSet<Resource> Resources { get; set; }

		public DbSet<Room> Rooms { get; set; }
        public DbSet<ResourceRoom> ResourceRooms { get; set; }

        public DbSet<Workshop> Workshops { get; set; }
        public DbSet<WorkshopAssistant> WorkshopAssistants { get; set; }
        public DbSet<Assistant> Assistants { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ResourceRoom>()
                .HasKey(pt => new { pt.ResourceId, pt.RoomName });

            modelBuilder.Entity<ResourceRoom>()
                .HasOne(pt => pt.AssignedResource)
                .WithMany(p => p.ResourcesRooms)
                .HasForeignKey(pt => pt.ResourceId);

            modelBuilder.Entity<ResourceRoom>()
                .HasOne(pt => pt.AssignedRoom)
                .WithMany(t => t.ResourcesRooms)
                .HasForeignKey(pt => pt.RoomName);

            modelBuilder.Entity<WorkshopAssistant>()
                .HasKey(wa => new { wa.WorkshopId, wa.AssistantId });

            modelBuilder.Entity<WorkshopAssistant>()
                .HasOne(wa => wa.Workshop)
                .WithMany(w => w.WorkshopAssistants)
                .HasForeignKey(wa => wa.WorkshopId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<WorkshopAssistant>()
                .HasOne(wa => wa.Assistant)
                .WithMany(w => w.WorkshopsAttended)
                .HasForeignKey(wa => wa.AssistantId)
                .OnDelete(DeleteBehavior.Restrict);
        }

    }
}

