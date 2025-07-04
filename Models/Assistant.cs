using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace conectArte.Models
{
    public class Assistant
    {
        [Key]
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Type { get; set; } // child, teen, adult
        public string Email { get; set; }
        public string Phone { get; set; }

        // Associated center
        public int CenterId { get; set; }
        [ForeignKey("CenterId")]
        public Center Center { get; set; }

        // Workshops attended
        public List<WorkshopAssistant> WorkshopsAttended { get; set; }

        public Assistant()
        {
            WorkshopsAttended = new List<WorkshopAssistant>();
        }
    }
} 