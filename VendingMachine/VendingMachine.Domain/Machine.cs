using System.Collections.Generic;

namespace VendingMachine.Domain
{
    public class Machine
    {
        private int[] _billetes;

        public Machine()
        {
            _billetes = new int[5] { 100, 50, 20, 10, 5 };
        }

        public IDictionary<int, int> GetChange(decimal price, decimal pay)
        {
            var change = new Dictionary<int, int>();

            pay -= price;
            while (pay > 0)
            {
                foreach (var billete in _billetes)
                {
                    if (pay - billete >= 0)
                    {
                        AgregarAlVuelto(billete, ref change);
                        pay -= billete;
                        break;
                    }
                }
            }

            return change;
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
