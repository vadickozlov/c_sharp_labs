using System;
using System.Collections.Generic;
using System.Text;

namespace School {
    public class Human {
        private string _name;
        private string _surname;
        private int _age;
        public static int MaxAge { get; private set; }
        public string Name {
            get => _name;
            set {
                if (string.IsNullOrEmpty(value)) {
                    throw new Exception("Name can't be null or empty");
                }
                StringBuilder newName = new StringBuilder(value.ToLower());
                newName[0] = Char.ToUpper(value[0]);
                _name = newName.ToString();
            }
        }
        public string Surname {
            get => _surname;
            set {
                if (string.IsNullOrEmpty(value)) {
                    throw new Exception("Surname can't be null or empty");
                }
                StringBuilder newSurname = new StringBuilder(value.ToLower());
                newSurname[0] = Char.ToUpper(value[0]);
                _surname = newSurname.ToString();
            }
        }
        public int Age {
            get => _age;
            set {
                if (value < 0) {
                    throw new Exception("Age can't be negative");
                }
                else {
                    _age = value;
                    if (value > MaxAge) {
                        MaxAge = value;
                    }
                }
            }
        }
        public string ToString() {
            return _surname + " " + _name;
        }
        public Human(string name, string surname, int age = 0) {
            Name = name;
            Surname = surname;
            Age = age;
        }
    }
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
    public class Form {
        private int _number;
        private char _letter;
        private List<Pupil> _pupils;
        private static int _maxPupilsCount = 0;
        public static int MaxPupilsCount { get; private set; }
        public char Letter {
            set {
                if (!char.IsLetter(value)) {
                    throw new ArgumentException();
                } else {
                    _letter = value;
                }
            }
            get => _letter;
        }
        public int Number { 
            set {
                if (value < 1 || value > 11) {
                    throw new ArgumentException();
                } else {
                    _number = value;
                }
            }
            get => _number; 
        }

        public int PupilsCount {
            get {
                return _pupils.Count;
            }
        }
        public void AddPupil(Pupil pupil) { 
            _pupils.Add(pupil);
            pupil.Form = this;
            _pupils.Sort();
            if (_pupils.Count > MaxPupilsCount) {
                MaxPupilsCount = _pupils.Count;
            }
        }
        public void ErasePupil(int index) {
            if (index < 0 || index >= _pupils.Count) {
                throw new Exception("Index out of bounds");
            }
            _pupils.RemoveAt(index);
        }
        public void ErasePupil(Pupil pupil) {
            _pupils.Remove(pupil);
        }
        public List<Pupil> GetPupils() {
            return _pupils;
        }
        public Pupil this[int index] {
            get => _pupils[index];
            set => _pupils[index] = value;
        }
        public Form(int number, char letter) {
            Number = number;
            Letter = letter;
            _pupils = new List<Pupil>();
        }
    }
}