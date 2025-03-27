namespace Ambev.DeveloperEvaluation.Domain.Models
{
    public class CustomerModel
    {
        public CustomerModel(long id, string cPF, string name, DateTime creationDate, DateTime? updateDate, DateTime? deletionDate)
        {
            Id = id;
            CPF = cPF;
            Name = name;
            CreationDate = creationDate;
            UpdateDate = updateDate;
            DeletionDate = deletionDate;
        }

        public CustomerModel()
        {
            
        }

        public long Id { get; set; }
        public string CPF { get; set; }
        public string Name { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public DateTime? DeletionDate { get; set; }

    }
}
