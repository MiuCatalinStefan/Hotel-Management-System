using Microsoft.AspNetCore.Mvc;
using Plaza_Hotel_Management_System.Interfaces;
using Plaza_Hotel_Management_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Plaza_Hotel_Management_System.Controllers
{
    [Route("hotel/[controller]")]
    [ApiController]
    public class RezervariController : ControllerBase
    {
        private readonly IRezervareRepo _repo;
        private readonly ICameraRepo _repoCamera;
        private readonly IClientRepo _repoClient;

        public RezervariController(IRezervareRepo repository, ICameraRepo repository2, IClientRepo repository3)
        {
            _repo = repository;

            _repoCamera = repository2;

            _repoClient = repository3;
        }

        //Get All
        // hotel/rezervare
        [HttpGet]
        public ActionResult<IEnumerable<Rezervare>> GetAllClienti()
        {
            var rezervari = _repo.GetAllRezervari();

            if (!rezervari.Any())
                return NotFound("NU exista Rezervari!");

            return Ok(rezervari);
        }

        //Get o anumita rezervare
        // hotel/rezervare/id
        [HttpGet("{Id}", Name = "GetRezervareById")]
        public ActionResult<Rezervare> GetRezervareById(int Id)
        {
            var rezervare = _repo.GetRezervareById(Id);

            if (rezervare == null)
                return NotFound("Nu exitsa o rezervare cu acest Id!");

            return Ok(rezervare);
        }


        //POST hotel/rezervari
        // verifica daca camera exista, si verifica daca camera este disponibila in momentul acesta
        // doar ca disponibilitatea a fost gandita prost si am eliminat-o
        // verifica daca datele sunt bine puse si sosirea vine calendaristic inaintea plecarii
        // verifica daca exista un client cu cnp-ul respectiv si introduce datele lui, nume, prenume, telefon
        // daca nu exista creeaza unul nou cu datele date in cerere
        [HttpPost]
        public ActionResult<Rezervare> CreateRezervare(Rezervare rezervare)
        {

            if (_repoCamera.GetCameraById(rezervare.CameraId) == null)
                return BadRequest("Camera cu acest Id nu exista!");
            // else if (_repoCamera.GetCameraById(rezervare.CameraId).Disponibil == false)
            //   return BadRequest("Camera deja ocupata!");

            if (DateTime.Compare(rezervare.Sosire, rezervare.Plecare) > 0)
                return BadRequest("Data introdusa incorrect!");

            if (_repoClient.GetClientByCNP(rezervare.Client.CNP) == null)
                _repoClient.CreateClient(rezervare.Client);
            _repo.SaveChanges();
            Client client = _repoClient.GetClientByCNP(rezervare.Client.CNP);
            rezervare.Client = null;
            rezervare.ClientId = client.Id;

            //_repoCamera.ChangeDisponibilitate(rezervare.CameraId);

            
            _repo.CreateRezervare(rezervare);
            _repo.SaveChanges();

            return CreatedAtRoute(nameof(GetRezervareById), new { Id = rezervare.Id }, rezervare);
        }

        //Modifica rezervarea, cu aceeleasi verificari ca POST-ul
        [HttpPut("{id}")]
        public ActionResult UpdateRezervare(int Id, Rezervare rezervare)
        {
            var rezervareFromRepo = _repo.GetRezervareById(Id);
            if (rezervareFromRepo == null)
            {
                return NotFound();
            }
            /*
            if (_repoCamera.GetCameraById(rezervare.CameraId).Disponibil == false && rezervare.CameraId != rezervareFromRepo.CameraId)
            {
                return BadRequest("Camera nu este disponibila!");
            }
            */

            if (DateTime.Compare(rezervare.Sosire, rezervare.Plecare) > 0)
                return BadRequest("Data introdusa incorrect!");

            
            if (_repoClient.GetClientByCNP(rezervare.Client.CNP) == null)
                _repoClient.CreateClient(rezervare.Client);
            Client client = _repoClient.GetClientByCNP(rezervare.Client.CNP);
            rezervare.ClientId = client.Id;
            
            /*
            if (rezervareFromRepo.CameraId != rezervare.CameraId)
            {
                _repoCamera.ChangeDisponibilitate(rezervareFromRepo.CameraId);
                _repoCamera.ChangeDisponibilitate(rezervare.CameraId);
            }
           */

            rezervareFromRepo.ClientId = rezervare.ClientId;
            rezervareFromRepo.CameraId = rezervare.CameraId;
            rezervareFromRepo.Sosire = rezervare.Sosire;
            rezervareFromRepo.Plecare = rezervare.Plecare;


            _repo.UpdateRezervare(rezervare);
            _repo.SaveChanges();

            return NoContent();
        }

        // sterge rezervarea
        [HttpDelete("{Id}")]
        public ActionResult DeleteRezervare(int Id)
        {
            var rezervareFromRepo = _repo.GetRezervareById(Id);
            if (rezervareFromRepo == null)
            {
                return NotFound();
            }

          //  _repoCamera.ChangeDisponibilitate(rezervareFromRepo.CameraId);

            _repo.DeleteRezervare(rezervareFromRepo);

            _repo.SaveChanges();

            return NoContent();
        }

    }
}
