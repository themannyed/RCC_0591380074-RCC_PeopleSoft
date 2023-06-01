using PeopleSoftGLExport.Business.Domain;

namespace PeopleSoftGLExport.Business
{
    public interface IPeopleSoftGLExportBusiness
    {
        List<GLExportLine> GenerateGLExportFile(string orgCode);
    }
}