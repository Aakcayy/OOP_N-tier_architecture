using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;
using System.Data.SqlClient;
using System.Data;

namespace DataAccessLayer
{
    public class DalPersonel
    {
      public static List<EntityPersonel> PersonelListesi()//<list metodunun ismi
        {
            List<EntityPersonel> degerler=new List<EntityPersonel>();
            SqlCommand cmd = new SqlCommand("Select * from dbo.Bilgi",Baglanti.bgl);//static olduğu için ayrıca bir nesne yani baglantı bgl=new baglantı(); oluşturmama gerek kalmadı ve direk erişebildim ; olmasaydı erişirdim
            if (cmd.Connection.State != ConnectionState.Open) //Bağlantının kapanabilme ihtimaline karşı  açık mı kapalı mı kontrolü anlamında
            {
                cmd.Connection.Open();
            }
            SqlDataReader dr = cmd.ExecuteReader();
            while(dr.Read())
            {
                EntityPersonel dp=new EntityPersonel();
                dp.Id = int.Parse(dr["ID"].ToString());
                dp.Ad = dr["AD"].ToString();
                dp.Soyad = dr["SOYAD"].ToString();
                dp.Gorev = dr["GOREV"].ToString();
                dp.Sehir = dr["SEHIR"].ToString();
                dp.Maas =short.Parse(dr["MAAS"].ToString());
                degerler.Add(dp); //dp den gelen değerleri  al degerler nesnesine ekle
            }
            dr.Close();
            return degerler;// değerler nesnesinin içine gelen değerleri list metoduna ekle ve listeleme işi için hazır hale gelir

        }
        public static int PersonelEkle(EntityPersonel p)
        {
            SqlCommand komut = new SqlCommand("insert into dbo.Bilgi (AD,SOYAD,GOREV,SEHIR,MAAS) VALUES(@p1,@p2,@p3,@p4,@p5)",Baglanti.bgl);
            if (komut.Connection.State != ConnectionState.Open) 
            {
                komut.Connection.Open();
            }
            komut.Parameters.AddWithValue("@p1", p.Ad);
            komut.Parameters.AddWithValue("@p2", p.Soyad);
            komut.Parameters.AddWithValue("@p3", p.Gorev);
            komut.Parameters.AddWithValue("@p4", p.Sehir);
            komut.Parameters.AddWithValue("@p5", p.Maas);

            return komut.ExecuteNonQuery();


        }
        public static bool PersonelSil(int p) //int de kullanabilirsin bool da bir fark yok
        {
            SqlCommand komut2 = new SqlCommand("DELETE from dbo.Bilgi where ID=@p1", Baglanti.bgl);
            if (komut2.Connection.State != ConnectionState.Open)
            {
                komut2.Connection.Open();
            }
            komut2.Parameters.AddWithValue("@p1", p);
            return komut2.ExecuteNonQuery()> 0;//bool türünde olduğu için 0 dan büyükse  1 olur yani true çalıştırır ve siler küçük olması -1 demek yani false olur çalıştırmaz ve silmez
        }
        public static bool PersonelGuncelle(EntityPersonel ent)//birden fazla parametre göndereceğim için int p kullanmadım
        {
            SqlCommand komut3 = new SqlCommand("Update dbo.Bilgi SET  AD=@p1,SOYAD=@p2,Maas=@p3,SEHIR=@p4,Gorev=@p5 where ID=@p6", Baglanti.bgl);
            if (komut3.Connection.State != ConnectionState.Open)
            {
                komut3.Connection.Open();
            }
            komut3.Parameters.AddWithValue("@p1", ent.Ad);
            komut3.Parameters.AddWithValue("@p2", ent.Soyad);
            komut3.Parameters.AddWithValue("@p3", ent.Maas);
            komut3.Parameters.AddWithValue("@p4", ent.Sehir);
            komut3.Parameters.AddWithValue("@p5", ent.Gorev);
            komut3.Parameters.AddWithValue("@p6", ent.Id);

            return komut3.ExecuteNonQuery() > 0;
        }
    }
}
