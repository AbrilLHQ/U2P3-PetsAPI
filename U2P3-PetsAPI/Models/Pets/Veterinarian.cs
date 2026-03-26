using System;
using System.Collections.Generic;

namespace U2P3_PetsAPI.Models.Pets;

public partial class Veterinarian
{
    public int VetId { get; set; }

    public string? Name { get; set; }

    public string? Specialty { get; set; }

    public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
}
