using Domain.Enums;

namespace Domain.Entities
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SecondName { get; set; }
        public string FirstLastName { get; set; }
        public string SecondLastName { get; set; }
        public string RFC { get; set; }
        public DateTime RegistartionDate { get; set; } = DateTime.Now;
        public GenderType GenderType { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }

    }
}
