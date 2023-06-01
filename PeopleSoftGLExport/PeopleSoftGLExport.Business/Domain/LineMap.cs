using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleSoftGLExport.Business.Domain
{
    public class LineMap : ClassMap<GLExportLine>
    {
        public LineMap()
        {
            Map(m => m.Organization).Index(1).Name("ORG");
        }
    }
}
