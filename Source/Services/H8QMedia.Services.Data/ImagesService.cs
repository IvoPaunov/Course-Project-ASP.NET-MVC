namespace H8QMedia.Services.Data
{
    using H8QMedia.Data.Common.Repositories;
    using H8QMedia.Data.Models;
    using H8QMedia.Services.Data.Contracts;

    public class ImagesService : IImagesService
    {
        private readonly IDbRepository<Image, int> images;

        public ImagesService(IDbRepository<Image, int> images)
        {
            this.images = images;
        }

        public void Delete(int id)
        {
          var entityToDelete = this.images.GetById(id);

            this.images.Delete(entityToDelete);

            this.images.Save();
        }
    }
}
