﻿using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AirplaneTicketService.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        UnityOfWork uow;
        public ClientController(UnityOfWork uow)
        {
            this.uow = uow;
        }

        //[Route("Clients")]
        // GET: /Client
        [HttpGet]
        public async Task<IActionResult> Clients()
        {
            try
            {
                var clients = await uow.Clients.RetrieveAll().ConfigureAwait(false);
                if(clients == null)
                {
                    return NotFound();
                }
                return Ok(clients);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        [Route("Passport")]
        //[HttpGet("{id}", Name = "Get")]
        [HttpGet]
        public async Task<IActionResult> GetClientsByPassport(string passport)
        {
            try
            {
                var clients = await uow.Clients.GetClientsByPassport(passport).ConfigureAwait(false);
                if (clients == null)
                {
                    return NotFound();
                }
                return Ok(clients);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        // GET: /Client/5
        [HttpGet("{id}", Name = "Client")]
        public async Task<IActionResult> GetClient(int id)
        {
            try
            {
                var nClient = await uow.Clients.Retrieve(id).ConfigureAwait(false);
                if(nClient == null)
                {
                    return NotFound();
                }
                return Ok(nClient);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // POST: api/Client
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Models.Client nClient)
        {
            if (ModelState.IsValid)
            {
                var newClient = await uow.Clients.Create(nClient).ConfigureAwait(false);
                return Ok(newClient);
            }
            return BadRequest();

        }

        // PUT: api/Client/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Models.Client nClient)
        {
            if (ModelState.IsValid)
            {
                if (id == nClient.ClientId)
                {
                    await uow.Clients.Update(nClient).ConfigureAwait(false);
                    return Ok();
                }
            }
            return BadRequest();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            int result = 0;
            if(id == 0)
            {
                return BadRequest();
            }
            try
            {
                result = await uow.Clients.Delete(id).ConfigureAwait(false);
                if(result == 0)
                {
                    return NotFound();
                }
                return Ok();    
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }
    }
}
