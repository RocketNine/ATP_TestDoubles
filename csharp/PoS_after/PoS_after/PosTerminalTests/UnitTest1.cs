using NUnit.Framework;

namespace PosTerminal
{
    public class Tests
    {
        [Test]
        public void VerifySale_AmountUnderSingleChargeLimit_IsApproved()
        {
            // This test uses the real CcVerifier class and takes a long time
            PosTerminal sut = new PosTerminal();
            
            sut.VerifySale(10.0);
            
            Assert.Pass("no exception was expected");
        }

        [Test]
        [Ignore("Using a mock runs faster as we bypass the costly call to real CcVerifier")]
        public void VerifySale_viaMock_AmountUnderSingleChargeLimit_IsApproved()
        {
            ICcVerifier mockCcVerifier = new MockCcVerifier();

            PosTerminal sut = new PosTerminal(mockCcVerifier);
            
            sut.VerifySale(10.0);

            Assert.Pass("no exception was expected");
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