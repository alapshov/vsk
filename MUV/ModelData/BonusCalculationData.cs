using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MUV.ModelData
{
    public class BonusCalculationData
    {
        /// <summary>
        /// Филиал
        /// </summary>
        public string Branch { get; set; }
        /// <summary>
        /// Бонусная программа
        /// </summary>
        public string Programm { get; set; }
        /// <summary>
        /// Получатель
        /// </summary>
        public string Beneficiary { get; set; }
        /// <summary>
        /// Код получателя
        /// </summary>
        public string BeneficiaryCode { get; set; }
        /// <summary>
        /// Номер платежного документа
        /// </summary>
        public string DocNumber { get; set; }
        /// <summary>
        /// Номер АВР
        /// </summary>
        public string AVR { get; set; }
        /// <summary>
        /// Результаты реестра расчетов
        /// </summary>
        public string TestName { get; set; }
        /// <summary>
        /// Расчет на дату
        /// </summary>
        public CalculationDate CalculationDate { get; set; }
        /// <summary>
        /// Начало периода страхового взноса
        /// </summary>
        public CalculationDate InsurancePremiumDateStart { get; set; }
        /// <summary>
        /// Окончание периода страхового взноса
        /// </summary>
        public CalculationDate InsurancePremiumDateEnd { get; set; }
        /// <summary>
        /// Код страхователя 1
        /// </summary>
        public string InsurersCode1 { get; set; }
        /// <summary>
        /// Код страхователя 2
        /// </summary>
        public string InsurersCode2 { get; set; }
        /// <summary>
        /// Вид страхования 1
        /// </summary>
        public string VidStrah1 { get; set; }
        /// <summary>
        /// Вид страхование 2
        /// </summary>
        public string VidStrah2 { get; set; }
        /// <summary>
        /// Список эталонных значений для проверки результата
        /// </summary>
        public List<RegistryLine> RegistryResult { get; set; }
        public string HoldValue { get; set; }

        /// <summary>
        /// Переопределение для формирования имени теста
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Programm + ", " + TestName + ", "+ Beneficiary;
        }

    }
}
