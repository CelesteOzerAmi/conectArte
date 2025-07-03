using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace conectArte.Models
{
    public class Room
    {
        [Key]
        public string Name { get; set; }
        public int Capacity { get; set; }
        public int CenterId { get; set; }

        [ForeignKey("CenterId")]
        public Center Center { get; set; }

        public List<ResourceRoom> ResourcesRooms { get; set; }

        [NotMapped]
        public List<int> ResourcesIds { get; set; }

        public Room()
        {

        }

    }
}
