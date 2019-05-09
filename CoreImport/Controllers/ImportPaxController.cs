using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using OfficeOpenXml;
using OfficeOpenXml.Packaging;
using System.Text;
using CoreImport.Models.DBF;

namespace CoreImport.Controllers
{
    [Produces("application/json")]
    [Route("api/Pax")]
    
    public class ImportPaxController : Controller
    {
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly CharterFlightsContext _db;

        public ImportPaxController(IHostingEnvironment hostingEnvironment, CharterFlightsContext db)
        {
            _hostingEnvironment = hostingEnvironment;
            _db = db;
        }

        [HttpGet]

        [Route("ImportPax")]
        public IList<PaxData> ImportPax()



        {
            string rootFolder = _hostingEnvironment.WebRootPath;
          //string rootFolder = @"C:\Users\Din\source\repos\CoreImport\CoreImport\Excelfile\";
            string fileName = @"PaxDataTest.xlsx";
            FileInfo file = new FileInfo(Path.Combine(rootFolder, fileName));

            using (ExcelPackage package = new ExcelPackage(file))
            {
                ExcelWorksheet workSheet = package.Workbook.Worksheets["Sheet1"];
                int totalRows = workSheet.Dimension.Rows;

                List<PaxData> LPaxDataList = new List<PaxData>();

                for (int i = 2; i <= totalRows; i++)
                {
                    //var exResNumber = workSheet.Cells[i, 1].Value.ToString();
                    //var exPaxOrder = workSheet.Cells[i, 2].Value.ToString();
                    //var exName = workSheet.Cells[i, 3].Value.ToString();
                    //var exGender=workSheet.Cells[i, 4].Value.ToString();
                    LPaxDataList.Add(new PaxData

                    {

                        ResNumber = workSheet.Cells[i, 1].Value.ToString(),
                        PaxOrder = workSheet.Cells[i, 2].Value.ToString(),
                        Name = workSheet.Cells[i, 3].Value.ToString(),
                        Gender = workSheet.Cells[i, 4].Value.ToString(), //Title
                      //Gender = Validator.isTitleValid(exTitle) ? exTitle : null,
                        Dob = DateTime.Parse(workSheet.Cells[i, 5].Value.ToString()),
                        Document = workSheet.Cells[i, 6].Value.ToString(),
                        ServiceYj = workSheet.Cells[i, 7].Value.ToString(),
                        Country = workSheet.Cells[i, 8].Value.ToString(),
                        Expires = DateTime.Parse(workSheet.Cells[i, 9].Value.ToString()),
                        Seats = workSheet.Cells[i, 10].Value == null
                            ? string.Empty
                            : workSheet.Cells[i, 10].Value.ToString(),
                        Escort = workSheet.Cells[i, 11].Value == null
                            ? string.Empty
                            : workSheet.Cells[i, 11].Value.ToString(),
                    });
                }

                _db.PaxData.AddRange(LPaxDataList);
                _db.SaveChanges();

                return LPaxDataList;
            }
        }

    }
}