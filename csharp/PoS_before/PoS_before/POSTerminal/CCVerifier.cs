using System.Threading;

namespace POSTerminal
{
    public class CCVerifier
    {
        private static CCVerifier instance;
        private static double AVAILABLE_CREDIT = 2000;
        private static double SINGLE_CHARGE_LIMIT = 250;

        private CCVerifier()
        {
            // only access via getInstance
        }
        
        public static CCVerifier getInstance()
        {
            if (null == instance)
            {
                instance = new CCVerifier();
            }

            return instance;
        }

        public bool approveCharge(double amount)
        {
            ThisCallIsCostly();
            return SufficientFunds(amount);
        }

        private bool SufficientFunds(double amount)
        {
            return (amount <= AVAILABLE_CREDIT) && (amount <= SINGLE_CHARGE_LIMIT);
        }

        private void ThisCallIsCostly()
        {
            Thread.Sleep(10000);
        }
    }
}