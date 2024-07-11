using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeriTabanı1
{
    internal class VeriSatir
    {
        //## ALANLAR  ----------  ----------  ----------  ----------
        //## NİTELİKLER  ----------  ----------  ----------  ----------
        private List <Object> _veriler {  get; set; }
        private List<string> _satirlar { get; set; }



        //## OLUŞTURUCULAR  ----------  ----------  ----------  ----------
        public VeriSatir(List<string> SutunVektor, string[] vektor)
        {
            _veriler = new List<Object>();
            _satirlar = new List<string>();
            foreach (string v in SutunVektor) { _satirlar.Add(v); }
            foreach (string v in vektor) { _veriler.Add (v); }
        }


        //## İNDEXLER  ----------  ----------  ----------  ----------

        public Object this [ int index] 
        {
            get { return _veriler[index]; } 
            set { _veriler[index] = value; } 
        }

        public Object this [string terim] 
        { 
            get 
            {
                int i;
                if(SatirAra(terim, out i))
                    return _veriler[i];
                return null;
            } 
            set {
                int i;
                if (SatirAra(terim, out i))
                    _veriler[i] = value;
            } 
        }

        //## METODLAR  ----------  ----------  ----------  ----------

        public static VeriSatir Yarat(List<string> SutunVektor, string[] vektor) => new VeriSatir(SutunVektor, vektor) ;

        public bool SatirAra (string aranacakTerim, out int index) 
        { int temp = _satirlar.IndexOf(aranacakTerim);
            if (temp == -1)
            {
                index = -1;
                return false;  
            }
            index = temp;
            return true;
        }

        public override string ToString()
        {
            string temp = "|";
            foreach (string s in _veriler ) 
            { 
                
                temp +=  s + BoslukEKle(12 - s.Length) + "|"; 
            }
            return temp;
        }

        public string BoslukEKle (int sayi)
        {
            string temp = "";
            for (int i = 0; i < sayi; i++) { temp += " "; }
            return temp;
        }

    }  //  VeriSatir sınıfı sonu
}
