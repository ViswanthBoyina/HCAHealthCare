﻿namespace StateHospital.Presentation.Models
{
    public class BaseModel
    {
        public string? CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public string? LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; } = DateTime.UtcNow;

    }
}
