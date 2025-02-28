﻿using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.ProductDtos;
using MultiShop.WebUI.Services.CatalogServices.ProductService;
using Newtonsoft.Json;

namespace MultiShop.WebUI.ViewComponents.DefaultViewComponents
{
    public class _FeatureProductDefaultComponentPartial:ViewComponent
    {
        private readonly IProductService _productService;

        public _FeatureProductDefaultComponentPartial(IProductService productService)
        {
            _productService = productService;
        }

      
  
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _productService.GetAllProductAsync();
            return View(values);
           
        }
    }
}
