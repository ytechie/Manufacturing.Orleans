using System.Threading.Tasks;
using Manufacturing.Framework.Dto;
using Orleans;

namespace GrainInterfaces
{
    public interface IDatasourceGrain : IGrain
    {
        Task NewRecord(DatasourceRecord record);
    }
}
