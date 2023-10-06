using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPILnkdn.Data;
using WebAPILnkdn.Model;

namespace WebAPILnkdn.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        public APIDbContext _dbcontex;
        public PersonController(APIDbContext dbContext)
        {
            _dbcontex = dbContext;
        }

        public IActionResult Get()
        {
            var PerosnList = _dbcontex.people.ToList();
            return Ok(PerosnList);

        }

        [HttpGet]
        [Route("{id}")]
        public async Task <IActionResult> GetbyID(int ID)
        {
            var Perosnbyid = await _dbcontex.people.FindAsync(ID);
            if(Perosnbyid==null)
            {
                return NotFound();
            }
            return Ok(Perosnbyid);

        }

        [HttpPost]

        public async Task<IActionResult> PostPerson(Person person)
        {
            if(!ModelState.IsValid)
            { return BadRequest(); }

            await _dbcontex.people.AddAsync(person);
            await _dbcontex.SaveChangesAsync();
            return CreatedAtAction("GetByID",
                new { id = person.ID },
                person);

        }

        [HttpPut("{Id}")]

        public async Task<IActionResult> PutPerson(int Id, Person person)
        {
            if(Id != person.ID)
            { return BadRequest(); }

            else

            {
                _dbcontex.Entry(person).State = EntityState.Modified;

                try
                {
                    await _dbcontex.SaveChangesAsync();


                }

                catch(DbUpdateConcurrencyException)
                {
                    if(!_dbcontex.people.Any(x=> x.ID == Id))
                    {
                        return NotFound();
                    }
                    else { throw ; }

                }
                return NoContent();

            }


        }

        [HttpDelete("{Id}")]

        public async Task<ActionResult<Person>> DeletePerson(int Id)
        {

            var person = await _dbcontex.people.FindAsync(Id);

            if(person==null) return BadRequest();

            _dbcontex.people.Remove(person);
            await _dbcontex.SaveChangesAsync();

            return person;
        
        }

            

    }
}
