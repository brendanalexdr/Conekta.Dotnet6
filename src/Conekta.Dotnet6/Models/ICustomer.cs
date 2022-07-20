using ConektaDotnet6.Values;

namespace ConektaDotnet6.Models
{
    public interface ICustomer
    {
        bool Corporate { get; set; }
        string DefaultPaymentSourceId { get; set; }
        bool Deleted { get; set; }
        string Email { get; set; }
        string Name { get; set; }
        string Phone { get; set; }
    }
}