using System.Collections.Generic;
using Ecommerce.DomainService.Interfaces;
using Ecommerce.ApplicationService.Interfaces;
using Ecommerce.CrossCutting.DTO.Size;
using Ecommerce.ValidationService.Services;

namespace Ecommerce.ApplicationService.Services
{
    public class SizeApplicationService : ISizeApplicationService
    {
        private readonly ISizeDomainService _sizeDomainService;
        private readonly SizeValidationService _sizeValidationService;

        public SizeApplicationService(ISizeDomainService tamanhoDomainService, SizeValidationService tamanhoValidationService)
        {
            _sizeDomainService = tamanhoDomainService;
            _sizeValidationService = tamanhoValidationService;
        }

        public ReadSizeDTO Add(CreateSizeDTO createSizeDto)
        {
            _sizeValidationService.Validate(createSizeDto);
            return _sizeDomainService.Add(createSizeDto);
        }

        public IList<ReadSizeDTO> List()
        {
            return _sizeDomainService.List();
        }

        public ReadSizeDTO GetById(int id)
        {
            return _sizeDomainService.GetById(id);
        }
    }
}