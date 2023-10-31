using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SourceCodeStudioTest.Services
{
    public interface ILocationService
    {
        Task<Location> GetLocationAsync(bool getCurrent = false);
    }
}
