using System;

namespace Lab {
    public delegate void PupilActionDelegate();
    public class Pupil : Human, IComparable {
        public int Reputation {
            private set;
            get;
        }
        public event PupilActionDelegate PunishNotify;

        public void ShowPunishMessage() {
            Console.WriteLine($"{this.Name} was punished.");
        }

        public void DecreaseReputation() {
            Reputation -= 5;
            Console.WriteLine($"Current pupil reputation: {Reputation}");
        }

        public void PunishByTeacher() {
            PunishNotify?.Invoke();
        }
        public Form Form { get; internal set; }
        public int CompareTo(object o) {
            if (!(o is Pupil pupil)) {
                throw new Exception("Invalid comparing");
            }
            if (this.Surname.Equals(pupil.Surname)) {
                return string.Compare(Name, pupil.Name);
            } else {
                return string.Compare(this.Surname, pupil.Surname);
            }
        }
        public Pupil(string name, string surname, int age = 0, Form form = null) : base(name, surname, age) {
            Form = form;
            Reputation = 0;
            PunishNotify += ShowPunishMessage;
            PunishNotify += DecreaseReputation;
        }
    }
}