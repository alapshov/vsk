using System;
using System.Collections.Generic;
using System.Diagnostics;
using TestTools;


namespace MUV.ModelData.Comparers
{
    public static class ListComparer<T> where T: List<RegistryLine>
    {
        /// <summary>
        /// Метод сравнения двух списков состоящих из RegistryLine
        /// </summary>
        /// <param name="etalon">список ожидаемого результата</param>
        /// <param name="list">список полученного результата</param>
        /// <returns></returns>
        public static int Compare(T etalon, T list)
        {
            var ErrorList = new List<RegistryLine>();
            if (list.Count == etalon.Count)
            {
                foreach (var item in etalon)
                {
                    bool exist = false;
                    foreach (var i in list)
                    {
                        if (i.CompareTo(item)==0)
                        {
                            exist = true;
                            break;
                        }
                    }
                    if (!exist)
                    {
                        ErrorList.Add(item);
                    }
                    //Заменил на фореч при отладке возможно можно вернуть Exists
                    //if (!list.Exists(i => i.CompareTo(item) == 0))
                    //{
                    //    ErrorList.Add(item);
                    //}
                }
                //Если есть ошибки выводим их в лог
                if (ErrorList.Count > 0)
                {
                    Trace("Строки не найденные в расчитанной таблице : ");
                    foreach (var item in ErrorList)
                    {
                        Trace(item.ToString());
                    }
                    Trace("");
                    Trace("Расчитанные строки : ");
                    foreach (var item in list)
                    {
                        Trace(item.ToString());
                    }
                    return 1;
                }
                else
                    return 0;
            }
            return 2;
        }
        /// <summary>
        ///Логирование
        /// </summary>
        /// <param name="msg">Сообщение в лог</param>
        private static void Trace(string msg)
        {
            Log.Trace($"ListComparer: {msg}", Level.Form);
        }
    }
}