using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Test.Context;
using Test.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Test.Controllers
{
    [Route("api/[controller]")]
    public class CompraController : Controller
    {
        private readonly AppDbContext context;
        public CompraController(AppDbContext context)
        {
            this.context = context;
        }
        // GET: api/<controller>
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok(context.Compra.ToList());

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<controller>/5
        [HttpGet("{id}", Name ="GetCompra")]
        public ActionResult Get(int id)
        {
            try
            {
                var Compra = context.Compra.FirstOrDefault(f => f.CodCompra == id);
                return Ok(Compra);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<controller>
        [HttpPost]
        public ActionResult Post([FromBody]Compra Compra)
        {
            try
            {
                context.Compra.Add(Compra);
                context.SaveChanges();
                return CreatedAtRoute("GetCompra", new { id = Compra.CodCompra }, Compra);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody]Compra Compra)
        {
            try
            {
                if (Compra.CodCompra == id)
                {
                    context.Entry(Compra).State = EntityState.Modified;
                    context.SaveChanges();
                    return CreatedAtRoute("GetCompra", new { id = Compra.CodCompra }, Compra);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                var Compra = context.Compra.FirstOrDefault(f => f.CodCompra == id);
                if (Compra != null)
                {
                    context.Compra.Remove(Compra);
                    context.SaveChanges();
                    return Ok(id);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
