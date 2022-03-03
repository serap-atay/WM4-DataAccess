using KuzeyApp.Models;
using KuzeyApp.Repository.Abstracts;
using System;

namespace KuzeyApp.Repository
{
    public class SiparisRepo:RepositoryBase<Siparis,int>
    {
        public void SiparisOlustur()
        {
            //transaction
        }
        public void SiparisRaporu (DateTime baslangic,DateTime bitis)
        {

        }
    }

}
