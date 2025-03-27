using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Handlers.StoreBranch.CreateStoreBranch
{
    public class CreateStoreBranchValidator : AbstractValidator<CreateStoreBranchCommand>
    {
        public CreateStoreBranchValidator()
        {
            RuleFor(x => x.NameBranch).NotNull().NotEmpty().WithMessage("O campo Nome da filial não pode ser vazio!");
            RuleFor(x => x.Number).GreaterThan(0).WithMessage("O campo número da filial deve ser maior que zero!");
            RuleFor(x => x.CEP).Length(8).WithMessage("O campo cep não pode ser vazio e deve conter 8 digitos!");
            RuleFor(x => x.State).NotNull().NotEmpty().WithMessage("O campo estado não pode ser vazio!");
            RuleFor(x => x.City).NotNull().NotEmpty().WithMessage("O campo cidade não pode ser vazio!");


        }
    }
}
