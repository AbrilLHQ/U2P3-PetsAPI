using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace U2P3_PetsAPI.Models.Pets;

public partial class Pet
{
    public int PetId { get; set; }

    [Required(ErrorMessage = "El nombre es obligatorio")]
    public string Name { get; set; }

    [Required(ErrorMessage = "La especie es obligatoria")]
    public string Species { get; set; }

    public string? Breed { get; set; }

    [Required(ErrorMessage = "La fecha es obligatoria")]
    public DateTime BirthDate { get; set; }

    [Required(ErrorMessage = "El Owner es obligatorio")]
    public int OwnerId { get; set; }

    public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();

    public virtual Owner Owner { get; set; }
}