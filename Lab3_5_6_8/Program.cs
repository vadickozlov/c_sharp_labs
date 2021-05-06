using System;
using System.Collections.Generic;

namespace Lab {
    class Program {
        static int GetMaxAgeOfGroupOfPeople(IPeopleContainable container) {
            List<Human> humans = container.GetPeople();
            int maxAge = -1;
            foreach (var human in humans) {
                if (human.Age > maxAge) maxAge = human.Age;
            }
            return maxAge;
        }

        static void Main(string[] args) {
            Pupil pupil1 = new Pupil("Vasiliy", "Petrov");
            Pupil pupil2 = new Pupil("Evgeniy", "Agazhelskiy");
            Pupil pupil3 = new Pupil("Alexey", "Ivanov");
            Pupil pupil4 = new Pupil("Boris", "Ivanov");
            BaseForm form1 = new BaseForm(10, 'A');
            form1.ChangeHoursOfSubject(Form.Subjects.Chemistry, 15);
            form1.ChangeHoursOfSubject(Form.Subjects.History, 15);
            form1.ChangeHoursOfSubject(Form.Subjects.Russian, 15);
            form1.ChangeHoursOfSubject(Form.Subjects.Physics, 15);
            form1.ChangeHoursOfSubject(Form.Subjects.Math, 15);
            ProfileForm form2 = new ProfileForm(
                form1, 
                10, 
                'B', 
                Form.Subjects.Math, 
                Form.Subjects.Physics, 
                4, 
                5);
            Console.WriteLine(form2.CountOfEducationalHoursBySubject[Form.Subjects.History]);
            Console.WriteLine(form2.CountOfEducationalHoursBySubject[Form.Subjects.Math]);
            Console.WriteLine(form2.CountOfEducationalHoursBySubject[Form.Subjects.Physics]);
            List<Form> schoolForms = new List<Form>();
            schoolForms.Add(form1);
            schoolForms.Add(form2);
            schoolForms[1].Headman = pupil2;
            form1.AddWastePaper(pupil1, 2);
            form2.AddWastePaper(pupil4, 10);
            MiddleSchoolForm form3 = new MiddleSchoolForm(5, 'B');
            form3.AddWastePaper(pupil3, 5000);
        }
    }
}