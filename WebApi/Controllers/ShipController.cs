using AutoMapper;
using Contracts;
using Entities.DTO;
using Entities.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/ship")]
    [ApiController]
    public class ShipController : ControllerBase
    {
        private ILoggerManager _logger;
        private IMapper _mapper;
        private IRepositoryWrapper _repository;

        public ShipController(ILoggerManager logger, IMapper mapper, IRepositoryWrapper repository)
        {
            _logger = logger;
            _mapper = mapper;
            _repository = repository;
        }

        [HttpGet]
        public IActionResult GetAllShips()
        {
            try
            {
                var ship = _repository.Ship.GetAllShips();
                var shipResult = _mapper.Map<IEnumerable<ShipDto>>(ship);
                return Ok(new { data = shipResult });
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error occurred in GetAllShips action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}", Name = "ShipById")]
        public IActionResult GetShipById(int id)
        {
            try
            {
                var ship = _repository.Ship.GetShipById(id);
                if (ship is null)
                {
                    _logger.LogError($"Ship with id: {id}, wasn't found in db");
                    return NotFound();
                }
                else
                {
                    var shipResult = _mapper.Map<ShipDto>(ship);
                    return Ok(shipResult);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error occurred in GetShipById action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}/cargo")]
        public IActionResult GetShipWithDetails(int id)
        {
            try
            {
                var ship = _repository.Ship.GetShipWithDetails(id);
                if (ship == null)
                {
                    _logger.LogError($"Ship with id: {id}, was not found");
                    return NotFound();
                }
                else
                {
                    var shipResult = _mapper.Map<ShipDto>(ship);
                    return Ok(new { data = shipResult });
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error occurred in GetShipWithDetails action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public IActionResult CreateShip([FromBody] ShipCreateDto ship)
        {
            try
            {
                if (ship == null)
                {
                    _logger.LogError("Ship object sent from client is null.");
                    return BadRequest("Ship object is null");
                }

                if (!ModelState.IsValid)
                {
                    _logger.LogError("Ship object sent from client is invalid");
                    return BadRequest("Invalid model object");
                }

                var shipEntity = _mapper.Map<Ship>(ship);
                _repository.Ship.CreateShip(shipEntity);
                _repository.Save();

                var shipCreated = _mapper.Map<ShipDto>(shipEntity);
                return CreatedAtRoute("ShipById", new { id = shipCreated.Id }, shipCreated);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error occurred in CreateShip action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateShip(int id, [FromBody] ShipUpdateDto ship)
        {
            try
            {
                if (ship is null)
                {
                    _logger.LogError("Ship object sent from client is null.");
                    return BadRequest("Ship object is null");
                }

                if (!ModelState.IsValid)
                {
                    _logger.LogError("Ship object sent from client is invalid");
                    return BadRequest("Invalid model object");
                }

                var shipEntity = _repository.Ship.GetShipById(id);
                if (shipEntity is null)
                {
                    _logger.LogError($"Ship with id: {id}, wasn't found in db.");
                    return NotFound();
                }

                _mapper.Map(ship, shipEntity);

                _repository.Ship.UpdateShip(shipEntity);
                _repository.Save();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error occurred in UpdateShip action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteShip(int id)
        {
            try
            {
                var ship = _repository.Ship.GetShipById(id);
                if (ship == null)
                {
                    _logger.LogError($"Ship with id: {id}, wasn't found in db.");
                    return NotFound();
                }

                if (_repository.Cargo.CargoByShip(id).Any())
                {
                    _logger.LogError($"Cannot delete ship with id: {id} due to attached cargos.");
                    return BadRequest("Cannot delete ship due to attached cargo.");
                }

                _repository.Ship.DeleteShip(ship);
                _repository.Save();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error occurred in DeleteShip action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
