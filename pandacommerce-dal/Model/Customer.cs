using System.ComponentModel.DataAnnotations;

namespace pandacommerce_dal.Model
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }

        public string CustomerName { get; set; }

        public string CustomerPhoneNumber { get; set; }

        public string CustomerEmail { get; set; }

        public string CustomerAddress { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }

        public Order Order { get; set; }

    }
}
