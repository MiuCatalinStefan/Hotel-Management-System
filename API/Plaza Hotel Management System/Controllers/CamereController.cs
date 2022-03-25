using Microsoft.AspNetCore.Mvc;
using Plaza_Hotel_Management_System.Interfaces;
using Plaza_Hotel_Management_System.Models;
using System.Collections.Generic;
using System.Linq;

namespace Plaza_Hotel_Management_System.Controllers
{
    [Route("hotel/[controller]")]
    [ApiController]
    public class CamereController : ControllerBase
    {
        private readonly ICameraRepo _repo;

        public CamereController(ICameraRepo repository)
        {
            _repo = repository;
        }

        //Get All
        // hotel/camere
        // Aduc toate informatiile camerelor hotelului
        [HttpGet]
        public ActionResult<IEnumerable<Camera>> GetAllCamere()
        {
            var camere = _repo.GetAllCamere();
            if (!camere.Any())
                return NotFound("NU exista Camere!");

            return Ok(camere);
        }

        // Aduc doar camerele disponibile in momentul acesta
        [HttpGet("disponibil")]
        public ActionResult<IEnumerable<Camera>> GetAllDisponibileCamere()
        {
            var camere = _repo.GetDisponibilCameras();
            if (!camere.Any())
                return NotFound("NU exista Camere Disponibile!");

            return Ok(camere);
        }



        //Get One By Id
        // hotel/camere/{id}
        [HttpGet("{Id}")]
        public ActionResult<Client> GetCamereById(int Id)
        {
            var camera = _repo.GetCameraById(Id);

            if (camera == null)
                return NotFound("Nu exitsa un camera cu acest Id!");

            return Ok(camera);
        }

        //schimba disponibilitatea camerei
        [HttpGet("update/{id}")]
        public ActionResult UpdateDisponibilitate(int Id)
        {
            var rezervareFromRepo = _repo.GetCameraById(Id);
            if (rezervareFromRepo == null)
            {
                return NotFound();
            }

            _repo.ChangeDisponibilitate(Id);
            _repo.SaveChanges();

            return NoContent();
        }
    }
}
