using System.Collections.Generic;
using Ecommerce.ApplicationService.Interfaces;
using Ecommerce.DomainService.Interfaces;
using Ecommerce.CrossCutting.DTO.Color;
using Ecommerce.ValidationService.Services;

namespace Ecommerce.ApplicationService.Services
{
    public class ColorApplicationService : IColorApplicationService
    {
        private readonly IColorDomainService _colorDomainService;
        private readonly ColorValidationService _colorValidationService;

        public ColorApplicationService(IColorDomainService colorDomainService, ColorValidationService colorValidationService)
        {
            _colorDomainService = colorDomainService;
            _colorValidationService = colorValidationService;
        }

        public ReadColorDTO Add(CreateColorDTO createColorDto)
        {
            _colorValidationService.Validate(createColorDto);

            return _colorDomainService.Add(createColorDto);
        }

        public IList<ReadColorDTO> List()
        {
            return _colorDomainService.List();
        }

        public ReadColorDTO GetById(int id)
        {
            return _colorDomainService.GetById(id);
        }
    }
}