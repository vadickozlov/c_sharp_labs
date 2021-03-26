using System;
using System.Collections.Generic;
using School;

namespace Lab3 {
    class Program {
        static void Main(string[] args) {
            Pupil pupil1 = new Pupil("Vasiliy", "Petrov");
            Pupil pupil2 = new Pupil("Evgeniy", "Agazhelskiy");
            Pupil pupil3 = new Pupil("Alexey", "Ivanov");
            Pupil pupil4 = new Pupil("Boris", "Ivanov");
            Form form1 = new Form(6, 'A');
            form1.AddPupil(pupil1);
            form1.AddPupil(pupil2);
            Form form2 = new Form(5, 'B');
            form2.AddPupil(pupil3);
            form2.AddPupil(pupil4);
            form2.AddPupil(new Pupil("Timur", "Bibekov"));
            for (int i = 0; i < form1.PupilsCount; i++) {
                Console.WriteLine(form1[i].ToString() + " ");
            }
            Console.WriteLine();
            List<Pupil> form2Pupils = form2.GetPupils();
            foreach (var pupil in form2Pupils) {
                Console.WriteLine(pupil.ToString() + " ");
            }
            Console.WriteLine();
            Console.WriteLine($"Maximal quantity of pupils is {Form.MaxPupilsCount}");
        }
    }
}