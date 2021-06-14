using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WebApi.Data;
using WebApi.Models;
using WebApi.Requests.CommandRequests;

namespace WebApi.Handlers.CommandHandlers
{
    public class AddProductHandler : IRequestHandler<AddProductCommand, Product>
    {
        private readonly ApplicationDbContext _context;

        public AddProductHandler(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Product> Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
            Product newProduct = new() { Name = request.Name, Price = request.Price };
            await _context.AddAsync(newProduct, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return newProduct;
        }
    }
}
