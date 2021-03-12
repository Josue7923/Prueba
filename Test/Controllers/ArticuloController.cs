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
    public class ArticuloController : Controller
    {
        private readonly AppDbContext context;

        public ArticuloController (AppDbContext context)
        {
            this.context = context;
        }
        // GET: api/<controller>
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok(context.Articulo.ToList());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<controller>/5
        [HttpGet("{id}", Name ="GetArticulo")]
        public ActionResult Get(int id)
        {
            try
            {
                var Articulo = context.Articulo.FirstOrDefault(f => f.CodArticulo == id);
                return Ok(Articulo);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<controller>
        [HttpPost]
        public ActionResult Post([FromBody]Articulo Articulo)
        {
            try
            {
                context.Articulo.Add(Articulo);
                context.SaveChanges();
                return CreatedAtRoute("GetArticulo", new { id = Articulo.CodArticulo }, Articulo);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody]Articulo Articulo)
        {
            try
            {
                if (Articulo.CodArticulo == id)
                {
                    context.Entry(Articulo).State = EntityState.Modified;
                    context.SaveChanges();
                    return CreatedAtRoute("GetArticulo", new { id = Articulo.CodArticulo }, Articulo);
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
                var Articulo = context.Articulo.FirstOrDefault(f => f.CodArticulo == id);
                if (Articulo != null)
                {
                    context.Articulo.Remove(Articulo);
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
