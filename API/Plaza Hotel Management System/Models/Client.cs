using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Plaza_Hotel_Management_System.Models
{
    public class Client
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(20)]
        public string Nume { get; set; }

        [Required]
        [MaxLength(20)]
        public string Prenume { get; set; }

        [Required]
        [MaxLength(20)]
        [StringLength(13)]
        public string CNP { get; set; }

        [Required]
        [StringLength(10)]
        public string Telefon { get; set; }

        // aici legam Clientul de lista lui de rezervari
        public List<Rezervare> Rezervares { get; set; }
    }
}
