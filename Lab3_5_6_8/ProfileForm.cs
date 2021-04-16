using System;

namespace Lab {
    public class ProfileForm : HighSchoolForm {
        public ProfileForm(int number, char letter, Subjects profileSubject1, Subjects profileSubject2)
            : base(number, letter) {
            ProfileSubject1 = profileSubject1;
            ProfileSubject2 = profileSubject2;
        }
        public ProfileForm(
            BaseForm baseForm, 
            int number, 
            char letter, 
            Subjects profileSubject1, 
            Subjects profileSubject2, 
            uint profileSubj1AdditionalHours,
            uint profileSubj2AdditionalHours) 
            : base(number, letter) {
            ProfileSubject1 = profileSubject1;
            ProfileSubject2 = profileSubject2;
            foreach (var sublect in Enum.GetValues(typeof(Subjects))) {
                CountOfEducationalHoursBySubject[(Subjects) sublect] = baseForm.CountOfEducationalHoursBySubject[(Subjects) sublect];
                CountOfEducationalHoursBySubject[profileSubject1] += profileSubj1AdditionalHours;
                CountOfEducationalHoursBySubject[profileSubject2] += profileSubj2AdditionalHours;
            }
            
        }
        public Subjects ProfileSubject1 { get; private set; }
        public Subjects ProfileSubject2 { get; private set; }
        
    }
}