using Microsoft.AspNetCore.Mvc;
using PracticalDemoWebAPI.Models;
using PracticalDemoWebAPI.Repository.Interface;

namespace PracticalDemoWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarInvontoryController : ControllerBase
    {
        private readonly ICarInventoryRepository _carInventoryRepository;
        public CarInvontoryController(ICarInventoryRepository carInventoryRepository)
        {
            _carInventoryRepository = carInventoryRepository;
        }

        #region Get List Of CarInventories
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<CarInventoryModel>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(void))]
        public async Task<IActionResult> Get()
        {
            var result = await _carInventoryRepository.GetCarList();
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound();
        }
        #endregion

        #region Car Inventory By Id
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CarInventoryModel))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(void))]
        public async Task<IActionResult> Get(Guid id)
        {
            var result = await _carInventoryRepository.GetCarInventoryById(id);
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound();
        }
        #endregion


        #region Add New Car Inventory
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResponseMessageModel))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ResponseMessageModel))]
        public async Task<IActionResult> Post([FromForm] CarInventoryModel model)
        {
            if (string.IsNullOrWhiteSpace(model.Name))
            {
                return BadRequest(ModelState);
            }
            else if (string.IsNullOrWhiteSpace(model.CompanyName))
            {
                return BadRequest(ModelState);
            }
            var data = await _carInventoryRepository.AddNew(model);
            if (data == true)
            {
                return Ok(new ResponseMessageModel
                {
                    Message = "Record added successfully"
                });

            }
            return Ok(new ResponseMessageModel
            {
                Message = "Something went wrong."
            });
        }

        #endregion

        #region Upadte Inventory
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResponseMessageModel))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ResponseMessageModel))]
        public async Task<IActionResult> Put(Guid id, [FromBody] CarInventoryModel model)
        {
            if (id == Guid.Empty || id == Guid.Parse("00000000-0000-0000-0000-000000000000"))
            {
                return BadRequest(new ResponseMessageModel
                {
                    Message = "Please enter valid id."
                });
            }
            var result = await _carInventoryRepository.UpdateInventoryById(id, model);
            if (result == 0)
            {
                return NotFound(new ResponseMessageModel
                {
                    Message = "No Data Found with this id."
                });
            }
            else if (result == 1)
            {
                return NotFound(new ResponseMessageModel
                {
                    Message = "Something went wrong."
                });
            }
            return Ok(new ResponseMessageModel
            {
                Message = "Data Updated Sucessfully"
            });

        }
        #endregion

        #region Delete
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResponseMessageModel))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ResponseMessageModel))]
        public async Task<IActionResult> Delete(Guid id)
        {
            if (id == Guid.Empty || id == Guid.Parse("00000000-0000-0000-0000-000000000000"))
            {
                return BadRequest(new ResponseMessageModel
                {
                    Message = "Please enter valid id."
                });
            }
            var result = await _carInventoryRepository.DeleteById(id);
            if (result == 0)
            {
                return NotFound(new ResponseMessageModel
                {
                    Message = "No Data Found with this id."
                });
            }
            else if (result == 1)
            {
                return NotFound(new ResponseMessageModel
                {
                    Message = "Something went wrong."
                });
            }
            return Ok(new ResponseMessageModel
            {
                Message = "Data deleted Sucessfully"
            });

        }
        #endregion
    }
}

