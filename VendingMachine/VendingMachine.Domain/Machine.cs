using System;

namespace VendingMachine.Domain
{
    public class Machine
    {
        private decimal _moneyToReturn;
        private decimal _price;
        private decimal _pay;

        public Machine Buy(decimal price)
        {
            _price = price;
            return this;
        }

        public Machine PayWith(decimal pay)
        {
            _pay = pay;
            return this;
        }

        public Bills GetChange()
        {
            var change = new Bills();
            _moneyToReturn = _pay - _price;

            while (ThereIsMoneyToReturn())
            {
                var billToReturn = GetBillToReturn(change.BillValues);
                change.AddOneBill(billToReturn);
                _moneyToReturn -= billToReturn;
            }

            return change;
        }

        private bool ThereIsMoneyToReturn()
        {
            return _moneyToReturn > 0;
        }

        private int GetBillToReturn(int[] bills)
        {
            foreach (var bill in bills)
            {
                if (_moneyToReturn - bill >= 0) return bill;
            }

            throw new NotImplementedException("Si no existe un billete para devolver... ¿que debería hacer el sistema?");
        }
    }
}
