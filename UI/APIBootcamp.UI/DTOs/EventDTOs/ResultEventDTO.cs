﻿namespace APIBootcamp.UI.DTOs.EventDTOs
{
    public class ResultEventDTO
    {
        public int Id { get; set; }
        public string YummyEventTitle { get; set; }
        public string YummyEventDescription { get; set; }
        public string YummyEventImageURL { get; set; }
        public decimal YummyEventPrice { get; set; }
        public bool YummyEventStatus { get; set; }

    }
}
