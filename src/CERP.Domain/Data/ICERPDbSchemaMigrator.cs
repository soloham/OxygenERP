using System.Threading.Tasks;

namespace CERP.Data
{
    public interface ICERPDbSchemaMigrator
    {
        Task MigrateAsync();
    }
}
