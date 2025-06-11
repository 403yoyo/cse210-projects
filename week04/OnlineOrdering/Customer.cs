namespace OnlineOrdering
{
    class Customer
    {
        private string name;
        private Address address;

        public Customer(string name, Address address)
        {
            this.name = name;
            this.address = address;
        }

        public bool IsDomestic() => address.IsDomestic();

        public string GetName() => name;

        public Address GetAddress() => address;
    }
}
