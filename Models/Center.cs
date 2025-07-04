﻿using System.ComponentModel.DataAnnotations.Schema;

namespace conectArte.Models
{
    public class Center
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public int PhoneNumber { get; set; }
        public int CoordinatorId {  get; set; }

        [ForeignKey("CoordinatorId")]
        public Coordinator Coordinator { get; set; }

        public Center()
        {
           
        }
    }
}
