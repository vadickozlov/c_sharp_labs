using System;

namespace Lab {
    public class Director : Human, ILeader {
        public Director(string name, string surname, int age = 0) : base(name, surname, age) { }
        public void Punish(Pupil pupil) {
            Console.WriteLine($"{pupil.Name}, I'll expel you from school!!!");
        }
        public void Compliment(Pupil pupil) {
            Console.WriteLine($"{pupil.Name}, well done! You are pride of our school.");
        }
    }
}