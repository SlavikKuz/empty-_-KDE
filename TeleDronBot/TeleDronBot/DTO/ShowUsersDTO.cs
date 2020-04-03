﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TeleDronBot.DTO
{
    class ShowUsersDTO
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("UserDTO")]
        public long ChatId { get; set; }
        public int MessageId { get; set; }
        public int CurrentId { get; set; }
        public string Region { get; set; }
    }
}
