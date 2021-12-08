using System.Collections.Generic;
using Ecommerce.CrossCutting.DTO.Color;

namespace Ecommerce.ApplicationService.Interfaces
{
    public interface IColorApplicationService
    {
        ReadColorDTO Add(CreateColorDTO createCorDto);
        IList<ReadColorDTO> List();
        ReadColorDTO GetById(int id);
    }
}