using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Brands.Commands.Create
{
    public class CreateBrandCommand:IRequest<CreatedBrandResponse>
    {
        public string Name { get; set; }
        public class CreateBrandCommandHandler : IRequestHandler<CreateBrandCommand, CreatedBrandResponse> //sana böyle commend gönderilirse şunun (CreateBrandCommandHandler) içini çalıştır
        {
            public Task<CreatedBrandResponse>? Handle(CreateBrandCommand request, CancellationToken cancellationToken)
            {
                CreatedBrandResponse createdBrandResponse = new CreatedBrandResponse();
                createdBrandResponse.Name = request.Name;
                createdBrandResponse.Id = new Guid();
                return null;
            }
        }
    }
}
