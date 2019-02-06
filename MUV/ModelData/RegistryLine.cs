using System;
using System.Diagnostics;

namespace MUV
{
    public class RegistryLine //: IComparable
    {
        public string NumDog { get; set; }
        public string DateDog { get; set; }
        public string Division { get; set; }
        public string NSICode { get; set; }
        public string Strah { get; set; }
        public string SaleChannel { get; set; }
        public string VidSatrah { get; set; }
        public string StrSumm { get; set; }
        public string KT { get; set; }
        public string Power { get; set; }
        public string TypeTS { get; set; }
        public string CelIspolzovania { get; set; }
        public string KBC { get; set; }
        public string VozrastTS { get; set; }
        public string VozrastLica { get; set; }
        public string PlatehzDoc { get; set; }
        public string Vznos { get; set; }
        public string DataVznosa { get; set; }
        public string KV { get; set; }
        public string MaxKV { get; set; }
        public string Stavka { get; set; }
        public string Summ { get; set; }
        public string Primachanie { get; set; }

        /// <summary>
        /// Переопределения для сравнения объектов
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{this.NumDog}{this.DateDog}{this.Division}{this.NSICode}{this.Strah}{this.SaleChannel}{this.VidSatrah}{this.StrSumm}{this.KT}{this.Power}{this.TypeTS}{this.CelIspolzovania}{this.KBC}{this.VozrastTS}{this.VozrastLica}{this.PlatehzDoc}{this.Vznos}{this.DataVznosa}{this.KV}{this.MaxKV}{this.Stavka}{this.Primachanie}";
        }

        /// <summary>
        /// Метод сравнения объектов
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public int CompareTo(RegistryLine obj)
        {
            return this.ToString().CompareTo(obj.ToString());
        }
    }
}
