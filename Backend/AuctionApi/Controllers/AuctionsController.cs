using Microsoft.AspNetCore.Mvc;
using AuctionApi.Core.Interfaces;
using AuctionApi.Data.Entities;
using AuctionApi.Data.DTOs;

namespace AuctionApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuctionsController : ControllerBase
{
    private readonly IAuctionService _service;

    public AuctionsController(IAuctionService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _service.GetActiveAsync());
    }

    [HttpGet("search")]
    public async Task<IActionResult> Search(string title)
    {
        return Ok(await _service.SearchActiveAsync(title));
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateAuctionDto dto)
    {
        var auction = new Auction
        {
            Title = dto.Title,
            Description = dto.Description,
            Price = dto.Price,
            EndDate = dto.EndDate,
            UserId = dto.UserId
        };

        return Ok(await _service.CreateAsync(auction));
    }
}