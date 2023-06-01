using PeopleSoftGLExport.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleSoftGLExport.Data
{
    public interface IPeopleSoftGLExportData
    {
        List<GeneralLedgerRecord>  GetGLExportData(string orgCode);
    }
}
