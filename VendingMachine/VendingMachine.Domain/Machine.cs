using System;
using System.Collections.Generic;

namespace VendingMachine.Domain
{
    public class Machine
    {
        private int[] _billetes;
        private decimal _moneyToReturn;

        public Machine()
        {
            _billetes = new int[5] { 100, 50, 20, 10, 5 };
        }

        public IDictionary<int, int> GetChange(decimal price, decimal pay)
        {
            var change = new Dictionary<int, int>();
            _moneyToReturn = pay;

            _moneyToReturn -= price;
            while (ThereIsMoneyToReturn())
            {
                var billToReturn = GetBillToReturn();
                AddBillToChange(billToReturn, ref change);
                _moneyToReturn -= billToReturn;
            }

            return change;
        }

        private int GetBillToReturn()
        {
            foreach (var billete in _billetes)
            {
                if (_moneyToReturn - billete >= 0) return billete;
            }

            throw new NotImplementedException("Si no existe un billete para devolver... ¿que debería hacer el sistema?");
        }

        private bool ThereIsMoneyToReturn()
        {
            return _moneyToReturn > 0;
        }

        private void AddBillToChange(int billete, ref Dictionary<int, int> change)
        {
            if (change.ContainsKey(billete))
                change[billete]++;
            else
                change.Add(billete, 1);
        }
    }

}
