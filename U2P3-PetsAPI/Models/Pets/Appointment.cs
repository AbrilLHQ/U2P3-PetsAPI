using System;
using System.Collections.Generic;

namespace U2P3_PetsAPI.Models.Pets;

public partial class Appointment
{
    public int AppointmentId { get; set; }

    public int? PetId { get; set; }

    public int? VetId { get; set; }

    public DateTime? AppointmentDate { get; set; }

    public string? Reason { get; set; }

    public virtual Pet? Pet { get; set; }

    public virtual ICollection<Treatment> Treatments { get; set; } = new List<Treatment>();

    public virtual Veterinarian? Vet { get; set; }
}
