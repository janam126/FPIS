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
    public class JedinicaMereController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;

        public JedinicaMereController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        // GET: api/<JedinicaMere>
        [HttpGet]
        public async Task<ActionResult<List<JedinicaMere>>> Get()
        {
            var jedinicaMere = await unitOfWork.JedinicaMere.GetAll();
            return jedinicaMere;
        }

    }
}
