using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teatru.Services.LocServices.Dto;

namespace Teatru.Services.LocServices
{
    public interface ILocService
    {
        List<LocDto> GetAll();
    }
}
