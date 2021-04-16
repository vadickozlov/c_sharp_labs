using System;

namespace Lab {
    public abstract class HighSchoolForm : Form{
        public override int Number {
            get => _number;
            set {
                if (value < 10 && value > 0) {
                    throw new Exception("It's not a high school form!");
                }
                if (value < 1 || value > 11) {
                    throw new Exception("Incorrect number");
                }
                _number = value;
            }
        }
        protected HighSchoolForm(int number, char letter) : base(letter) {
            Number = number;
        }
        private const int NEEDED_SUM_OF_COLLECTED_WASTE_PAPER = 1;
        
        public override void AddWastePaper(Pupil pupil, int mass) {
            SumOfCollectedWastePaper += mass;
            Console.WriteLine($"Oh, {pupil.Name}, that's cool, thank you!");
        }
    }
}