using Crud.Dto;
using Crud.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace Crud.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IUsuario _user;
        public UsuarioController(IUsuario user)
        {
            _user = user;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var users = _user.Get();

                return Ok(users);
            }
            catch (Exception ex)
            {
                SimpleLog.Error(ex.Message);
                return BadRequest("Erro, tente novamente mais tarde");
            }
        }

        [HttpPost]
        public IActionResult Save([FromBody] UsuarioDto newUser)
        {
            try
            {
                newUser.IsValid();
                _user.Save(newUser);

                return Created("/Usuario", newUser.Cpf);
            }
            catch (Exception ex)
            {
                SimpleLog.Error(ex.Message);

                if (ex is ArgumentException)
                    return BadRequest(ex.Message);
                else
                    return BadRequest("Erro, tente novamente mais tarde");
            }
        }

        [HttpPut]
        public IActionResult Update([FromBody] UsuarioDto user)
        {
            try
            {
                user.IsValid();

                if (!_user.Get(user.Cpf).Any())
                    throw new ArgumentException("Tentativa de editar usuário inexistente");

                _user.Update(user);
                return Ok();
            }
            catch (Exception ex)
            {
                SimpleLog.Error(ex.Message);

                if (ex is ArgumentException)
                    return BadRequest(ex.Message);
                else
                    return BadRequest("Erro, tente novamente mais tarde");
            }
        }

        [HttpDelete]
        public IActionResult Delete([FromQuery] string cpf)
        {
            try
            {
                if (string.IsNullOrEmpty(cpf))
                    throw new ArgumentException("Cpf inválido");

                if (!_user.Get(cpf).Any())
                    throw new ArgumentException("Tentativa de deletar usuário inexistente");

                _user.Delete(cpf);
                return Ok();
            }
            catch (Exception ex)
            {
                SimpleLog.Error(ex.Message);

                if (ex is ArgumentException)
                    return BadRequest(ex.Message);
                else
                    return BadRequest("Erro, tente novamente mais tarde");
            }
        }
    }
}