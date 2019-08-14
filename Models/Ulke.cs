using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FakeData_MVC.Models
{
    [Table("Ulkeler")]
    public class Ulke
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string Ad { get; set; }
        public List<Personel> Personeller{ get; set; }
    }
}