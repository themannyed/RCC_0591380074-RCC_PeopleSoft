using PeopleSoftGLExport.Business.Domain;
using PeopleSoftGLExport.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleSoftGLExport.Business
{
    public class PeopleSoftGLExportBusiness : IPeopleSoftGLExportBusiness
    {

        private IPeopleSoftGLExportData _data;

        public PeopleSoftGLExportBusiness(IPeopleSoftGLExportData peopleSoftGLExportData)
        {
            _data = peopleSoftGLExportData;

        }

        public List<GLExportLine> GenerateGLExportFile(string orgCode)
        {
            List<GLExportLine> GLExportItems = new List<GLExportLine>();

            //TODO: Fetch GL data here

            return GLExportItems;
        }
    }
}
