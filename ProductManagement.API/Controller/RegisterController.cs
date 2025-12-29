using Microsoft.AspNetCore.Mvc;
using ProductManagement.Domain.Contracts.UseCase;
using ProductManagement.Domain.Dto;
using ProductManagement.Domain.Model;

namespace ProductManagement.API.Controller
{
    [ApiController]
    [Route("/api/v1/register")]
    [Produces("application/json")]
    public class RegisterController : ControllerBase
    {
        public IRegisterProduct registerProduct;

        public RegisterController(IRegisterProduct registerProduct) 
        {
            this.registerProduct = registerProduct;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> register([FromBody] CreateProductRequest createProduct)
        {
            try
            {
                var productId = await registerProduct.ExecuteAsync(createProduct);
                return Created($"/api/v1/product/{productId}", new { id = productId });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Ocorreu um erro interno." });
            }
        }
    }
}
