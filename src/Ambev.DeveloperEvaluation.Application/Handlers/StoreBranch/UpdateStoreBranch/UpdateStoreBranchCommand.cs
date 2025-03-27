using Ambev.DeveloperEvaluation.Application.ViewModel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.Handlers.StoreBranch.UpdateStoreBranch
{
    public class UpdateStoreBranchCommand : IRequest<ResultModel>
    {
        public long Id { get; set; }
        public string NameBranch { get; set; }
        public int Number { get; set; }
        public string CEP { get; set; }
        public string State { get; set; }
        public string City { get; set; }
    }
}
