namespace H8QMedia.Web.Controllers.Tests
{
    using System.Reflection;
    using H8QMedia.Common;
    using H8QMedia.Web;
    using H8QMedia.Web.Infrastructure.Mapping;
    using NUnit.Framework;

    [SetUpFixture]
    public class TestsInit
    {
        [SetUp]
        public void RunBeforeAnyTests()
        {
            var autoMapperConfig = new AutoMapperConfig();
            autoMapperConfig.Execute(Assembly.Load(Assemblies.Web));
        }
    }
}
