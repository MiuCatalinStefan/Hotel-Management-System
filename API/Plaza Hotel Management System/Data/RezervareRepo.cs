using Microsoft.EntityFrameworkCore;
using Plaza_Hotel_Management_System.Interfaces;
using Plaza_Hotel_Management_System.Models;
using Plaza_Hotel_Management_System.Repos;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Plaza_Hotel_Management_System.Data
{
    public class RezervareRepo : IRezervareRepo
    {
        private readonly HotelContext _context;

        // Aici am legat clasa de Baza de Date Practic
        public RezervareRepo(HotelContext context)
        {
            _context = context;
        }

        // Creez o noua rezervare 
        public void CreateRezervare(Rezervare rezervare)
        {
            if (rezervare == null)
            {
                throw new ArgumentNullException(nameof(rezervare));
            }

            _context.Rezervari.Add(rezervare);
        }

        // Ster o anume rezervare

        public void DeleteRezervare(Rezervare rezervare)
        {
            if (rezervare == null)
            {
                throw new ArgumentNullException(nameof(rezervare));
            }

            _context.Rezervari.Remove(rezervare);
        }

        // Aduc toate rezervarile
        public IEnumerable<Rezervare> GetAllRezervari()
        {
            return _context.Rezervari.Include(c => c.Client).ToList();
        }

        public Rezervare GetRezervareById(int Id)
        {
            //return _context.Rezervari.FirstOrDefault(r => r.Id == Id);
            return _context.Rezervari.Include(c => c.Client).FirstOrDefault(r => r.Id == Id);
        }

        // Salvez schimbarile facute in BD
        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateRezervare(Rezervare rezervare)
        {

        }
    }
}
