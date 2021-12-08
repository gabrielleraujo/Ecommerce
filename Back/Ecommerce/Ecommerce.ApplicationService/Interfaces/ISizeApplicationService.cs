using System.Collections.Generic;
using Ecommerce.CrossCutting.DTO.Size;

namespace Ecommerce.ApplicationService.Interfaces
{
    public interface ISizeApplicationService
    {
        ReadSizeDTO Add(CreateSizeDTO createSizeDto);
        IList<ReadSizeDTO> List();
        ReadSizeDTO GetById(int id);
    }
}