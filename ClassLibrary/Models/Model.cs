using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary.Interfaces;

namespace ClassLibrary.Models
{
    public class Model : IModel
    {
        #region Properties
        public string ModelName { get; set; }
        public string Description { get; set; }
        public double HullLength { get; set; }
        public double HullWidth { get; set; }
        public double HullDepth { get; set; }
        public double BaseWeight { get; set; }
        #endregion

        public Model(string modelName, string description, double hullLength, double hullWidth, double hullDepth, double baseWeight)
        {
            ModelName = modelName;
            Description = description;
            HullLength = hullLength;
            HullWidth = hullWidth;
            HullDepth = hullDepth;
            BaseWeight = baseWeight;
        }

        public override string ToString()
        {
            return $"{ModelName}\nDescription: {Description}\nHull Length: {HullLength}\nHull Width: {HullWidth}\nHull Depth: {HullDepth}\nBase Weight: {BaseWeight}";
        }
    }
}
