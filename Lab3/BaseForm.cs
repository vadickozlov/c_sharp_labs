using System;

namespace Lab {
    public class BaseForm : HighSchoolForm {
        public BaseForm(int number, char letter) : base(number, letter) { }

        public void ChangeHoursOfSubject(Subjects subject, uint newValue) {
            CountOfEducationalHoursBySubject[subject] = newValue;
        }
    }
}