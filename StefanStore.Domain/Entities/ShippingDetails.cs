﻿using System.ComponentModel.DataAnnotations;

namespace StefanStore.Domain.Entities
{
    public class ShippingDetails
    {
        public string Name { get; set; }


        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string Line3 { get; set; }


        public string City { get; set; }


        public string State { get; set; }

        public string Zip { get; set; }


        public string Country { get; set; }

        public bool FastDelivery { get; set; }
    }
}
