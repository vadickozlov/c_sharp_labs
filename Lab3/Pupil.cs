using System;

namespace School {
    public class Pupil : Human, IComparable {
        public Form Form { get; internal set; }
        public int CompareTo(object o) {
            if (!(o is Pupil pupil)) {
                throw new Exception("Invalid comparing");
            }
            if (this.Surname.Equals(pupil.Surname)) {
                return string.Compare(this.Name, pupil.Name);
            } else {
                return string.Compare(this.Surname, pupil.Surname);
            }
        }
        public Pupil(string name, string surname, Form form = null, int age = 0) : base(name, surname, age) {
            Form = form;
        }
    }
}