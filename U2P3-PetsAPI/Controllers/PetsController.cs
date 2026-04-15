using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using U2P3_PetsAPI.Models.Pets;

namespace U2P3_PetsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetsController : ControllerBase
    {
        private readonly PetsContext _context;

        public PetsController(PetsContext context)
        {
            _context = context;
        }

    
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pet>>> GetPets()
        {
            return await _context.Pets
                .Include(p => p.Owner)
                .ToListAsync();
        }

       
        [HttpGet("{id}")]
        public async Task<ActionResult<Pet>> GetPet(int id)
        {
            var pet = await _context.Pets
                .Include(p => p.Owner)
                .FirstOrDefaultAsync(p => p.PetId == id);

            if (pet == null)
                return NotFound();

            return pet;
        }

       
        [HttpGet("species/{species}")]
        public async Task<ActionResult<IEnumerable<Pet>>> GetBySpecies(string species)
        {
            return await _context.Pets
                .Where(p => p.Species == species)
                .ToListAsync();
        }

        [HttpGet("owner/{ownerId}")]
        public async Task<ActionResult<IEnumerable<Pet>>> GetByOwner(int ownerId)
        {
            return await _context.Pets
                .Where(p => p.OwnerId == ownerId)
                .ToListAsync();
        }

       
        [HttpPost]
        public async Task<ActionResult<Pet>> PostPet(Pet pet)
        {
            // Validar que el Owner exista
            var ownerExists = await _context.Owners.AnyAsync(o => o.OwnerId == pet.OwnerId);

            if (!ownerExists)
                return BadRequest("El Owner no existe");

            _context.Pets.Add(pet);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPet), new { id = pet.PetId }, pet);
        }

        
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPet(int id, Pet pet)
        {
            if (id != pet.PetId)
                return BadRequest();

            _context.Entry(pet).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PetExists(id))
                    return NotFound();
                else
                    throw;
            }

            return NoContent();
        }

     
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePet(int id)
        {
            var pet = await _context.Pets.FindAsync(id);

            if (pet == null)
                return NotFound();

            _context.Pets.Remove(pet);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PetExists(int id)
        {
            return _context.Pets.Any(e => e.PetId == id);
        }
    }
}