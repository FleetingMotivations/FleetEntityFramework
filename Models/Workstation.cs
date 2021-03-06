﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FleetEntityFramework.Models
{
    public class Workstation
    {
        [Key]
        public int WorkstationId { get; set; }

        public string FriendlyName { get; set; }

        [Required]
        [Column(TypeName ="VARCHAR")]
        [StringLength(100)]
        [Index(IsUnique = true )]
        public string WorkstationIdentifier { get; set; }

        public string IpAddress { get; set; }

        public string MacAddress { get; set; }

        // These are percentages
        public float TopXRoomOffset { get; set; }
        public float TopYRoomOffset { get; set; }
        public bool IsFacilitator { get; set; }
        public string Colour { get; set; }

        [Index]
        public int RoomId { get; set; }
        public virtual Room Room { get; set; }

        public DateTime? LastSeen { get; set; }

        public virtual ICollection<WorkgroupWorkstation> Workgroups { get; set; }
        public virtual ICollection<WorkstationLogin> Logins { get; set; }

        public virtual ICollection<WorkstationMessage> ReceivedMessages { get; set; }
        public virtual ICollection<Message> SentMessages { get; set; }
    }
}
