using SourceCodeStudioTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SourceCodeStudioTest.Services
{
    public interface IDogService
    {
        Task<DogResponse> GetRandomDogAsync();
    }
}
