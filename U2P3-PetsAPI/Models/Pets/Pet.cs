using System;
using System.Collections.Generic;

namespace U2P3_PetsAPI.Models.Pets;

public partial class Pet
{
    public int PetId { get; set; }

    public string? Name { get; set; }

    public string? Species { get; set; }

    public string? Breed { get; set; }

    public DateOnly? BirthDate { get; set; }

    public int? OwnerId { get; set; }

    public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();

    public virtual Owner? Owner { get; set; }
}
