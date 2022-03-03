using KuzeyApp.Models;
using KuzeyApp.Repository.Abstracts;

namespace KuzeyApp.Repository
{
    public class UrunRepo:RepositoryBase<Urun,int> 
    { 
        public override void Update(Urun entity,bool isSaveLater = false)
        {
            var entry=_context.Entry(entity);
            var eskifiyat = (decimal)entry.OriginalValues["Fiyat"];
            //Ürün fiyat geçmişi tablosuna eklenir/loglanır.
            base.Update(entity,isSaveLater);
        }
    }

}
