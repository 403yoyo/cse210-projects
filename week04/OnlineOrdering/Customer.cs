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

        public bool IsDomestic()
        {
            return address.IsDomestic();
        }

        public string GetName()
        {
            return name;
        }

        public Address GetAddress()
        {
            return address;
        }
    }
}
