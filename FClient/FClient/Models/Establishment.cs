using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FClient.Models
{
    public class Establishment
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo é obrigatório.")]
        public string SocialName { get; set; }

        public string FantasyName { get; set; }

        [Required(ErrorMessage = "O campo é obrigatório.")]
        public string CNPJ { get; set; }

        public string Email { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string Phone { get; set; }

        public DateTime DateTime { get; set; }

        public string Category { get; set; }

        public bool IsActive { get; set; }

        public string Agency { get; set; }

        public string Account { get; set; }


    }
}