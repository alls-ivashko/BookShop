using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class OrderDetail
    {
        public int CartId { get; set; }
        public DateTime RegistrationTime { get; set; }
        public bool Pickup { get; set; }
        public int? DeliveryZipCode { get; set; }
        public string? DeliveryRegion { get; set; }
        public string? DeliveryCity { get; set; }
        public string? DeliveryStreet { get; set; }
        public int? DeliveryHouse { get; set; }
        public int? DeliveryFlat { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public decimal? DeliveryPrice { get; set; }
        public DateTime? CompletionTime { get; set; }
        public string PaymentType { get; set; } = null!;
        public bool Payed { get; set; }
        public string Status { get; set; } = null!;
        public bool Deleted { get; set; }

        public virtual Cart Cart { get; set; } = null!;
    }
}
