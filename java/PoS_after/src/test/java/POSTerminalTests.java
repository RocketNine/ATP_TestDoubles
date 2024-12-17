import org.junit.jupiter.api.Disabled;
import org.junit.jupiter.api.Test;

import static org.junit.jupiter.api.Assertions.fail;

public class POSTerminalTests {

    @Test
    public void VerifySale_AmountUnderSingleChargeLimit_IsApproved() {
        // Using the real instance is costly in terms of time

        POSTerminal sut = new POSTerminal();

        try {
            sut.verifySale(10);
        } catch (POSTerminal.InvalidChargeException e) {
            fail("Amount was under Single Charge Amount - exception not expected!");
        }
    }

    @Test
    @Disabled("Remove to show faster feedback by using Test Double")
    public void VerifySale_ViaMock_AmountUnderSingleChargeLimit_IsApproved() {
        ICCVerifier mockCCVerifier = new MockCCVerifier();

        POSTerminal sut = new POSTerminal(mockCCVerifier);

        try {
            sut.verifySale(10);
        } catch (POSTerminal.InvalidChargeException e) {
            fail("Amount was under Single Charge Amount - exception not expected!");
        }
    }

    class MockCCVerifier implements ICCVerifier {

        @Override
        public boolean approveCharge(double amount) {
            return true;
        }
    }
}
