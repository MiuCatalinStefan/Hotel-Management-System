using Plaza_Hotel_Management_System.Models;
using System.Collections.Generic;

namespace Plaza_Hotel_Management_System.Interfaces
{
    public interface IClientRepo
    {
        // Aici am declarat functiile de care am nevoie in restul proiectului pentru manipularea datelor
        
        // Aduc toti clientii
        IEnumerable<Client> GetAllClients();

        // Aduc un clientu cu un Id anume
        Client GetClientById(int Id);

        // Aduc un client cu un CNP anume
        Client GetClientByCNP(string CNP);

        // Creez client
        void CreateClient(Client client);

        // Modific Client
        void UpdateClient(Client client);

        // Salvez ce am facut in BD
        bool SaveChanges();

        // Nu am functie de stergere client, ca sa pot tine o lista cu toti clientii, la cererea clientului speciala pot sa il sterg direct din BD
    }
}
