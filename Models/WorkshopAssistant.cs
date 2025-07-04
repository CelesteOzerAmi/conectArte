using System.ComponentModel.DataAnnotations.Schema;

namespace conectArte.Models
{
    public class WorkshopAssistant
    {
        public int WorkshopId { get; set; }
        [ForeignKey("WorkshopId")]
        public Workshop Workshop { get; set; }

        public int AssistantId { get; set; }
        [ForeignKey("AssistantId")]
        public Assistant Assistant { get; set; }

        public double Rating { get; set; }
    }
} 