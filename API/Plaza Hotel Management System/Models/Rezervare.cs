using System;
using System.ComponentModel.DataAnnotations;

namespace Plaza_Hotel_Management_System.Models
{
    public class Rezervare
    {
        [Key]
        public int Id { get; set; }

        // Id-ul clientului
        [Required]
        public int ClientId { get; set; }

        // Datele Clientului
        public Client Client { get; set; }

        // Id-ul (numarul) camerei
        [Required]
        public int CameraId { get; set; }

        // Datele Camerei, neimportante pentru noi
        public Camera Camera { get; set; }

        // Data sosirii
        [Required]
        public DateTime Sosire { get; set; }

        // Data plecarii
        [Required]
        public DateTime Plecare { get; set; }

    }
}
