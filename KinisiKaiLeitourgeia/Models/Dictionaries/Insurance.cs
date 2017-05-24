using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KinisiKaiLeitourgeia.Models.Dictionaries
{
    public class Insurance
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Ασφαλιστικός Φορέας")]
        public string Name { get; set; }
    }
}