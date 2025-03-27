using Ambev.DeveloperEvaluation.Common.Validation;

namespace Ambev.DeveloperEvaluation.Domain.Common;

public class BaseEntity : IComparable<BaseEntity>
{
    public BaseEntity()
    {
        CreationDate = DateTime.Now;
    }
    public long Id { get; private set; }
    public DateTime CreationDate { get; set; }
    public DateTime? UpdateDate { get; set; }
    public DateTime? DeletionDate { get; set; }


    public Task<IEnumerable<ValidationErrorDetail>> ValidateAsync()
    {
        return Validator.ValidateAsync(this);
    }

    public int CompareTo(BaseEntity? other)
    {
        if (other == null)
        {
            return 1;
        }

        return other!.Id.CompareTo(Id);
    }

    protected void SetId(long id)
    {
        Id = id;
    }
}
