using System;

namespace Lab {
    public class Pupil : Human, IComparable {
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
        }
        
    }
}