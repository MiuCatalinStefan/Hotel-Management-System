using Plaza_Hotel_Management_System.Interfaces;
using Plaza_Hotel_Management_System.Models;
using Plaza_Hotel_Management_System.Repos;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Plaza_Hotel_Management_System.Data
{
    public class ClientRepo : IClientRepo
    {
        private readonly HotelContext _context;

        // Aici am legat clasa de Baza de Date Practic
        public ClientRepo(HotelContext context)
        {
            _context = context;
        }

        //Aici se creeaza un client
        public void CreateClient(Client client)
        {
            if (client == null)
            {
                throw new ArgumentNullException(nameof(client));
            }

            _context.Clienti.Add(client);
        }

        // Tragem toti Clienti intr-o Lista
        public IEnumerable<Models.Client> GetAllClients()
        {
            return _context.Clienti.ToList();
        }

        public Client GetClientByCNP(string CNP)
        {
            return _context.Clienti.FirstOrDefault(c => c.CNP.CompareTo(CNP) == 0);
        }

        // Tragem Doar Clientu cu Id-ul dat
        public Models.Client GetClientById(int Id)
        {
            return _context.Clienti.FirstOrDefault(c => c.Id == Id);
        }

        // Salvez modificarile in bd
        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateClient(Client client)
        {

        }
    }
}
