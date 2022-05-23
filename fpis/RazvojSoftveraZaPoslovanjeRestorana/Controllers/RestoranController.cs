using Data.UnitOfWork;
using Domen.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazvojSoftveraZaPoslovanjeRestorana.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestoranController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;

        public RestoranController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        // GET: api/<JedinicaMere>
        [HttpGet]
        public async Task<ActionResult<List<Restoran>>> Get()
        {
            var restoran = await unitOfWork.Restoran.GetAll();
            return restoran;
        }
    }
}
