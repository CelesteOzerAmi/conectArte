﻿namespace conectArte.Models
{
    public class Resource
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Stock { get; set; }

        public List<ResourceRoom> ResourcesRooms { get; set; }
        public Resource()
        {

        }
    }
}
