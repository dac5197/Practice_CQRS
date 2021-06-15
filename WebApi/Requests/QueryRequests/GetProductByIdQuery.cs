using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Models;

namespace WebApi.Requests.QueryRequests
{
    public record GetProductByIdQuery(int Id) : IRequest<Product>;
}
