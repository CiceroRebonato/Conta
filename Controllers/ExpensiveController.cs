using DespesasControlApp.DTOs;
using DespesasControlApp.Models;
using DespesasControlApp.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DespesasControlApp.Controllers
{
    public class DespesasController : Controller
    {
        private readonly ILogger<DespesasController> _logger;
        private readonly IDespesasService _DespesasService;

        public DespesasController(ILogger<DespesasController> logger,
            IDespesasService DespesasService)
        {
            _logger = logger;
            _DespesasService = DespesasService;
        }

        public async Task<IActionResult> Index()
        {
            var listDespesasDto = new ListDespesasDTO();

            listDespesasDto.Items = await _DespesasService.FindBy(listDespesasDto.StartDate, listDespesasDto.EndDate);

            return View(listDespesasDto);
        }

         public async Task<IActionResult> Republica()
        {
            var listDespesasDto = new ListDespesasDTO();

            listDespesasDto.Items = await _DespesasService.FindBy(listDespesasDto.StartDate, listDespesasDto.EndDate);

            return View(listDespesasDto);
        }

        [HttpPost]
        public async Task<IActionResult> Index(ListDespesasDTO listDespesasDto)
        {
            try
            {
                listDespesasDto.Items = await _DespesasService.FindBy(listDespesasDto.StartDate, listDespesasDto.EndDate);

                return View(listDespesasDto);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("CustomError", ex.Message);
                return View(listDespesasDto);
            }
        }

        public async Task<IActionResult> Create()
        {
            var createDespesasDto = new CreateDespesasDTO();

            return View(createDespesasDto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateDespesasDTO createDespesasDto)
        {
            try
            {
                await _DespesasService.Create(createDespesasDto);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("CustomError", ex.Message);
                return View(createDespesasDto);
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}