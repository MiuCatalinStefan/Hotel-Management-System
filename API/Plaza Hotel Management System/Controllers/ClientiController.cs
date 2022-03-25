using Microsoft.AspNetCore.Mvc;
using Plaza_Hotel_Management_System.Interfaces;
using Plaza_Hotel_Management_System.Models;
using System.Collections.Generic;
using System.Linq;

namespace Plaza_Hotel_Management_System.Controllers
{
    [Route("hotel/[controller]")]
    [ApiController]
    public class ClientiController : ControllerBase
    {
        private readonly IClientRepo _repo;

        public ClientiController(IClientRepo repository)
        {
            _repo = repository;
        }

        //Get All
        // hotel/clienti
        [HttpGet]
        public ActionResult<IEnumerable<Client>> GetAllClienti()
        {
            var clients = _repo.GetAllClients();

            if (!clients.Any())
                return NotFound("Nu exista Clienti!");

            return Ok(clients);
        }

        //Get One By Id
        // hotel/clienti/{id}
        [HttpGet("{Id}", Name = "GetClientById")]
        public ActionResult<Client> GetClientById(int Id)
        {
            var client = _repo.GetClientById(Id);

            if (client == null)
                return NotFound("Nu exitsa un client cu acest Id!");

            return Ok(client);
        }

        [HttpGet("CNP/{CNP}")]
        public ActionResult<Client> GetClientByCNP(string CNP)
        {
            var client = _repo.GetClientByCNP(CNP);

            if (client == null)
                return NotFound("Nu exitsa un client cu acest Id!");

            return Ok(client);
        }

        //POST hotel/clienti
        [HttpPost]
        public ActionResult<Client> CreateClient(Client client)
        {
            if(_repo.GetClientByCNP(client.CNP) != null)
            {
                return BadRequest("Cleintul cu acest DEJA");
            }
            _repo.CreateClient(client);
            _repo.SaveChanges();

            return CreatedAtRoute(nameof(GetClientById), new { Id = client.Id }, client);
        }

        // Modifica un anume client
        [HttpPut("{id}")]
        public ActionResult UpdateClient(int Id, Client client)
        {
            var clientFromRepo = _repo.GetClientById(Id);
            if (clientFromRepo == null)
            {
                return NotFound();
            }

            if (_repo.GetClientByCNP(client.CNP) != null)
            {
                return BadRequest("Cleintul cu acest DEJA");
            }

            clientFromRepo.Nume = client.Nume;
            clientFromRepo.Prenume = client.Prenume;
            clientFromRepo.CNP = client.CNP;
            clientFromRepo.Telefon = client.Telefon;

            _repo.UpdateClient(client);
            _repo.SaveChanges();

            return NoContent();
        }

    }
}
