using System.Collections.Generic;
using Ecommerce.CrossCutting.DTO.Color;

namespace Ecommerce.DomainService.Interfaces
{
    public interface IColorDomainService
    {
        ReadColorDTO Add(CreateColorDTO createColorDto);
        IList<ReadColorDTO> List();
        ReadColorDTO GetById(int id);
    }
}