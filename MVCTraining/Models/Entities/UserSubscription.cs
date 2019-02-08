using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVCTraining.Models.Entities
{
    public class UserSubscription
    {
        [Required]
        [Key, Column(Order = 1)]
        public int SubscriptionId { get; set; }

        [Required]
        [Key, Column(Order = 2)]
        [MaxLength(128)]
        public string UserId { get; set; }

        public DateTime? startDate { get; set; }
        public DateTime? endDate { get; set; }

    }
}