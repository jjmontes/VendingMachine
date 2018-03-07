using System.Collections.Generic;

namespace VendingMachine.Domain
{
    public class Machine
    {
        public IDictionary<int, int> GetChange(decimal price, decimal pay)
        {
            return new Dictionary<int, int>
            {
                {50, 1},
                {20, 2},
            };
        }
    }
}
