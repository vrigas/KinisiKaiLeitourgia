using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KinisiKaiLeitourgeia.Models.People
{
    public class Person
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Ονομα")]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Επώνυμο")]
        [StringLength(50)]
        public string Surname { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Σταθερό")]
        public string Telephone { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Σταθερό Εργασίας")]
        public string Workphone { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Κινητό")]
        public string Mobile { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name = "Διεύθυνση")]
        public string Address { get; set; }
        
        [Display(Name = "Πληροφορίες")]
        public string Info { get; set; }

        [Display(Name = "Ονοματεπωνυμο")]
        public virtual string FullName { get { return $"{Surname} {Name}"; } }

    }
}