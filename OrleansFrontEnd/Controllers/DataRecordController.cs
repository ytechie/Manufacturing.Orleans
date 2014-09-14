using System;
using System.Linq;
using System.Web.Http;
using GrainInterfaces;
using Manufacturing.Framework.Datasource;
using Manufacturing.Framework.Dto;

namespace OrleansFrontEnd.Controllers
{
    public class DataRecordController : ApiController
    {
        public void Post(DatasourceRecord record)
        {
            var datasource = DatasourceGrainFactory.GetGrain(record.DatasourceId);
            datasource.NewRecord(record);
        }

        public DatasourceRecord Get()
        {
            var record = RandomDatasourceRecordGenerator.GenerateDummyData(1).Single();
            return record;
        }
    }
}
