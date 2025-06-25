using System;
namespace conectArte.Models
{
	public class Tarea
	{
		private int id;
		private string titulo;

		public int Id { get { return this.id; } set { this.id = value; } }
        public string Titulo { get => titulo; set => titulo = value; }

        public Tarea()
		{
		}
	}
}

