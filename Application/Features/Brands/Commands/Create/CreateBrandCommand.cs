﻿using Application.Features.Brands.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transaction;
using Domain.Entities;
using MediatR;

namespace Application.Features.Brands.Commands.Create
{
    public class CreateBrandCommand : IRequest<CreatedBrandResponse>, ITransactionalRequest, ICacheRemoverRequest, ILoggableRequest //ITransactional işaretlendiyse çalışabilir
    {
        public string Name { get; set; }

        public string CacheKey => "";

        public bool BypassCache => false;

        public string? CacheGroupKey => "GetBrands";

        public class CreateBrandCommandHandler : IRequestHandler<CreateBrandCommand, CreatedBrandResponse> //sana böyle commend gönderilirse şunun (CreateBrandCommandHandler) içini çalıştır
        {
            private readonly IBrandRepository _brandRepository;
            private readonly IMapper _mapper;
            private readonly BrandBusinessRules _brandBusinessRules;
            public CreateBrandCommandHandler(IBrandRepository brandRepository, IMapper mapper, BrandBusinessRules brandBusinessRules)
            {
                _brandRepository = brandRepository;
                _mapper = mapper;
                _brandBusinessRules = brandBusinessRules;
            }

            public async Task<CreatedBrandResponse>? Handle(CreateBrandCommand request, CancellationToken cancellationToken)
            {
               await _brandBusinessRules.BrandNameCannotBeDuplicatedInsorted(request.Name);

                Brand brand = _mapper.Map<Brand>(request);
                brand.Id = Guid.NewGuid();

                await _brandRepository.AddAsync(brand);
                //await _brandRepository.AddAsync(brand);

                CreatedBrandResponse createdBrandResponse =_mapper.Map<CreatedBrandResponse>(brand);
                return createdBrandResponse;
            }
        }
    }
}
