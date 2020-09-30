using System;
using System.Collections.Generic;
using System.Text;

namespace CykelLib
{
    public class Cykel
    {
        private int _id;
        private string _farve;
        private double _pris;
        private int _gear;

        public Cykel()
        {

        }

        public Cykel(int id, string farve, double pris, int gear)
        {
            _id = id;
            _farve = farve;
            _pris = pris;
            _gear = gear;
        }

        public int Id
        {
            get => _id;
            set => _id = value;
        }

        public string Farve
        {
            get => _farve;
            set
            {
                if (value.Length < 1) throw new ArgumentOutOfRangeException();
                _farve = value;
            }
        }

        public double Pris
        {
            get => _pris;
            set
            {
                if (value <= 0) throw new ArgumentOutOfRangeException();
                _pris = value;
            }
        }

        public int Gear
        {
            get => _gear;
            set
            {
                if (value < 3 || value > 32) throw new ArgumentOutOfRangeException();
                _gear = value;
            }
        }

        public override string ToString()
        {
            return $"{nameof(Id)}: {Id}, {nameof(Farve)}: {Farve}, {nameof(Pris)}: {Pris}, {nameof(Gear)}: {Gear}";
        }
    }
}
