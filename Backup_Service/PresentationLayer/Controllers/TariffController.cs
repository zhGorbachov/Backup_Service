using AutoMapper;
using BusinessLayer.Interfaces;
using BusinessLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using PresentationLayer.DTO;

namespace PresentationLayer.Controllers;

public class TariffController : Controller
{
    private readonly IMapper _mapper;
    private readonly ITariffService _tariffService;

    public TariffController(ITariffService tariffService, IMapper mapper)
    {
        _tariffService = tariffService;
        _mapper = mapper;
    }

    [HttpPost("AddTariff")]
    public async Task<IActionResult> AddTariffModelAsync(TariffDTO tariffDto)
    {
        var tariffModel = _mapper.Map<TariffModel>(tariffDto);
        var tariff = await _tariffService.AddTariffAsync(tariffModel);
        return Ok(tariff);
    }

    [HttpPut("UpdateTariff")]
    public async Task<IActionResult> UpdateTariffModelAsync(TariffDTO tariffDto, int id)
    {
        var tariffModel = _mapper.Map<TariffModel>(tariffDto);
        var tariff = await _tariffService.UpdateTariffAsync(tariffModel, id);
        return Ok(tariff);
    }
    
    [HttpDelete("DeleteTariff")]
    public async Task<IActionResult> DeleteTariffModelAsync(int id)
    {
        await _tariffService.DeleteTariffAsync(id);
        return Ok();
    }
    
    [HttpGet("GetAllTariffs")]
    public IActionResult GetAllTariffsModel()
    {
        var tariffModels = _tariffService.GetAllTariffs();
        var tariffsDto = _mapper.ProjectTo<TariffDTO>(tariffModels);
        return Ok(tariffsDto);
    }
    
    [HttpGet("GetTariffById")]
    public async Task<IActionResult> GetTariffByIdAsync(int id)
    {
        var tariffModel = await _tariffService.GetTariffModelByIdAsync(id);
        var tariffDto = _mapper.Map<TariffDTO>(tariffModel);
        return Ok(tariffDto);
    }
}