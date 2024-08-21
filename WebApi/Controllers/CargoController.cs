using AutoMapper;
using Contracts;
using Entities.DTO;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/cargo")]
    [ApiController]
    public class CargoController : ControllerBase
    {
        private ILoggerManager _logger;
        private IMapper _mapper;
        private IRepositoryWrapper _repository;

        public CargoController(ILoggerManager logger, IMapper mapper, IRepositoryWrapper repository)
        {
            _logger = logger;
            _mapper = mapper;
            _repository = repository;
        }

        [HttpGet("{id}", Name = "CargoById")]
        public IActionResult GetCargoById(int id)
        {
            try
            {
                var cargo = _repository.Cargo.GetCargoById(id);
                if (cargo is null)
                {
                    _logger.LogError($"Cargo with id: {id}, wasn't found in db");
                    return NotFound();
                }
                else
                {
                    var cargoResult = _mapper.Map<CargoDto>(cargo);
                    return Ok(cargoResult);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error occurred in GetCargoById action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public IActionResult CreateCargo([FromBody] CargoCreateDto cargo)
        {
            try
            {
                if (cargo == null)
                {
                    _logger.LogError("Cargo object sent from client is null.");
                    return BadRequest("Cargo object is null");
                }

                if (!ModelState.IsValid)
                {
                    _logger.LogError("Cargo object sent from client is invalid");
                    return BadRequest("Invalid model object");
                }

                var cargoEntity = _mapper.Map<Cargo>(cargo);
                _repository.Cargo.CreateCargo(cargoEntity);
                _repository.Save();

                var cargoCreated = _mapper.Map<CargoDto>(cargoEntity);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error occurred in CreateCargo action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCargo(int id, [FromBody] CargoUpdateDto cargo)
        {
            try
            {
                if (cargo is null)
                {
                    _logger.LogError("Cargo object sent from client is null.");
                    return BadRequest("Cargo object is null");
                }

                if (!ModelState.IsValid)
                {
                    _logger.LogError("Ship object sent from client is invalid");
                    return BadRequest("Invalid model object");
                }

                var cargoEntity = _repository.Cargo.GetCargoById(id);
                if (cargoEntity is null)
                {
                    _logger.LogError($"Cargo with id: {id}, wasn't found in db.");
                    return NotFound();
                }

                _mapper.Map(cargo, cargoEntity);

                _repository.Cargo.UpdateCargo(cargoEntity);
                _repository.Save();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error occurred in UpdateCargo action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCargo(int id)
        {
            try
            {
                var cargo = _repository.Cargo.GetCargoById(id);
                if (cargo == null)
                {
                    _logger.LogError($"Cargo with id: {id}, wasn't found in db.");
                    return NotFound();
                }

                _repository.Cargo.DeleteCargo(cargo);
                _repository.Save();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error occurred in DeleteCargo action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
