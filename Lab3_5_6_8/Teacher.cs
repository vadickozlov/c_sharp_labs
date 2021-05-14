using System;

namespace Lab {
    public class Teacher : Human, ILeader {
        public Teacher(string name, string surname, int age = 0) : base(name, surname, age) { }
        public void Punish(Human pupil) {
            Console.WriteLine($"{pupil.Name}, I'll call your parents!");
        }

        public void Compliment(Human pupil) {
            Console.WriteLine($"{pupil.Name}, that's cool, you'll get good mark :)");
        }
    }
}