namespace H8QMedia.Web.Controllers.Tests
{
    using H8QMedia.Services.Data.Contracts;
    using NUnit.Framework;
    using TestStack.FluentMVCTesting;

    [TestFixture]
    public class ArtControllerTests
    {
        private ArtController _controller;
        private IArticlesService articles;

        [SetUp]
        public void Setup()
        {
            this.articles = ObjectFactory.GetArticleService();
            this._controller = new ArtController(this.articles);

        }

        [Test]
        public void Render_default_view_for_get_to_index()
        {
            this._controller.WithCallTo(c => c.Index(1))
                .ShouldRenderDefaultView();
        }
    }
}
