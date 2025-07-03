using System.ComponentModel.DataAnnotations.Schema;

namespace conectArte.Models
{
    public class ResourceRoom
    {
        public int ResourceId { get; set; }

        [ForeignKey("ResourceId")]
        public Resource AssignedResource { get; set; }

        public string RoomName { get; set; }

        [ForeignKey("RoomName")]
        public Room AssignedRoom { get; set; }

        public int ResourceCount { get; set; }

        public ResourceRoom()
        {

        }

    }
}
