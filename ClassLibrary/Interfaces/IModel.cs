using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Interfaces
{
    public interface IModel
    {
        string ModelName { get; set; }
        string Description { get; set; }
        double HullLength { get; set; }
        double HullWidth { get; set; }
        double HullDepth { get; set; }
        double BaseWeight { get; set; }
    }
}
