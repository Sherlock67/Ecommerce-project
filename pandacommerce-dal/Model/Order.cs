namespace pandacommerce_dal.Model
{
    public class Order
    {

        public int OrderId { get; set; }

        public DateTime OrderDate { get; set; }

        public DateTime ShippedDate { get; set; }

        public string OrderStatus { get; set; }
        
        public IEnumerable<Customer> CustomersOrder { get; set; }
    }
}
