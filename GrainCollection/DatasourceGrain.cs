using System;
using System.Threading.Tasks;
using GrainInterfaces;
using Manufacturing.Framework.Dto;
using Orleans;

namespace GrainCollection
{
    public class DatasourceGrain : GrainBase, IDatasourceGrain
    {
        public Task NewRecord(DatasourceRecord record)
        {
            //This would be a good place to run or dispatch to reactive extensions

            Console.WriteLine("Orleans has received a record for datasource {0}", record.DatasourceId);

            return TaskDone.Done;
        }
    }
}
