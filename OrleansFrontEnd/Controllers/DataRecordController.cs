using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using GrainInterfaces;
using Manufacturing.Framework.Datasource;
using Manufacturing.Framework.Dto;

namespace OrleansFrontEnd.Controllers
{
    public class DataRecordController : ApiController
    {
        public void Post([FromBody] IEnumerable<DatasourceRecord> records)
        {
            foreach (var record in records)
            {
                var datasource = DatasourceGrainFactory.GetGrain(record.DatasourceId);
                datasource.NewRecord(record);
            }
        }

        public DatasourceRecord Get()
        {
            var record = RandomDatasourceRecordGenerator.GenerateDummyData(1).Single();
            return record;
        }
    }
}
