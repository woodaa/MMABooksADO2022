namespace MMABooksBusinessClasses {
    public class Product {
        public Product() { }

        public Product(string productcode, string description, decimal unitprice, int onhandquantity) {
            ProductCode = productcode;
            Description = description;
            UnitPrice = unitprice;
            OnHandQuantity = onhandquantity;
        }

        private string productCode;

        public string ProductCode {
            get => productCode;
            set {
                // Normally would be "==" but due to the "bad data" mentioned in State.cs, this code requires "<=" instead to properly work
                if (value.Length <= 4) productCode = value;
                else throw new ArgumentOutOfRangeException("The product code must be exactly 4 characters long.");
            }
        }

        public string Description { get; set; }

        private decimal unitPrice;

        public decimal UnitPrice {
            get => unitPrice;
            set {
                if (value > 0.0m) unitPrice = value;
                else throw new ArgumentOutOfRangeException("The unit price must be greater than 0.0.");
            }
        }

        public int OnHandQuantity { get; set; }

        public override string ToString() => $"{ProductCode} | {Description} | {UnitPrice} | {OnHandQuantity}";
    }
}
