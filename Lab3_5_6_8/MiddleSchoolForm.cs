using System;

namespace Lab {
    public class MiddleSchoolForm : Form {
        private const int NEEDED_SUM_OF_COLLECTED_WASTE_PAPER = 100500;

        public MiddleSchoolForm(int number, char letter) : base(letter) {
            Number = number;
        }
        public override void AddWastePaper(Pupil pupil, int mass) {
            SumOfCollectedWastePaper += mass;
            Console.WriteLine($"Oh, {pupil.Name}, it's too little. Could you bring more?");
        }
        public override int Number {
            get => _number;
            set {
                if (value > 9 && value <= 11) {
                    throw new Exception("It's a high school form!");
                }
                if (value < 1 || value > 11) {
                    throw new Exception("Incorrect number");
                }
                _number = value;
            }
        }
    }
}