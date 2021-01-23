using Microsoft.AspNetCore.Mvc;
using Plants.Infrastructure.Data;
using Plants.Infrastructure.Models;
using System.Collections.Generic;
using System.Linq;

namespace Plants.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ScoreController : ControllerBase
    {
        public DataContext _context { get; set; }

        public ScoreController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Score> Get()
        {
            return _context.GetAllScores().OrderByDescending(q => q.TimeStamp);
        }
    }
}