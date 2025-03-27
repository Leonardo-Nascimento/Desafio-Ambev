using Ambev.DeveloperEvaluation.Domain.Common;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    public class StoreBranch : BaseEntity
    {
        public StoreBranch(string nameBranch, int number, string cEP, string state, string city)
        {
            NameBranch = nameBranch;
            Number = number;
            CEP = cEP;
            State = state;
            City = city;
        }

        public StoreBranch(long id, string nameBranch, int number, string cEP, string state, string city)
        {
            SetId(id);
            NameBranch = nameBranch;
            Number = number;
            CEP = cEP;
            State = state;
            City = city;
            CreationDate = DateTime.Now.Date;
        }

        public StoreBranch()
        {
            
        }

        public string NameBranch { get; set; }
        public int Number { get; set; }
        public string CEP { get; set; }
        public string State { get; set; }
        public string City { get; set; }

    }
}
