using Microsoft.AspNetCore.Mvc;
using AuctionApi.Core.Interfaces;
using AuctionApi.Data.Entities;
using AuctionApi.Data.DTOs;

namespace AuctionApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BidsController : ControllerBase
{
    private readonly IBidService _service;

    public BidsController(IBidService service)
    {
        _service = service;
    }

    [HttpGet("{auctionId}")]
    public async Task<IActionResult> Get(int auctionId)
    {
        return Ok(await _service.GetByAuctionIdAsync(auctionId));
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateBidDto dto)
    {
        var bid = new Bid
        {
            Amount = dto.Amount,
            AuctionId = dto.AuctionId,
            UserId = dto.UserId
        };

        var result = await _service.CreateAsync(bid);

        if (!result.Success)
            return BadRequest(result.Error);

        return Ok(result.CreatedBid);
    }
}