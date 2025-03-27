using Ambev.DeveloperEvaluation.Domain.Common;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    public class Customer : BaseEntity
    {
        public Customer(string cPF, string name)
        {
            CPF = cPF;
            Name = name;
        }

        public Customer()
        {
            
        }

        public string CPF { get; set; }
        public string Name { get; set; }

    }
}
