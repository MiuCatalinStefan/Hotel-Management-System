using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Plaza_Hotel_Management_System.Models
{
    public class Camera
    {
        [Key]
        public int Id { get; set; }

        // Acesta camp arata daca camera este disponibila fix in momentul acesta
        // eu cand am introdus-o si am facut proiecul am uitat de micul fapt ca exista internet si 
        // poti face o rezervare azi, pentru anul viitor
        // la mine in cap ajungeai la ghiseu si de abia atunci puteai sa faci o rezervare din momentul aceela
        // pana cand vrei tu.
        // ceea ce inseamna ca nu o sa fie disponibila in lista de camere disponibile
        // pentru o rezervare pentru anul viitor, de exemplu
        // asta are repercursiuni mai mari prin proiect
        [Required]
        public bool Disponibil { get; set; }

        // Legatura cu rezervare
        public List<Rezervare> Rezervares { get; set; }
    }
}
