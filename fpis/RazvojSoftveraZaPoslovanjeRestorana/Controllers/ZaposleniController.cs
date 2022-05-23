using Data.UnitOfWork;
using Domen.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RazvojSoftveraZaPoslovanjeRestorana.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ZaposleniController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;

        public ZaposleniController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        // GET: api/<ZaposleniController>
        [HttpGet]
        public async Task<ActionResult<List<Zaposleni>>> Get()
        {
            var zaposleni = await unitOfWork.Zaposleni.GetAll();
            return zaposleni;
        }

    }
}
