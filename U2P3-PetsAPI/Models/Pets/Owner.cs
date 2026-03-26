using System;
using System.Collections.Generic;

namespace U2P3_PetsAPI.Models.Pets;

public partial class Owner
{
    public int OwnerId { get; set; }

    public string? Name { get; set; }

    public string? Phone { get; set; }

    public string? Email { get; set; }

    public virtual ICollection<Pet> Pets { get; set; } = new List<Pet>();
}
