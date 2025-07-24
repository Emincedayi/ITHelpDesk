using System.Threading.Tasks;

namespace ITHelpDesk.Data;

public interface IITHelpDeskDbSchemaMigrator
{
    Task MigrateAsync();
}
