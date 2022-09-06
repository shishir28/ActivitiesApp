using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ActivitiesController : BaseAPIController
{
    private readonly DataContext _context;

    public ActivitiesController(DataContext context)
    {
        this._context = context;
    }

    [HttpGet]
    public async Task<ActionResult<List<Activity>>> GetActivities() =>
        await this._context.Activities.ToListAsync();

    [HttpGet("{id}")]
    public async Task<ActionResult<Activity>> GetActivity(Guid id) =>
        await _context.Activities.FindAsync(id);



}
