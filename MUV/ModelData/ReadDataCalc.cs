using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using MUV.FormObjects;
using MUV.ModelData.Comparers;
using NUnit.Framework;
using TestStack.White.UIItems;
using TestTools;


namespace MUV.ModelData
{
    public class ReadDataCalc
    {
        public List<RegistryLine> item;
        public ProductEnum product;
        public int cellsCount;
        public enum ProductEnum
        {
            /// <summary>
            /// Не задан продукт
            /// </summary>
            Other = 0,
            /// <summary>
            /// Продукты КАСКО ОПО и Зелёная карта
            /// </summary>
            KaskoOpoZv = 17,
            /// <summary>
            /// Дорожный серпантин
            /// </summary>
            DS = 24
        }
        /// <summary>
        /// Пустой конструктор
        /// </summary>
        public ReadDataCalc()
        {
            item = new List<RegistryLine>();
        }
        /// <summary>
        /// Конструктор с заполнением данных
        /// </summary>
        /// <param name="listViewsRows">Строки формы</param>
        public ReadDataCalc (ListViewRows listViewsRows)
        {
            item = new List<RegistryLine>();
            cellsCount = listViewsRows[0].Cells.Count();
            product = (ProductEnum) (cellsCount==17 || cellsCount == 24 ? cellsCount : 0);
            AddItem(listViewsRows);
        }

        /// <summary>
        /// Добавление данных
        /// </summary>
        /// <param name="listViewsRows"></param>
        public void AddItem(ListViewRows listViewsRows)
        {
            for (int i = 0; i < listViewsRows.Count(); i++)
            {
                
                var RegistryLine = new RegistryLine()
                {
                    NumDog = listViewsRows[i].Cells[1].Text
                    ,DateDog = listViewsRows[i].Cells[2].Text
                    ,Division = listViewsRows[i].Cells[3].Text
                    ,NSICode = listViewsRows[i].Cells[4].Text
                    ,Strah = listViewsRows[i].Cells[5].Text
                    ,SaleChannel = listViewsRows[i].Cells[6].Text
                    ,VidSatrah = listViewsRows[i].Cells[7].Text
                    ,StrSumm = listViewsRows[i].Cells[8].Text
                    ,KT = product == ProductEnum.DS ? (listViewsRows[i].Cells[9].Text.Replace(",",".") != ""? 
                          listViewsRows[i].Cells[9].Text.Replace(",", "."): null ) :
                          null
                    ,Power = product == ProductEnum.DS ? listViewsRows[i].Cells[10].Text.Replace(",", ".") :
                             null
                    ,TypeTS = product == ProductEnum.DS ? listViewsRows[i].Cells[11].Text :
                              null
                    ,CelIspolzovania = product == ProductEnum.DS ? listViewsRows[i].Cells[12].Text :
                                       null
                    ,KBC = product == ProductEnum.DS ? listViewsRows[i].Cells[13].Text.Replace(",", ".") :
                           null
                    ,VozrastTS = product == ProductEnum.DS ? listViewsRows[i].Cells[14].Text :
                                 null
                    ,VozrastLica = product == ProductEnum.DS ?  listViewsRows[i].Cells[15].Text:
                                   null
                    ,PlatehzDoc = product == ProductEnum.KaskoOpoZv ? listViewsRows[i].Cells[9].Text :
                                  product == ProductEnum.DS ? listViewsRows[i].Cells[16].Text :
                                  null
                    ,Vznos = product == ProductEnum.KaskoOpoZv ? listViewsRows[i].Cells[10].Text :
                             product == ProductEnum.DS ? listViewsRows[i].Cells[17].Text :
                             null
                    ,DataVznosa = product == ProductEnum.KaskoOpoZv ? listViewsRows[i].Cells[11].Text :
                                  product == ProductEnum.DS ? listViewsRows[i].Cells[18].Text :
                                  null
                    ,KV = product == ProductEnum.KaskoOpoZv ? listViewsRows[i].Cells[12].Text :
                          product == ProductEnum.DS ? listViewsRows[i].Cells[19].Text :
                          null
                    ,MaxKV = product == ProductEnum.KaskoOpoZv ? listViewsRows[i].Cells[13].Text :
                             product == ProductEnum.DS ? listViewsRows[i].Cells[20].Text :
                             null
                    ,Stavka = product == ProductEnum.KaskoOpoZv ? listViewsRows[i].Cells[14].Text :
                              product == ProductEnum.DS ? listViewsRows[i].Cells[21].Text :
                              null
                    ,Summ = product == ProductEnum.KaskoOpoZv ? listViewsRows[i].Cells[15].Text :
                            product == ProductEnum.DS ? listViewsRows[i].Cells[22].Text :
                            null
                    ,Primachanie = product == ProductEnum.KaskoOpoZv ? listViewsRows[i].Cells[16].Text :
                                   product == ProductEnum.DS ? listViewsRows[i].Cells[23].Text :
                                   null
                };
             item.Add(RegistryLine);
            }
        }

        /// <summary>
        /// Удаление дублей
        /// </summary>
        /// <returns></returns>
        public void Distinct()
        {
            ReadDataCalc DistinctCollection = new ReadDataCalc();
            this.item.Sort(SortDelegat);
            RegistryLine AddRow = this.item[0];
            DistinctCollection.item.Add(AddRow);
            foreach (RegistryLine i in this.item)
            {
                if (AddRow.CompareTo(i) != 0)
                {
                    DistinctCollection.item.Add(i);
                    AddRow = i;
                }
            }
            this.item = DistinctCollection.item;
        }

        /// <summary>
        /// Делигат для сортировки данных
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="obj2"></param>
        /// <returns></returns>
        public int SortDelegat(RegistryLine obj, RegistryLine obj2)
        {
            if (obj == null && obj2 == null) return 0;
            else if (obj == null) return -1;
            else if (obj2 == null) return 1;
            else return obj.CompareTo(obj2);
        }

        /// <summary>
        /// Сравнение результатов расчетов с эталонными
        /// </summary>
        /// <param name="data">Данные из xml</param>
        /// <param name="sorce">Данные с формы</param>
        /// <returns></returns>
        public static void RegistryValidation(BonusCalculationData data, List<RegistryLine> sorce)
        {

            Trace("Сравниваем результаты расчетов с эталонными данными");
            var resultCompare = ListComparer<List<RegistryLine>>.Compare(data.RegistryResult, sorce);

            if (resultCompare > 0)
            {
                if (resultCompare == 1)
                {
                    Trace("Есть ошибки в расчете");
                    Assert.Fail("Есть ошибки в расчете");
                }
                else if (resultCompare == 2)
                {
                    string ErrorMsg = string.Format("Количество строк не совпало ожидаем = {0}, найдено = {1}", data.RegistryResult.Count, sorce.Count);
                    Trace(ErrorMsg);
                    Assert.Fail(ErrorMsg);
                }
            }
            else
            {
                Trace("Расчет проведен верно");
            }

           
        }
        /// <summary>
        ///Логирование
        /// </summary>
        /// <param name="msg">Сообщение в лог</param>
        private static void Trace(string msg)
        {
            Log.Trace($"ReadDataCalc: {msg}", Level.Form);
        }
    }
}
