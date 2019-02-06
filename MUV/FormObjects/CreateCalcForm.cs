using System;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using System.Diagnostics;
using MUV.ModelData;
using System.Windows.Automation;
using TestTools;
using TestStack.White.UIItems.WindowItems;
using TestStack.White.UIItems.ListBoxItems;

namespace MUV.FormObjects
{
    public class CreateCalcForm
    {
        #region Form element

        protected Window _formCalculationRegistryNew
        {
            get
            {
                return AppManager.Instance.MainWindow.ModalWindow(SearchCriteria.ByAutomationId("formCalculationRegistryNew"));
            }
        }

        protected ComboBox _cboBranch
        {
            get
            {
                return AppManager.Instance.MainWindow.Get<ComboBox>(SearchCriteria.ByAutomationId("cboBranch"));
            }
        }

        protected ComboBox _cboBonusProgram
        {
            get
            {
                return AppManager.Instance.MainWindow.Get<ComboBox>(SearchCriteria.ByAutomationId("cboBonusProgram"));
            }
        }

        protected CheckBox _chkIsRetention
        {
            get
            {
                return AppManager.Instance.MainWindow.Get<CheckBox>(SearchCriteria.ByAutomationId("chkIsRetention"));
            }
        }

        protected Button _btnBeneficiarySelect
        {
            get
            {
                return AppManager.Instance.MainWindow.Get<Button>(SearchCriteria.ByAutomationId("btnBeneficiarySelect"));
            }
        }

        protected Button _btnInsurerSelect
        {
            get
            {
                return AppManager.Instance.MainWindow.Get<Button>(SearchCriteria.ByAutomationId("btnInsurersSelect"));
            }
        }

        protected Button _btnInsurerType
        {
            get
            {
                return AppManager.Instance.MainWindow.Get<Button>(SearchCriteria.ByAutomationId("btnInsuranceTypeSelect"));
            }
        }

        protected TextBox _filterBeneficiary
        {
            get
            {
                return AppManager.Instance.MainWindow.Get<TextBox>(SearchCriteria.ByAutomationId("PART_TextBoxFilter"));
            }
        }

        protected Button _btnSave
        {
            get
            {
                return AppManager.Instance.MainWindow.Get<Button>(SearchCriteria.ByAutomationId("btnSave"));
            }
        }

        protected ListView _dataTable
        {
            get
            {
                return AppManager.Instance.MainWindow.Get<ListView>(SearchCriteria.ByAutomationId("DGrid"));
            }
        }

        protected TextBox _txtPaymentDocNumber
        {
            get
            {
                return AppManager.Instance.MainWindow.Get<TextBox>(SearchCriteria.ByAutomationId("txtPaymentDocNumber"));
            }
        }

        protected TextBox _txtAcceptanceCertificateNumber
        {
            get
            {
                return AppManager.Instance.MainWindow.Get<TextBox>(SearchCriteria.ByAutomationId("txtAcceptanceCertificateNumber"));
            }
        }

        protected CheckBox _chkFilterPaymentsDate
        {
            get
            {
                return AppManager.Instance.MainWindow.Get<CheckBox>(SearchCriteria.ByAutomationId("chkFilterPaymentsDate"));
            }
        }

        protected DateTimePicker _dtFilterPaymentsDateStart
        {
            get
            {
                return AppManager.Instance.MainWindow.Get<DateTimePicker>(SearchCriteria.ByAutomationId("dtFilterPaymentsDateStart"));
            }
        }

        protected DateTimePicker _dtFilterPaymentsDateEnd
        {
            get
            {
                return AppManager.Instance.MainWindow.Get<DateTimePicker>(SearchCriteria.ByAutomationId("dtFilterPaymentsDateEnd"));
            }
        }

        protected Button _btnCreate
        {
            get
            {
                return AppManager.Instance.MainWindow.Get<Button>(SearchCriteria.ByAutomationId("btnCreate"));
            }
        }

        protected DateTimePicker _dtCalculationDateTo
        {
            get
            {
                return AppManager.Instance.MainWindow.Get<DateTimePicker>(SearchCriteria.ByAutomationId("dtCalculationDateTo"));
            }
        }
        #endregion

        #region Form action
        /// <summary>
        /// Выбрать филиал
        /// </summary>
        public void SelectBranch(string branch)
        {
            Trace("CreateCalcForm: Выбираем филиал " + branch);
            _cboBranch.Select(branch);
        }
        /// <summary>
        /// Выбрать программу
        /// </summary>
        public void SelectProgramm(string programm)
        {
            Trace("CreateCalcForm: Выбираем бонусную программу = " + programm);
            _cboBonusProgram.Select(programm);
        }

