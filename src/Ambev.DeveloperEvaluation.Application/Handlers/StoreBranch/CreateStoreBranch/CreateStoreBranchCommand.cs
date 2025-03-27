using Ambev.DeveloperEvaluation.Application.ViewModel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.Handlers.StoreBranch.CreateStoreBranch
{
    public class CreateStoreBranchCommand : IRequest<ApiResponse>
    {
        public string NameBranch { get; set; }
        public int Number { get; set; }
        public string CEP { get; set; }
        public string State { get; set; }
        public string City { get; set; }
    }
}
