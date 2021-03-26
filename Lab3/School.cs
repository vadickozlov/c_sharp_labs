using System;
using System.Collections.Generic;
using System.Text;

namespace School {
    public class Human {
        private string _name;
        private string _surname;
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
        public string ToString() {
            return _surname + " " + _name;
        }

        public Human(string name, string surname) {
            Name = name;
            Surname = surname;
        }
    }

    public class Pupil : Human, IComparable {
        public int CompareTo(object o) {
            Pupil? pupil = o as Pupil;
            if (pupil == null) {
                throw new Exception("Invalid comparing");
            }
            if (this.Surname.Equals(pupil.Surname)) {
                return string.Compare(this.Name, pupil.Name);
            }
            else {
                return string.Compare(this.Surname, pupil.Surname);
            }
        }
        public Pupil(string name, string surname) : base(name, surname) { }
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
            _pupils.Sort();
            if (_pupils.Count > MaxPupilsCount) {
                MaxPupilsCount = _pupils.Count;
            }
        }
        public void AddPupil(string name, string surname) { 
            _pupils.Add(new Pupil(name, surname));
            _pupils.Sort();
            if (_pupils.Count > MaxPupilsCount) {
                MaxPupilsCount = _pupils.Count;
            }
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