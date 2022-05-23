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
    public class UslugaController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;

        public UslugaController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        // GET: api/<UslugaController>
        [HttpGet]
        public async Task<ActionResult<List<Usluga>>> Get()
        {
            var usluga = await unitOfWork.Usluga.GetAll();
            return usluga;
        }

        // GET api/<UslugaController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Usluga>> Get(int id)
        {
            var usluga = await unitOfWork.Usluga.FindByID(id);
            return usluga;
        }

        // POST api/<UslugaController>
        [HttpPost]
        public void Post([FromBody] Usluga usluga)
        {
            unitOfWork.Usluga.Add(usluga);
            unitOfWork.Commit();
        }

        // PUT api/<UslugaController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Usluga usluga)
        {
            usluga.UslugaID = id;
            unitOfWork.Usluga.Update(usluga);
            unitOfWork.Commit();
        }

        // DELETE api/<UslugaController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            unitOfWork.Usluga.Delete(new Usluga { UslugaID = id });
            unitOfWork.Commit();
        }

        [HttpGet("last")]
        public async Task<ActionResult<int>> GetLast()
        {
            var usluga = await unitOfWork.Usluga.GetLast();
            return usluga.UslugaID + 1;
        }

        [HttpGet("find/{nazivUsluge}")]
        public async Task<ActionResult<Usluga>> Find(string nazivUsluge)
        {
            var usluga = await unitOfWork.Usluga.FindByName(nazivUsluge);
            return usluga;
        }

    }
}
