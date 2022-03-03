using KuzeyApp.Models.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KuzeyApp.Models
{
    [Table("Urunler")]
    public class Urun:BaseEntity,IKey<int>
    {
        [Key]
        public int Id { get; set; }
        [Required,StringLength(50)]
        public string Ad { get; set; }
        public decimal Fiyat { get; set; } = 0;
        public int KategoriId { get; set; }

        [Range(0,10000)]//validation attribute
        public int StokMiktari { get; set; }
        public bool DevamEtmiyorMu { get; set; } = true;

        public Guid? TedarikciId { get; set; }
        public ICollection<SiparisDetay> SiparisDetaylari { get; set; } = new HashSet<SiparisDetay>();

        [ForeignKey(nameof(KategoriId))]
        public Kategori Kategori { get; set; }
        [ForeignKey(nameof(TedarikciId))]
        public Tedarikci Tedarikci { get; set; }
  
    }
}
