using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;
using DataAccessLayer;
using System.Diagnostics.Eventing.Reader;
using System.Data.SqlClient;

namespace LogicLayer
{
    public class LogicPersonel
    {
       public static List<EntityPersonel> LLPersonelListesi()
        {
            return DalPersonel.PersonelListesi();
        }
        public static int LLPersonelEkle(EntityPersonel p) 
        {
            if (p.Ad!="" && p.Soyad!="" && p.Maas>=4500 && p.Ad.Length>=3)//Buraya gelene kadar işlemleri kontrol edecek ve aşağıdaki şartları sağlıyor ise değerleri döndürecek ve bir sonraki katmana iletmeye hazır hale gelecek
            {
                return DalPersonel.PersonelEkle(p);
            }
            else
            {
                
                return -1; //if i sağlamazsa hiç bir şey yapma anlamında
            }
        }
        public static bool LLPersonelSil(int per)
        {
            if(per > 1)
            {
                return DalPersonel.PersonelSil(per);
            }
            else { return false; } 
        }
        public static bool LLPersonelGuncelle(EntityPersonel ent)
        {
            if (ent.Ad != "" && ent.Soyad != "" && ent.Maas >= 4500 && ent.Ad.Length >= 3)
            {
                return DalPersonel.PersonelGuncelle(ent);
            }
            else
            {

                return false; 
            }
        }
    }
    
}
