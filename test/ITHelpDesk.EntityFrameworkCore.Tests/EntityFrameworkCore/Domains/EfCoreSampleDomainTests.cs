using ITHelpDesk.Samples;
using Xunit;

namespace ITHelpDesk.EntityFrameworkCore.Domains;

[Collection(ITHelpDeskTestConsts.CollectionDefinitionName)]
public class EfCoreSampleDomainTests : SampleDomainTests<ITHelpDeskEntityFrameworkCoreTestModule>
{

}
