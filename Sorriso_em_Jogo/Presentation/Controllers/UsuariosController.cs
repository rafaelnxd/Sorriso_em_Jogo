using Microsoft.AspNetCore.Mvc;
using Sorriso_em_Jogo.Application.DTOs.UsuarioDTOs;
using Sorriso_em_Jogo.Domain.Entities.Models;
using Sorriso_em_Jogo.Application.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class UsuariosController : ControllerBase
{
    private readonly UsuarioService _usuarioService;

    public UsuariosController(UsuarioService usuarioService)
    {
        _usuarioService = usuarioService;
    }

    // GET api/usuarios
    [HttpGet]
    public async Task<ActionResult<IEnumerable<UsuarioDTO>>> Get()
    {
        var usuarios = await _usuarioService.GetAllUsuariosAsync();

       
        var usuarioDtos = usuarios.Select(u => new UsuarioDTO
        {
            Id_usuario = u.Id_usuario,
            Nome = u.Nome,
            Email = u.Email,
            Data_cadastro = u.Data_cadastro,
            Pontos_recompensa = u.Pontos_recompensa
        });

        return Ok(usuarioDtos);
    }

    // GET api/usuarios/{id}
    [HttpGet("{id}")]
    public async Task<ActionResult<UsuarioDTO>> Get(int id)
    {
        var usuario = await _usuarioService.GetUsuarioByIdAsync(id);
        if (usuario == null) return NotFound();

        var usuarioDto = new UsuarioDTO
        {
            Id_usuario = usuario.Id_usuario,
            Nome = usuario.Nome,
            Email = usuario.Email,
            Data_cadastro = usuario.Data_cadastro,
            Pontos_recompensa = usuario.Pontos_recompensa
        };

        return Ok(usuarioDto);
    }

    // POST api/usuarios
    [HttpPost]
    public async Task<ActionResult<UsuarioDTO>> Post([FromBody] UsuarioCreateDTO usuarioDto)
    {
     
        var usuario = new Usuario
        {
            Nome = usuarioDto.Nome,
            Email = usuarioDto.Email,
            Senha = usuarioDto.Senha, 
            Data_cadastro = DateTime.UtcNow
        };

        await _usuarioService.AddUsuarioAsync(usuario);


        var usuarioCriado = new UsuarioDTO
        {
            Id_usuario = usuario.Id_usuario,
            Nome = usuario.Nome,
            Email = usuario.Email,
            Data_cadastro = usuario.Data_cadastro,
            Pontos_recompensa = usuario.Pontos_recompensa
        };

        return CreatedAtAction(nameof(Get), new { id = usuario.Id_usuario }, usuarioCriado);
    }

    // PUT api/usuarios/{id}
    [HttpPut("{id}")]
    public async Task<ActionResult> Put(int id, [FromBody] UsuarioUpdateDTO usuarioDto)
    {
        var usuarioExistente = await _usuarioService.GetUsuarioByIdAsync(id);
        if (usuarioExistente == null) return NotFound();

  
        usuarioExistente.Nome = usuarioDto.Nome;
        usuarioExistente.Email = usuarioDto.Email;
        usuarioExistente.Senha = usuarioDto.Senha; 

        await _usuarioService.UpdateUsuarioAsync(usuarioExistente);
        return NoContent();
    }

    // DELETE api/usuarios/{id}
    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        await _usuarioService.DeleteUsuarioAsync(id);
        return NoContent();
    }
}
