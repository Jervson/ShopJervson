using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopJervson.Core.Domain;
using ShopJervson.Core.Dto;
using ShopJervson.Data;

namespace ShopJervson.ApplicationServices.Services
{
    public class FilesServices : IFilesServices
    {
        private readonly ShopJervsonContext _context;
        public FilesServices
            (
                ShopJervsonContext context
            )
        {
            _context = context;
        }
        public void UploadFilesToDatabase(SpaceshipDto dto, Spaceship domain)
        {
            if (dto.Files != null && dto.Files.Count > 0)
            {
                foreach (var photo in dto.Files)
                {
                    using (var target = new MemoryStream())
                    {
                        FileToDatabase files = new FileToDatabase()
                        {
                            Id = Guid.NewGuid(),
                            ImageTitle = photo.FileName,
                            SpaceshipId = domain.Id,
                        };

                        photo.CopyTo( target );
                        files.ImageData = target.ToArray();

                        _context.FileToDatabases.Add(files);
                    }
                }
            }
        }
    }
}
