﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.OfferDiscountDtos;
using MultiShop.WebUI.Services.CatalogServices.OfferDiscountService;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]
    [Route("Admin/OfferDiscount")]
    public class OfferDiscountController : Controller
    {
        private readonly IOfferDiscountService _offerDiscountService;

        public OfferDiscountController(IOfferDiscountService offerDiscountService)
        {
            _offerDiscountService = offerDiscountService;
        }
        void OfferDiscountViewbag()
        {
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "İndirim Teklifleri";
            ViewBag.v3 = "İndirim Teklif Listesi";
            ViewBag.v0 = "İndirim Teklif İşlemleri";
        }
        [Route("Index")]
        public async Task<IActionResult> Index()
        {

            OfferDiscountViewbag();

            var values = await _offerDiscountService.GetAllOfferDiscountAsync();
            return View(values);
        }
        [HttpGet]
        [Route("CreateOfferDiscount")]
        public IActionResult CreateOfferDiscount()
        {
            OfferDiscountViewbag();
            return View();
        }
        [HttpPost]
        [Route("CreateOfferDiscount")]
        public async Task<IActionResult> CreateOfferDiscount(CreateOfferDiscountDto createOfferDiscountDto)
        {

            await _offerDiscountService.CreateOfferDiscountAsync(createOfferDiscountDto);


            return RedirectToAction("Index", "OfferDiscount", new { area = "Admin" });
          
        }

        [Route("DeleteOfferDiscount/{id}")]
        public async Task<IActionResult> DeleteOfferDiscount(string id)
        {
            await _offerDiscountService.DeleteOfferDiscountAsync(id);

            return RedirectToAction("Index", "OfferDiscount", new { area = "Admin" });
        }
        [Route("UpdateOfferDiscount/{id}")]
        [HttpGet]
        public async Task<IActionResult> UpdateOfferDiscount(string id)
        {
            OfferDiscountViewbag();

            var values = await _offerDiscountService.GetByIdOfferDiscountAsync(id);


            return View(values);
        }
        [Route("UpdateOfferDiscount/{id}")]
        [HttpPost]
        public async Task<IActionResult> UpdateOfferDiscount(UpdateOfferDiscountDto updateOfferDiscountDto)
        {
            await _offerDiscountService.UpdateOfferDiscountAsync(updateOfferDiscountDto);


            return RedirectToAction("Index", "OfferDiscount", new { area = "Admin" });
        }
    }
}
