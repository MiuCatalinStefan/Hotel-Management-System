using Microsoft.EntityFrameworkCore;
using Plaza_Hotel_Management_System.Interfaces;
using Plaza_Hotel_Management_System.Models;
using Plaza_Hotel_Management_System.Repos;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Plaza_Hotel_Management_System.Data
{
    public class CameraRepo : ICameraRepo
    {
        private readonly HotelContext _context;

        // Aici am legat clasa de Baza de Date Practic
        public CameraRepo(HotelContext context)
        {
            _context = context;
        }

        // schimb disponibilitatea din momentul in momentul acesta a camerei
        public void ChangeDisponibilitate(int Id)
        {
            var camera = _context.Camere.FirstOrDefault(c => c.Id == Id);
            if (camera.Disponibil == true)
                camera.Disponibil = false;
            else camera.Disponibil = true;

            SaveChanges();
        }


        // aduc toate camerele
        public IEnumerable<Camera> GetAllCamere()
        {
            return _context.Camere.ToList();
        }

        // aduc o camera dupa numarul ei (Id)
        public Camera GetCameraById(int Id)
        {
            return _context.Camere.FirstOrDefault(c => c.Id == Id);
        }

        // Aici aduc lista de camere disponibile in momentul acesta
        // Am incercat sa remediez treaba ca daca acum e indisponibila, peste un an tot arata ca e indisponibila
        // Dar ca sa schimb tot sistemul cu disponibilitatea este o mare bataie de cap, mai ales la front end
        public IEnumerable<Camera> GetDisponibilCameras()
        {
            /*
            List<Camera> camera = _context.Camere.Include(c => c.Rezervares).ToList();

            List<Camera> smth = camera.OrderBy(x => x.Rezervares.Count).ToList();

            List<Camera> final = new();

            foreach( Camera elem in smth)
            {
                if(elem.Rezervares.Any())
                {
                   List<Rezervare> rez = elem.Rezervares.OrderBy(x => x.Plecare).ToList();

                   foreach(Rezervare r in rez)
                   {
                        Console.WriteLine("///////////");
                        Console.WriteLine(r.Plecare);
                        Console.WriteLine(r.Sosire);
                   }
                }

            }
            return smth;
            */

            return _context.Camere.Where(c => c.Disponibil == true);
        }

        // salvez modificarile facute in BD

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}
