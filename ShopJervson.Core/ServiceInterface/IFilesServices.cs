﻿using ShopJervson.Core.Domain;
using ShopJervson.Core.Dto;

namespace ShopJervson.ApplicationServices.Services
{
    public interface IFilesServices
    {
        void UploadFilesToDatabase(SpaceshipDto dto, Spaceship domain);
    }
}