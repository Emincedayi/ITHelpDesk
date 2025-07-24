using Xunit;

namespace ITHelpDesk.EntityFrameworkCore;

[CollectionDefinition(ITHelpDeskTestConsts.CollectionDefinitionName)]
public class ITHelpDeskEntityFrameworkCoreCollection : ICollectionFixture<ITHelpDeskEntityFrameworkCoreFixture>
{

}
