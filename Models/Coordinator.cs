namespace conectArte.Models
{
    public class Coordinator
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int PhoneNumber { get; set; }    
        public List<Center> AssignedCenters { get; set; }

        public Coordinator()
        {
            AssignedCenters = new List<Center>();
        }
    }
}
