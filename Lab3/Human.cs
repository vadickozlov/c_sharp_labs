using System;
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
}