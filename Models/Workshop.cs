using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace conectArte.Models
{
    public class Workshop
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; } // art, music, theater, technology, etc.
        public int MaxCapacity { get; set; }
        public double AverageRating { get; set; } // Calculated

        // Relation with Teacher
        public int TeacherId { get; set; }
        [ForeignKey("TeacherId")]
        public Teacher Teacher { get; set; }

        // Relation with Room
        public string RoomName { get; set; }
        [ForeignKey("RoomName")]
        public Room Room { get; set; }

        // Relation with assistants (many to many with rating)
        public List<WorkshopAssistant> WorkshopAssistants { get; set; }

        public Workshop()
        {
            WorkshopAssistants = new List<WorkshopAssistant>();
        }
    }
} 