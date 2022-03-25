using Plaza_Hotel_Management_System.Models;
using System.Collections.Generic;

namespace Plaza_Hotel_Management_System.Interfaces
{
    public interface IRezervareRepo
    {
        //Aici am declarat ce functii mai am nevoie inmm proiect pentru manipularea datelor

        // Aduc toate rezervarile
        IEnumerable<Rezervare> GetAllRezervari();

        // Aduc o anume rezervare dupa Id
        Rezervare GetRezervareById(int Id);

        // Creez rezervare
        void CreateRezervare(Rezervare rezervare);

        // Updatez rezervare
        void UpdateRezervare(Rezervare rezervare);

        // Sterg rezervare
        void DeleteRezervare(Rezervare rezervare);

        // Salvez ce schimbari am mai facut in BD
        bool SaveChanges();
    }
}
