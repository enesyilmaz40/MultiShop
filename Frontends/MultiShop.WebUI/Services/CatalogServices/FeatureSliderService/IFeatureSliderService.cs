﻿using MultiShop.DtoLayer.CatalogDtos.FeatureSliderDto;

namespace MultiShop.WebUI.Services.CatalogServices.FeatureSliderService
{
    public interface IFeatureSliderService
    {
        Task<List<ResultFeatureSliderDto>> GetAllFeatureSliderAsync();
        Task CreateFeatureSliderAsync(CreateFeatureSliderDto FeatureSliderDto);
        Task UpdateFeatureSliderAsync(UpdateFeatureSliderDto FeatureSliderDto);
        Task DeleteFeatureSliderAsync(string id);
        Task<UpdateFeatureSliderDto> GetByIdFeatureSliderAsync(string id);
        Task FeatureSliderChangeStatusToTrue(string id);
        Task FeatureSliderChangeStatusToFalse(string id);
    }
}
