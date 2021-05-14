using System;
using System.Collections.Generic;

namespace Lab {
    class Program {
        static int GetMaxAgeOfGroupOfPeople(IPeopleContainable container) => container.GetPeople().Count;

        static void AddWastePaperToClasses(List<Pupil> pupils, List<Form> forms) {
            for (int i = 0; i < Math.Min(pupils.Count, forms.Count); i++) {
                forms[i].AddWastePaper(pupils[i], i);
            }
        }

        static void PunishPupilByGroupOfLeaders(Pupil pupil, List<ILeader> leaders) {
            foreach (var leader in leaders) {
                leader.Punish(pupil);
            }
        }

        static void Main(string[] args) {
            Pupil pupil1 = new Pupil("Vasiliy", "Petrov");
            Pupil pupil2 = new Pupil("Evgeniy", "Agazhelskiy");
            Pupil pupil3 = new Pupil("Alexey", "Ivanov");
            Pupil pupil4 = new Pupil("Boris", "Ivanov");
            pupil3.Age = 17;
            BaseForm form1 = new BaseForm(10, 'A');
            form1.AddPupil(pupil1);
            form1.AddPupil(pupil2);
            form1.AddPupil(pupil3);
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
            MiddleSchoolForm form3 = new MiddleSchoolForm(5, 'B');
            List<Pupil> pupils = new List<Pupil>() { pupil1, pupil2, pupil3, pupil4 };
            List<Form> forms = new List<Form>() { form1, form2, form3 };
            AddWastePaperToClasses(pupils, forms);
            Teacher teacher = new Teacher("Ivan", "Petrovich");
            Director director = new Director("Alena", "Eduardovna");
            List<ILeader> leaders = new List<ILeader>() {teacher, director};
            PunishPupilByGroupOfLeaders(pupil4, leaders);
        }
    }
}