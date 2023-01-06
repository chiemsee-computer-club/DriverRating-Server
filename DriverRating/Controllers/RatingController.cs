using DriverRating.Data;
using DriverRating.Data.Entities;
using DriverRating.Dtos;
using DriverRating.Extensions;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace DriverRating.Controllers;

[ApiController]
[Route("[controller]")]
public class RatingController : ControllerBase
{
    private readonly ILogger<RatingController> _logger;
    private readonly IAppDbRepository _dbRepository;

    public RatingController(ILogger<RatingController> logger, IAppDbRepository dbRepository)
    {
        _logger = logger;
        _dbRepository = dbRepository;
    }

    [HttpGet("{driverId}", Name = "GetAllRatings")]
    [SwaggerOperation(OperationId = "getAllRatings")]
    public async Task<ActionResult<RatingDto>> GetAllRatingsAsync([FromRoute] string driverId)
    {
        try
        {
            var ratings = await _dbRepository.GetRatingsAsync(driverId);
            var ret = ratings?.Select(x => x.ToDto());
            return Ok(ret);
        }
        catch (Exception e)
        {
            _logger.LogError(e, string.Empty);
            return BadRequest();
        }
    }

    [HttpPost("{driverId}", Name = "AddRating")]
    [SwaggerOperation(OperationId = "addRating")]
    public async Task<IActionResult> PostRatingAsync([FromRoute] string driverId, [FromBody] RatingDto ratingDto)
    {
        try
        {
            await _dbRepository.AddRatingAsync(driverId, ratingDto);
        }
        catch (Exception e)
        {
            _logger.LogError(e, string.Empty);
            return BadRequest();
        }

        return Ok();
    }
}