namespace U2P3_PetsAPI.Models.DTO
{
    public class AppointmentDTO
    {
        public int AppointmentId { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string Reason { get; set; }

        // Pet
        public int PetId { get; set; }
        public string PetName { get; set; }
        public string Species { get; set; }

        // Owner
        public int OwnerId { get; set; }
        public string OwnerName { get; set; }

        // Veterinarian
        public int VetId { get; set; }
        public string VetName { get; set; }
        public string Specialty { get; set; }

    }
}
