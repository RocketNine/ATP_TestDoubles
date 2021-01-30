using NUnit.Framework;
using PosTerminal;

namespace PosTerminalTests
{
    public class Tests
    {
        [Test]
        public void VerifySale_AmountUnderSingleChargeLimit_IsApproved()
        {
            // This test uses the real CcVerifier class and takes a long time
            PosTerminal.PosTerminal sut = new PosTerminal.PosTerminal();
            
            Assert.DoesNotThrow(() =>
            {
                sut.VerifySale(10.0);
            });
        }

        [Test]
        [Ignore("Using a mock runs faster as we bypass the costly call to real CcVerifier")]
        public void VerifySale_viaMock_AmountUnderSingleChargeLimit_IsApproved()
        {
            ICcVerifier mockCcVerifier = new MockCcVerifier();

            PosTerminal.PosTerminal sut = new PosTerminal.PosTerminal(mockCcVerifier);
            
            Assert.DoesNotThrow(() =>
            {
                sut.VerifySale(10.0);
            });
        }
    }

    public class MockCcVerifier : ICcVerifier
    {
        public bool ApproveCharge(double amount)
        {
            return true;
        }
    }
}