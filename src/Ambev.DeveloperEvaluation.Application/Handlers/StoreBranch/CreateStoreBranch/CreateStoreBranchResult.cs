using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.Handlers.StoreBranch.CreateStoreBranch
{
    public class CreateStoreBranchResult
    {
        public long Id { get; set; }

        public CreateStoreBranchResult(long id)
        {
            Id = id;
        }
    }
}
