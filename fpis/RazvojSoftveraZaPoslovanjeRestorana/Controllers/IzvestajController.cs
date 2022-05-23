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
    public class IzvestajController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;

        public IzvestajController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        // GET: api/<IzvestajController>
        [HttpGet]
        public async Task<ActionResult<List<IzvestajOBrojuDorucaka>>> Get()
        {
            var izvestaj = await unitOfWork.Izvestaj.GetAll();
            return izvestaj;
        }

        // GET api/<IzvestajController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IzvestajOBrojuDorucaka>> Get(int id)
        {
            var izvestaj = await unitOfWork.Izvestaj.FindByID(id);
            return izvestaj;
        }

        // POST api/<IzvestajController>
        [HttpPost]
        public  void PostAsync([FromBody] IzvestajOBrojuDorucaka izvestaj)
        {
            unitOfWork.Izvestaj.Add(izvestaj);
            unitOfWork.Commit();
        }

        // PUT api/<IzvestajController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] IzvestajOBrojuDorucaka izvestaj)
        {
            unitOfWork.Izvestaj.Update(izvestaj);
            unitOfWork.Commit();
        }

        // DELETE api/<IzvestajController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            unitOfWork.Izvestaj.Delete(new IzvestajOBrojuDorucaka { RBIzvestaja = id });
            unitOfWork.Commit();
        }

        // GET: api/<IzvestajController>
        [HttpGet("last")]
        public async Task<ActionResult<int>> GetLast()
        {
            var izvestaj = await unitOfWork.Izvestaj.GetLast();
            return izvestaj.RBIzvestaja+1;
        }
    }
}
