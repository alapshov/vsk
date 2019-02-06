using TestStack.White.UIItems.Finders;
using System.Diagnostics;
using TestTools;
using TestStack.White.UIItems.TreeItems;
using NUnit.Framework;
using TestStack.White.UIItems;
using TestStack.White.UIItems.ListBoxItems;
using TestStack.White.UIItems.WindowItems;
using System;
using System.Collections;

namespace MUV.FormObjects
{
    public class DetailedSummaryListForm
    {
        public DetailedSummaryListForm()
        {

        }

        #region form element
        
        #region Tool bar

        #endregion

        #endregion

        #region Form action

        #endregion

        #region Public data
        #endregion

        /// <summary>
        ///Логирование
        /// </summary>
        /// <param name="msg">Сообщение в лог</param>
        private void Trace(string msg)
        {
            Log.Trace($"{ToString()}: {msg}", Level.Form);
        }
    }
}
