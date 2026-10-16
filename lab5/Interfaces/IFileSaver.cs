using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab5.Interfaces
{
    interface IFileSaver
    {
        Task SaveAsync<T>(string filePath, List<T> data);
    }
}
