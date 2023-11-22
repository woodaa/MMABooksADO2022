namespace MMABooksBusinessClasses {
    public class Customer {
        public Customer() { }

        public Customer(int id, string name, string address, string city, string state, string zipcode) {
            CustomerID = id;
            Name = name;
            Address = address;
            City = city;
            State = state;
            ZipCode = zipcode;
        }

        private int customerID;

        public int CustomerID {
            get => customerID;
            set {
                if (value >= 0) customerID = value;
                else throw new ArgumentOutOfRangeException("The customer id must be a number of 0 or higher.");
            }
        }

        public string Name { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        private string state;

        public string State {
            get => state;
            set {
                // Normally would be "==" but due to the "bad data" mentioned in State.cs, this code requires "<=" instead to properly work
                if (value.Length <= 2) state = value;
                else throw new ArgumentOutOfRangeException("The state name must be exactly 2 characters long.");
            }
        }

        private string zipCode;

        public string ZipCode {
            get => zipCode;
            set {
                if (value.Length >= 5) zipCode = value;
                else throw new ArgumentOutOfRangeException("The ZIP code must contain 5 or more characters.");
            }
        }

        public override string ToString() => $"{CustomerID} | {Name} | {Address} | {City} | {State} | {ZipCode}";
    }
}
