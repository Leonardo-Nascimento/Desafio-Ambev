using Ambev.DeveloperEvaluation.Application.ViewModel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.Handlers.StoreBranch.DeleteStoreBranch
{
    public class DeleteStoreBranchCommand : IRequest<ResultModel>
    {
        public long Id { get; set; }

        public DeleteStoreBranchCommand(long id)
        {
            Id = id;
        }
    }
}
