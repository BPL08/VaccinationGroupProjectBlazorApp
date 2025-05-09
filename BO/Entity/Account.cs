﻿using System.ComponentModel.DataAnnotations;

namespace BO.Entity
{
    public class Account
    {
        [Key]
        public Guid AccountId { get; set; }
        public int? FKCenterId { get; set; }
        public VaccineCenter Center { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int PhoneNumber { get; set; }
        public string Email { get; set; }
        public string AccountRole { get; set; }
        public string? ProfileImage { get; set; }
  
        public string Status { get; set; }
    }

}
