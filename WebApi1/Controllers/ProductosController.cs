using Database.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebApi1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        private readonly NorthwindContext _context;

        // GET /api/productos
        [HttpGet()]
        public ActionResult Get()
        {
            var productos = _context.Products.ToList();
            return Ok(productos);
        }

        // GET /api/productos/11
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            if(id<1) return BadRequest(new 
            {
                Message = "Las referencias tienen que ser números positivos.",
                Data = id.ToString()
            });

            var producto = _context.Products
                .Where(r=>r.ProductID == id)
                .FirstOrDefault();

            if (producto == null) return NotFound(new { Message = "El producto no existe." });

            else
                return Ok(producto);
        }

        // POST /api/productos
        [HttpPost()]
        public ActionResult Post(Product producto)
        {
            if (_context.Products == null)
                return Problem("La entidad productos no existe (es null)");

            try
            {
                _context.Products.Add(producto);
                _context.SaveChanges();

                // Opción 1, retorna Creado 201, los datos recientemente insertados y la URL para consultar el producto en la cabecera LOCATION
                return Created($"https://localhost:7013/api/Productos/{producto.ProductID}", producto);

                // Opción 2, intteresante cuando el registro puede cambiar facilmente por tener campos autocalculados o verse afectados por triggers
                // return CreatedAtAction("Get", new {id = producto.ProductID}, producto);
            }
            catch (DbUpdateException e)
            {
                if(ProductoExiste(producto.ProductID))
                    return Conflict(new { Message = $"El producto {producto.ProductID} ya existe." });
                else 
                    return Conflict(new { Message = e.Message });
            }
            catch (Exception e)
            {
                return Conflict(new { Message = e.Message });
            }
        }
        // PUT /api/productos/11
        [HttpPut("{id}")]
        public ActionResult Put(int id, Product producto)
        {
            if (id != producto.ProductID) 
                return BadRequest(new { Message = "Los identificadores no son válidos" });
            try
            {
                _context.Update(producto);
                _context.SaveChanges();

                return NoContent(); 
            }
            catch (DbUpdateConcurrencyException e)
            {
                if (!ProductoExiste(producto.ProductID))
                    return Conflict(new { Message = $"El producto {producto.ProductID} no existe." });
                else
                    return Conflict(new { Message = e.Message });
            } 
            catch (Exception e) 
            {
                return Conflict(new { Message = e.Message });
            }
            return Ok();
        }
        // DELETE /api/productos/11
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            // Opción 1, con FIND
            var producto = _context.Products.Find(id);

            if (producto == null) return NotFound(new { Message = "El producto no existe." });

            // Opción 2, ccon WHERE
            //var producto2 = _context.Products
            //    .Where(r => r.ProductID == id)
            //    .FirstOrDefault();

            //if (producto2 == null) return NotFound(new { Message = "El producto no existe."});

            try
            {
                _context.Products.Remove(producto);
                _context.SaveChanges();

                return Ok();
            }
            catch (Exception e)
            {
                return Conflict(new { Message = e.Message });
            }

        }
        private bool ProductoExiste(int id)
        {
            return _context.Products.Any(p => p.ProductID == id);
        }

        public ProductosController(NorthwindContext context)
        {
            _context = context;
        }
    }
}
