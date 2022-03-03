using KuzeyApp.Models.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace KuzeyApp.Models
{
    [Table("Calisan")]
    public class Calisan:BaseEntity,IKey<int>
    {
        [Key]
        public int Id { get; set; }
        [Required,StringLength(50)]
        public string Ad { get; set; }
         [Required,StringLength(50)]
        public decimal Soyad { get; set; } = 0;
        [StringLength(11)]
        public string Telefon { get; set; }

        public int? AmirId { get; set; }
       

        [ForeignKey(nameof(AmirId))]
        public Calisan Amir { get; set; }
       public ICollection<Calisan> Calisanlar{get;set;}=new HashSet<Calisan>();
  
    }
}