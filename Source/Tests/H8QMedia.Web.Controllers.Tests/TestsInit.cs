namespace H8QMedia.Web.Controllers.Tests
{
    using System.Reflection;
    using H8QMedia.Common;
    using H8QMedia.Web;
    using H8QMedia.Web.Infrastructure.Mapping;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class TestsInit
    {
        [AssemblyInitialize]
        public static void AssemblyInit(TestContext context)
        {
            var autoMapperConfig = new AutoMapperConfig();
            autoMapperConfig.Execute(Assembly.GetExecutingAssembly());
        }
    }
}
