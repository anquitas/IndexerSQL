using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace VeriTabanı1
{
    internal class VeriTablo
    {
        //## NİTELİKLER  ----------  ----------  ----------  ----------
        private List <VeriSatir> satirlar {  get; set; }
        private List <string> sutunlar { get; set; }
        //## OLUŞTURUCULAR  ----------  ----------  ----------  ----------
        public VeriTablo(string[] Sutunvektor) 
        { 
            sutunlar = new List <string>();
            foreach(string s in Sutunvektor)
                sutunlar.Add(s);
            satirlar = new List<VeriSatir>(); 
        }
        //## İNDEXLER  ----------  ----------  ----------  ----------

        #region satir al
        public string this[int index] 
        { 
            get { return satirlar[index].ToString(); }
        }
        #endregion

        #region element al
        public Object this [int satir, int sutun ] 
        { 
            get { return satirlar[satir][sutun]; }
            set { satirlar[satir][sutun] = value; }
        }

        public Object this[int satir, string terim]
        {
            get { return satirlar[satir][terim]; }
            set { satirlar[satir][terim] = value; }
        }
        #endregion

        //## METODLAR  ----------  ----------  ----------  ----------

        #region FONKSİYON SatirEkle()
        public void SatirEkle (VeriSatir satir) => satirlar.Add(satir);

        public void SatirEkle (string[] vektor) 
        {
            satirlar.Add(VeriSatir.Yarat(sutunlar, vektor));
        }
        #endregion


        public void yazdir ()
        {
            foreach(VeriSatir satir in satirlar)
            {
                Console.WriteLine(satir);
            }
        }

    }
}
