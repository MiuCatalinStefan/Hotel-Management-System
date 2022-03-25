using Plaza_Hotel_Management_System.Models;
using System;
using System.Collections.Generic;

namespace Plaza_Hotel_Management_System.Interfaces
{
    public interface ICameraRepo
    {
        // Aici, in Interfata, am declarat functiile de care am nevoie in restul proiectului
        // Avem functie de adus toate camerele, de adus toate camerele disponibile FIX in momentul acesta
        // e putin cam enervat faptul ca am omis faptul ca poti face o rezervare din timp
        // nu exista functie de adaugat camere, fiindca m-am gandit ca nu prea se intampla asa des 
        // ca un hotel sa mai scoata din neant niste camere
        
        IEnumerable<Camera> GetAllCamere();

        IEnumerable<Camera> GetDisponibilCameras();
        
        // functie de adus camera cu un id(numar) anume
        Camera GetCameraById(int Id);

        // schimba disponibilitatea camerei de mana
        // gandit-a atunci cand clientul s-a lasat cheia, o persoana sa anunte sistemul ca aceea camera este acum libera
        void ChangeDisponibilitate(int Id);

        //salveaza schimbarile din BD
        bool SaveChanges();
    }
}
