using QTTimeManagement.Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QTTimeManagement.Logic.Entities
{
    [Table("CollectiveAgreements", Schema = "timemanagement")]
    public class CollectiveAgreement : ValidityEntity
    {
        #region nighthours
        public TimeOnly? NightHoursBegin { get; set; }

        public TimeOnly? NightHoursEnd { get; set; }
        #endregion

        #region break
        /*Die tägliche unbezahlte Ruhepause beträgt höchstens eineinhalb Stunden.

        Im Kraftfahrlinienverkehr kann die unbezahlte Ruhepause in einen Teil von mindestens 30 Minuten und einen bzw. mehrere Teile von mindestens 15 Minuten geteilt werden.

        Bei Teilung der unbezahlten Ruhepause ist der erste Teil spätestens nach sechs Stunden einzuhalten.

        Der 30-minütige Teil der unbezahlten Ruhepause ist im Dienstplan der Fahrdienstleitung oder im Einsatzplan im Vorhinein zu fixieren.

        Der unbezahlte Ruhepausenteil von 30 Minuten muss in einem Zeitraum von frühestens 3 Stunden nach Beginn bzw. spätestens 3 Stunden vor Ende des Dienstes liegen. Wird dem Lenker der unbezahlte Ruhepausenteil von 30 Minuten innerhalb dieses Zeitraumes nicht gewährt, beträgt die tägliche unbezahlte Ruhepause höchstens 1 Stunde.

        Ein Ruhepausenteil von 15 Minuten ist dann unbezahlt, wenn er innerhalb eines Zeitraumes von frühestens 2 Stunden nach Beginn bzw. spätestens 2 Stunden vor Ende des Dienstes liegt.        
        */

        public TimeSpan? MaximumBreakDuration { get; set; }

        public TimeSpan? MinWorkingTimeAfterBegin { get; set; }
        public TimeSpan? MinWorkingTimeBeforeEnd { get; set; }
        public TimeSpan? MinTime30MinBreakAfterBegin { get; set; }
        public TimeSpan? MinTime30MinBreakBeforeEnd { get; set; }
        #endregion

        #region rest time
        /*
        Die tägliche Ruhezeit kann 3 x wöchentlich auf mindestens 9 zusammenhängende Stunden verkürzt werden. 
        Jede Verkürzung der täglichen Ruhezeit ist, bis zum Ende der Folgewoche, 
        durch eine zusätzliche Ruhezeit im Ausmaß der Verkürzung auszugleichen. 
        Diese Ausgleichsruhezeit ist zusammen mit einer anderen, mindestens 8-stündigen Ruhezeit zu gewähren.
        Wenn eine tägliche Ruhezeit von insgesamt mindestens 12 Stunden eingehalten wird, 
        kann die tägliche Ruhezeit in zwei oder drei Abschnitten genommen werden, 
        von denen einer mindestens 8 zusammenhängende Stunden, die übrigen Teile jeweils 
        mindestens 1 Stunde betragen müssen. In diesem Fall beginnt eine neue Tagesarbeitszeit 
        nach Ablauf des mindestens 8-stündigen Teiles der Ruhezeit. 
        */

        #endregion

        #region operating time
        /*
        Die Einsatzzeit umfasst die zwischen zwei Ruhezeiten anfallende Arbeitszeit 
        und die Arbeitszeitunterbrechungen (einschließlich der täglichen unbezahlten Ruhepause 
        im Ausmaß von insgesamt höchstens eineinhalb Stunden pro Tag). 
        Bei Teilung der täglichen Ruhezeit oder bei Unterbrechung der täglichen Ruhezeit 
        bei kombinierter Beförderung beginnt eine neue Einsatzzeit nach Ablauf der gesamten Ruhezeit. 
        Bei Teilung der täglichen Ruhezeit im Kraftfahrlinienverkehr
        bis 50 km Linienstrecke beginnt eine neue Einsatzzeit nach Ablauf 
        des mindestens 8-stündigen Teiles der Ruhezeit.

        Die Einsatzzeit darf grundsätzlich 12 Stunden nicht überschreiten, 
        soweit nicht im Folgenden etwas Anderes geregelt ist:
        1. Fahrzeuge im Sinne von § 16 Absatz 3 Ziffer 2 AZG (Autobusse 
        mit mehr als 9 Sitzplätzen einschließlich des Fahrers)
        Gemäß § 16 Abs.3 AZG kann die Einsatzzeit über 12 Stunden hinaus soweit verlängert werden, 
        dass die innerhalb eines Zeitraumes von 24 Stunden, bei 2-Fahrerbesetzung innerhalb 
        eines Zeitraumes von 30 Stunden, vorgeschriebene tägliche Ruhezeit eingehalten wird.
        2. Fahrzeuge im Sinne von § 16 Absatz 4 AZG (Alle übrigen Fahrzeuge) 
        Die Einsatzzeit beim Lenken von Fahrzeugen im Sinne von § 16 Absatz 4 AZG 
        (Sonstige Fahrzeuge) beträgt maximal 14 Stunden.
         */

        public TimeSpan? MaxOperatingTime { get; set; }

        /*
        Wird vom Lenker im Kraftfahrlinienverkehr an einem Kalendertag eine Dienstleistung verlangt, 
        müssen unbeschadet der Dauer dieser Dienstleistung mindestens 6 Stunden 30 Minuten Arbeitszeit 
        verrechnet werden, wobei Abschnitt V entsprechend zu berücksichtigen ist. 
        */
        public TimeSpan? MinWorkingTime { get; set; }

        /*
        Für die Durchführung von Vor- und Abschlussarbeiten im Kraftfahrlinienverkehr ist daher in den Fällen, 
        in denen am Beginn und am Ende einer Einsatzzeit kein "fliegender Fahrerwechsel" vorliegt,
        dem Fahrpersonal der dafür notwendige Zeitaufwand in Form einer Zeitpauschale 
        von 25 Minuten einmalig für jede Tagesarbeitszeit vom Arbeitgeber zur Verfügung zu stellen.
        */
        public TimeSpan? PreperationAndPreworkTime { get; set; }

        #endregion

        #region overtime
        public int? OverTimeThresholdWeeklyHours { get; set; }
        public double? OvertimeSurchargeWeeklyHours { get; set; }
        public double? OvertimeSurchargeBeforeWeeklyHourThreshold { get; set; }
        public double? HolidaySurcharge { get; set; }


        #endregion

    }
}
