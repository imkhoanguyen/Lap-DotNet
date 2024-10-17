using Application.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Lap.Controllers
{
    public class BookController : Controller
    {
        private readonly IUnitOfWork _unit;
        public BookController(IUnitOfWork unit)
        {
            _unit = unit;
        }

        
    }
}
