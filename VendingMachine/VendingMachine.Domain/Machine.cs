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
                foreach (var billete in _billetes)
                {
                    if (_moneyToReturn - billete >= 0)
                    {
                        AgregarAlVuelto(billete, ref change);
                        _moneyToReturn -= billete;
                        break;
                    }
                }
            }

            return change;
        }

        private bool ThereIsMoneyToReturn()
        {
            return _moneyToReturn > 0;
        }

        private void AgregarAlVuelto(int billete, ref Dictionary<int, int> change)
        {
            if (change.ContainsKey(billete))
                change[billete]++;
            else
                change.Add(billete, 1);
        }
    }

}
