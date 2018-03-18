using System;
using System.Collections.Generic;
using System.Linq;

namespace VendingMachine.Domain
{
    public class Bills
    {
        private readonly Dictionary<int, int> _bills;

        public Bills()
        {
            _bills = new Dictionary<int, int>
            {
                {100, 0},
                {50, 0},
                {20, 0},
                {10, 0},
                {5, 0},
            };
        }

        internal void AddOneBill(int value)
        {
            if (!_bills.ContainsKey(value)) throw new NotImplementedException();
            
            _bills[value]++;
        }

        public int Count()
        {
            return _bills.Values.Count(v => v > 0);
        }

        public int CountFromBill(int value)
        {
            return _bills[value];
        }
    }
}
