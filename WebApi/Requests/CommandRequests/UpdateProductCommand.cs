using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Models;

namespace WebApi.Requests.CommandRequests
{
    public record UpdateProductCommand(int Id, Product Product) : IRequest<Product>;
}
