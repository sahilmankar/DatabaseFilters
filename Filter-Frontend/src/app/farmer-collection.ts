export class FarmerCollection {
    constructor(
        public collectionId: number,
        public crop: string,
        public grade: string,
        public containerType: string,
        public quantity: number,
        public totalWeight: number,
        public tareWeight: number,
        public netWeight: number,
        public ratePerKg: number,
        public amount: number,
        public collectionDate: string,
        // public billId: number,
        public labourCharges: number,
        public totalAmount: number,
        public billingDate: string,
    ) { }
}
