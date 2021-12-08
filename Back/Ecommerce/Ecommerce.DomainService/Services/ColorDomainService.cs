using AutoMapper;
using Ecommerce.Data.Entities;
using Ecommerce.DomainService.Interfaces;
using Ecommerce.Repository.Interfaces;
using Ecommerce.CrossCutting.DTO.Color;
using System.Collections.Generic;

namespace Ecommerce.DomainService.Services
{
    public class ColorDomainService : IColorDomainService
    {
        private readonly IColorRepository _colorRepository;
        private readonly IMapper _mapper;

        public ColorDomainService(IColorRepository colorRepository, IMapper mapper)
        {
            _colorRepository = colorRepository;
            _mapper = mapper;
        }

        public ReadColorDTO Add(CreateColorDTO createColorDto)
        {
            var color = _mapper.Map<Color>(createColorDto);
            _colorRepository.Add(color);

            return _mapper.Map<ReadColorDTO>(color);
        }

        public IList<ReadColorDTO> List()
        {
            var colors = _colorRepository.List();

            return colors != null ? _mapper.Map<IList<ReadColorDTO>>(colors) : null;
        }

        public ReadColorDTO GetById(int id)
        {
            var color = _colorRepository.GetById(id);

            return color != null ? _mapper.Map<ReadColorDTO>(color) : null;
        }
    }
}