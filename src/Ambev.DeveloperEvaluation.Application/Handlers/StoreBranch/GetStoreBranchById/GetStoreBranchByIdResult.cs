using Ambev.DeveloperEvaluation.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.Handlers.StoreBranch.GetStoreBranchById
{
    public class GetStoreBranchByIdResult
    {
        public StoreBranchModel StoreBranchModel { get; set; }

        public GetStoreBranchByIdResult(StoreBranchModel storeBranchModel)
        {
            StoreBranchModel = storeBranchModel;
        }
    }
}
