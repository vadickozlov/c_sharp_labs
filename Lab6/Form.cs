using System;
using System.Collections.Generic;

namespace Lab {
    public abstract class Form{
        protected int _number;
        protected char _letter;
        protected List<Pupil> _pupils;
        protected static int _maxPupilsCount = 0;
        public int SumOfCollectedWastePaper { get; set; }
        public Dictionary<Subjects, uint> CountOfEducationalHoursBySubject { get; protected set; }

        public enum Subjects {
            Russian,
            Belorussian, 
            Math,
            Physics,
            Chemistry,
            Biology,
            History,
            PE,
            IT,
            OBZh
        };

        public Pupil Headman { get; set; }
        public static int MaxPupilsCount { get; protected set; }
        public abstract void AddWastePaper(Pupil pupil, int mass);
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
        public abstract int Number { set; get; }
        public int PupilsCount => _pupils.Count;
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

        public delegate void AnnouncementDelegate();

        public void MakeAnAnnouncement(AnnouncementDelegate action) {
            Console.WriteLine("Announcement: \n");
            action();
        }

        public Form(char letter) {
            Letter = letter;
            _pupils = new List<Pupil>();
            CountOfEducationalHoursBySubject = new Dictionary<Subjects, uint>();
            foreach (var item in Enum.GetValues(typeof(Subjects))) {
                CountOfEducationalHoursBySubject.Add((Form.Subjects)item, 0);
            }
        }
    }
}