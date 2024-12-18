using Geometrie.DTO;
using Geometrie.Service;
using Microsoft.AspNetCore.Mvc;

namespace Geometrie.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CercleController : ControllerBase
    {
        private readonly ICercle_Service _cercleService;

        public CercleController(ICercle_Service cercleService)
        {
            _cercleService = cercleService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Cercle_DTO>> GetAll()
        {
            return Ok(_cercleService.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult<Cercle_DTO> GetById(int id)
        {
            var cercle = _cercleService.GetById(id);
            if (cercle == null)
            {
                return NotFound();
            }
            return Ok(cercle);
        }

        [HttpPost]
        [ActionName("Ajouter un cercle")]
        public ActionResult<Cercle_DTO> Add(Cercle_DTO cercle)
        {
            var createdCercle = _cercleService.Add(cercle);
            return CreatedAtAction(nameof(GetById), new { id = createdCercle.Id }, createdCercle);
        }

        [HttpPut("{id}")]
        public ActionResult<Cercle_DTO> Update(int id, Cercle_DTO cercle)
        {
            if (id != cercle.Id)
            {
                return BadRequest();
            }
            var updatedCercle = _cercleService.Update(cercle);
            return Ok(updatedCercle);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _cercleService.Delete(id);
            return NoContent();
        }
    }
}