public class POSTerminal {
    ICCVerifier ccVerifier;

    POSTerminal() {
        this.ccVerifier = CCVerifier.getInstance();
    }

    POSTerminal(ICCVerifier ccVerifier) {
        this.ccVerifier = ccVerifier;
    }

    void verifySale(double amount) throws InvalidCharge {
        if (!ccVerifier.approveCharge(amount)) {
            throw new InvalidCharge();
        }
    }

    public static class InvalidCharge extends Throwable {
        public InvalidCharge() {
            super("Charge exceeds single transaction amount or credit limit");
        }
    }
}
