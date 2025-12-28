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
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult PostTransacao([FromBody] CreateProductRequest createProduct)
        {
            if (registerProduct.IsRegistered(createProduct))
                return StatusCode(StatusCodes.Status201Created);
            else
                return StatusCode(StatusCodes.Status400BadRequest);
        }
    }
}
