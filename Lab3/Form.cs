using System;
using System.Collections.Generic;

namespace School {
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