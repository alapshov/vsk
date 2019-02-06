using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UITest.ModelData.Comparers
{
    public static class ElementComarer
    {
        public static int CompareTo(object obj, object objEtalon)
        {
            var o = obj as RegistryLine;
            var et = objEtalon as RegistryLine;
            if (o != null)
            {
                if (o.CelIspolzovania == et.CelIspolzovania)
                {
                    if (o.DataVznosa == et.DataVznosa)
                    {
                        if (o.DateDog == et.DateDog)
                        {
                            if (o.Division == et.Division)
                            {
                                if (o.KBC == et.KBC)
                                {
                                    if (o.KT == et.KT)
                                    {
                                        if (o.KV == et.KV)
                                        {
                                            if (o.MaxKV == et.MaxKV)
                                            {
                                                if (o.NSICode == et.NSICode)
                                                {
                                                    if (o.NumDog == et.NumDog)
                                                    {
                                                        if (o.PlatehzDoc == et.PlatehzDoc)
                                                        {
                                                            if (o.Power == et.Power)
                                                            {
                                                                if (o.Primachanie == et.Primachanie)
                                                                {
                                                                    if (o.SaleChannel == et.SaleChannel)
                                                                    {
                                                                        if (o.Stavka == et.Stavka)
                                                                        {
                                                                            if (o.Strah == et.Strah)
                                                                            {
                                                                                if (o.StrSumm == et.StrSumm)
                                                                                {
                                                                                    if (o.Summ == et.Summ)
                                                                                    {
                                                                                        if (o.TypeTS == et.TypeTS)
                                                                                        {
                                                                                            if (o.VidSatrah == et.VidSatrah)
                                                                                            {
                                                                                                if (o.VozrastLica == et.VozrastLica)
                                                                                                {
                                                                                                    if (o.VozrastTS == et.VozrastTS)
                                                                                                    {
                                                                                                        if (o.Vznos == et.Vznos)
                                                                                                        {
                                                                                                            return 1;
                                                                                                        }
                                                                                                    }
                                                                                                }
                                                                                            }
                                                                                        }
                                                                                    }
                                                                                }
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }

                                                    }

                                                }
                                            }
                                        }

                                    }
                                }
                            }
                        }
                    }

                }
            }
            return 0;
        }
    }
}

