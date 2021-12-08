using AutoMapper;
using Ecommerce.DomainService.Interfaces;
using Ecommerce.Repository.Interfaces;
using Ecommerce.CrossCutting.DTO.Size;
using Ecommerce.Data.Entities;
using System.Collections.Generic;

namespace Ecommerce.DomainService.Services
{
    public class SizeDomainService : ISizeDomainService
    {
        private readonly ISizeRepository _sizeRepository;
        private readonly IMapper _mapper;

        public SizeDomainService(ISizeRepository sizeRepository, IMapper mapper)
        {
            _sizeRepository = sizeRepository;
            _mapper = mapper;
        }

        public ReadSizeDTO Add(CreateSizeDTO createSizeDto)
        {
            var size = _mapper.Map<Size>(createSizeDto);
            _sizeRepository.Adicionar(size);

            return _mapper.Map<ReadSizeDTO>(size);
        }

        public IList<ReadSizeDTO> List()
        {
            var sizes = _sizeRepository.Listar();

            return sizes != null ? _mapper.Map<IList<ReadSizeDTO>>(sizes) : null;
        }

        public ReadSizeDTO GetById(int id)
        {
            var size = _sizeRepository.RecuperarPorId(id);

            return size != null ? _mapper.Map<ReadSizeDTO>(size) : null;
        }
    }
}