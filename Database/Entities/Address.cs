﻿namespace FinalExamBE.Database.Entities
{
    public class Address
    {
        public Guid Id { get; set; }
        public string City { get; set; }
        public string StreetName { get; set; }
        public string BuildingNumber { get; set; }
        public string? ApartmentNumber { get; set; }
    }
}
