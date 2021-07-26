using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using nks_backend_auth_demo.Models;
using Serilog;
using System;

namespace nks_backend_auth_demo.Controllers
{
    [Route("api/staffs/{id}/cv")]
    [ApiController]
    public class CvController : ControllerBase
    {
        /// <summary>
        /// Получение списка резюме пользователя по его ID
        /// </summary>
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Error), StatusCodes.Status400BadRequest)]
        [HttpGet]
        public ActionResult<bool> GetCvsByParameters(long id)
        {
            try
            {
                return Ok(true);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Ошибка при получении резюме");
                return BadRequest(new Error { Message = ex.Message });
            }
        }
    }
}