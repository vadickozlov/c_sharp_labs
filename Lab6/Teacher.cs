using System;

namespace Lab {
    public class Teacher : Human, ILeader {
        public Teacher(string name, string surname, int age = 0) : base(name, surname, age) { }

        void CallParentsOfPupil(Pupil pupil) {
            
        }

        public void Punish(Pupil pupil) {
            Console.WriteLine($"{pupil.Name}, I'll call your parents!");
            pupil.PunishByTeacher();
        }

        public void Compliment(Pupil pupil) {
            Console.WriteLine($"{pupil.Name}, that's cool, you'll get good mark :)");
        }
    }
}