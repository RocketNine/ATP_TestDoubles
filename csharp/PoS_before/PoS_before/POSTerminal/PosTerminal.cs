using System;

namespace POSTerminal
{
    public class PosTerminal
    {
        private CCVerifier ccVerifier;

        public PosTerminal()
        {
            this.ccVerifier = CCVerifier.getInstance();
        }
        
        void VerifySale(double amount)
        {
            if (!ccVerifier.approveCharge(amount))
            {
                throw new InvalidChargeException();
            }
        }
    }

    internal class InvalidChargeException : Exception
    {
        public InvalidChargeException() : 
            base("Charge exceeds single transaction amount or credit limit")
        {
        }
    }
}