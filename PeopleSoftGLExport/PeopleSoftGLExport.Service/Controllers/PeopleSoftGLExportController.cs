using CsvHelper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PeopleSoftGLExport.Business;
using PeopleSoftGLExport.Business.Domain;
using PeopleSoftGLExport.Data;

namespace PeopleSoftGLExport.Service.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PeopleSoftGLExportController : ControllerBase
    {
        private IPeopleSoftGLExportBusiness PeopleSoftGLExportBusiness;
        private readonly IConfiguration Configuration;
        private ILogger<PeopleSoftGLExportData> _logger;
        private readonly string _connectionString;
        public PeopleSoftGLExportController(ILogger<PeopleSoftGLExportData> logger, IPeopleSoftGLExportBusiness paymentManagerServiceBusiness, IConfiguration configuration)
        {
            PeopleSoftGLExportBusiness = paymentManagerServiceBusiness;
            _logger = logger;
            Configuration = configuration;
        }

        [Authorize]
        [HttpGet]
        [Route("GenerateGLExportData")]
        public IActionResult GenerateGLExportData(string orgCode)
        {
            try
            {
                var glExportFileName = Configuration["GLExportFileName"];
                string fileName = $"{glExportFileName}_{DateTime.Now.ToString("MddyyyyHHmmss")}.csv";
                List<GLExportLine> glExportData = PeopleSoftGLExportBusiness.GenerateGLExportFile(orgCode);
                if (glExportData == null || glExportData.Count == 0)
                {
                    return Ok("No Records to Process");
                }
                else
                {
                    using (MemoryStream stream = new MemoryStream())
                    {
                        using (StreamWriter writer = new StreamWriter(stream))
                        {
                            using (CsvWriter csv = new CsvWriter(writer, System.Globalization.CultureInfo.InvariantCulture))
                            {
                                csv.Context.RegisterClassMap<LineMap>();
                                csv.WriteRecords(glExportData);

                                csv.NextRecord();
                                writer.Flush();
                                return File(stream.ToArray(), "text/csv", fileName);
                            }
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex, ex.Message);
                return BadRequest(ex.Message);
            }


        }

    }
}
