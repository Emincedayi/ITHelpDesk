using ITHelpDesk.Samples;
using Xunit;

namespace ITHelpDesk.EntityFrameworkCore.Applications;

[Collection(ITHelpDeskTestConsts.CollectionDefinitionName)]
public class EfCoreSampleAppServiceTests : SampleAppServiceTests<ITHelpDeskEntityFrameworkCoreTestModule>
{

}
