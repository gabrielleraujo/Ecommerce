using Job.DomainService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Job.ApplicationService
{
    public class SumaryApplicationService
    {
        private readonly ISumamyDomainService _resumoCompraDomainService;

        public SumaryApplicationService(IResumoCompraDomainService resumoCompraDomainService)
        {
            _resumoCompraDomainService = resumoCompraDomainService;
        }

        public void Adicionar(ReadCompraDto readCompraDto)
        {
            _resumoCompraDomainService.Adicionar(readCompraDto);
        }
        public ReadResumoCompraDto RecuperarPorDate(DateTime data)
        {
            return _resumoCompraDomainService.RecuperarPorDate(data);
        }
    }
}