        /// <summary>
        /// Установить чекбокс удержание
        /// </summary>
        public void Hold()
        {
            Trace("CreateCalcForm: Устанавлеваем чек бокс удержание ");
            _chkIsRetention.Select();
        }
        /// <summary>
        /// Выбрать получателя
        /// </summary>
        public void BeneficiarySelect(string beneficiary)
        {
            Trace("CreateCalcForm: Выбираем получателя = " + beneficiary);
            _btnBeneficiarySelect.Click();
            _filterBeneficiary.SetValue(beneficiary);
            //var test = AppManager.Instance.MainWindow.Get<ListView>(SearchCriteria.ByAutomationId("DGrid"));
            foreach (var row in _dataTable.Rows)
            {
                foreach (var cell in row.Cells)
                {
                    if (cell.Name.Contains(beneficiary))
                    {
                        row.Click();
                        break;
                    }
                }                                    
            }
            _btnSave.Click();
        }
        /// <summary>
        /// Выбор страхователя
        /// </summary>
        public void InsurersSelect(string InsurersCode1, string InsurersCode2)
        {
            Trace("CreateCalcForm: Выбираем страхователя " + InsurersCode1 + " " + InsurersCode2);
            _btnInsurerSelect.Click();
            foreach (var row in _dataTable.Rows)
            {
                if (string.Equals(row.Cells[2].Text, InsurersCode1))
                {
                    row.Cells[0].DoubleClick();
                }else if (string.Equals(row.Cells[2].Text, InsurersCode2)){
                    row.Cells[0].DoubleClick();
                }
            }

            _btnSave.Click();
        }
        /// <summary>
        /// Выбор вида страхования
        /// </summary>
        public void VidStrahSelect(string Vidstrah1, string Vidstrah2)
        {
            Trace("CreateCalcForm: Выбираем вид страхования " + Vidstrah1 + " "+Vidstrah2);
            _btnInsurerType.Click();
            foreach (var row in _dataTable.Rows)
            {
                //TODO: Тоже не понял смысла или, но оставлю это условие
                if (row.Cells[2].Text == Vidstrah1 || row.Cells[2].Text == Vidstrah2)
                    row.Cells[0].DoubleClick();
            }
            _btnSave.Click();
        }
        /// <summary>
        /// Фильтр по номеру документа
        /// </summary>
        /// <param name="DocNumber"></param>
        public void TxtPaymentDocNumberFilter(string DocNumber)
        {
            Trace("CreateCalcForm: Заполняем фильтр номер документа = " + DocNumber);
            _txtPaymentDocNumber.SetValue(DocNumber);
        }
        /// <summary>
        /// Фильтр по АВР
        /// </summary>
        public void TxtAVRFilter(string AVRNumber)
        {
            Trace("CreateCalcForm: Заполняем фильтр АВР = " + AVRNumber);
            _txtAcceptanceCertificateNumber.SetValue(AVRNumber);

        }
        /// <summary>
        /// Фильтр на дату расчетов
        /// </summary>
        /// <param name="obj"></param>
        public void CalulationDateToFilter(CalculationDate Date)
        {
            //Trace("CreateCalcForm: Открываем фильтр Расчет на дату");
            //var Date = obj as CalculationDate;
           // AppManager.Instance.MainWindow.ModalWindow(SearchCriteria.ByAutomationId("formCalculationRegistryNew"));
            var chageDate = new DateTime(int.Parse(Date.Year), int.Parse(Date.Month), int.Parse(Date.Day));
            //Дата обновляется два раза для того что бы обновить день
            Trace("CreateCalcForm: Заполняем фильтр Расчет на дату = "+ chageDate);
            _dtCalculationDateTo.SetDate(chageDate, DateFormat.DayMonthYear);
            _dtCalculationDateTo.SetDate(chageDate, DateFormat.DayMonthYear);
            //SetDate(DateTime.Now.AddMonths(int.Parse(Date.Month))
            //, DateFormat.DayMonthYear);
        }
        /// <summary>
        /// Период страхового взноса
        /// </summary>
        /// <param name="obj1">DateStart</param>
        /// <param name="obj2">DateEnd</param>
        public void InsurancePremiumPeriod(CalculationDate DateStart, CalculationDate DateEnd)
        {
            Trace("CreateCalcForm: Заполнение периода страхового взноса");
            _chkFilterPaymentsDate.Select();
            var chageDateStart = new DateTime(int.Parse(DateStart.Year), int.Parse(DateStart.Month), int.Parse(DateStart.Day));
            var changeDateEnd = new DateTime(int.Parse(DateEnd.Year), int.Parse(DateEnd.Month), int.Parse(DateEnd.Day));
            //Дата обновляется два раза для того что бы обновить день
            Trace("CreateCalcForm: Устанавливаем дату начала = "+ chageDateStart.ToString());
            _dtFilterPaymentsDateStart.SetDate(chageDateStart, DateFormat.DayMonthYear);
            _dtFilterPaymentsDateStart.SetDate(chageDateStart, DateFormat.DayMonthYear);

            Trace("CreateCalcForm: Устанавливаем дату оконвания = " + changeDateEnd.ToString());
            _dtFilterPaymentsDateEnd.SetDate(changeDateEnd, DateFormat.DayMonthYear);
            _dtFilterPaymentsDateEnd.SetDate(changeDateEnd, DateFormat.DayMonthYear);
        }

        /// <summary>
        /// Нажать кнопуку создать реестр и перейти в форму деталицачия расчета
        /// </summary>
        public void BtnCreateClick()
        {
            Trace("CreateCalcForm: Нажимаем кнопку создать");
            _btnCreate.Click();
        }

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
