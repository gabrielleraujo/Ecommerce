using System.Collections.Generic;
using Ecommerce.CrossCutting.DTO.Size;

namespace Ecommerce.DomainService.Interfaces
{
    public interface ISizeDomainService
    {
        ReadSizeDTO Add(CreateSizeDTO createSizeDto);
        IList<ReadSizeDTO> List();
        ReadSizeDTO GetById(int id);
    }
}