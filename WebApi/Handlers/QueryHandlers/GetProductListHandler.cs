using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WebApi.Data;
using WebApi.Models;
using WebApi.Requests.QueryRequests;

namespace WebApi.Handlers.QueryHandlers
{
    public class GetProductListHandler : IRequestHandler<GetProductListQuery, List<Product>>
    {
        private readonly ApplicationDbContext _context;

        public GetProductListHandler(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<Product>> Handle(GetProductListQuery request, CancellationToken cancellationToken)
        {
            var output = await _context.Products.ToListAsync(cancellationToken: cancellationToken);
            return output;
        }
    }
}
