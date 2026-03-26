using System;
using System.Collections.Generic;

namespace U2P3_PetsAPI.Models.Pets;

public partial class Treatment
{
    public int TreatmentId { get; set; }

    public int? AppointmentId { get; set; }

    public string? Description { get; set; }

    public decimal? Cost { get; set; }

    public virtual Appointment? Appointment { get; set; }
}
