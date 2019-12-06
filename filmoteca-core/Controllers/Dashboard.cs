using System;
using System.Collections.Generic;

namespace filmoteca_core.Controllers
{
    public class Dashboard
    {
        public List<string> Labels { get; set; }
        public List<DataSet> DataSets { get; set; }

    }

    public class DataSet
    {
        public string Label { get; set; }
        public List<int> Data { get; set; }
        public string BackgroundColor { get; set; }
        public string BorderColor { get; set; }
    }
}