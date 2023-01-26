using Microsoft.CodeAnalysis;

namespace Uber.Domain.Models
{
    public class Driver
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public Location Location { get; set; }
    }

}
