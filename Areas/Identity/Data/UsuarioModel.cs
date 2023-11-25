using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace ProjetoMVC.Areas.Identity.Data;

// Add profile data for application users by adding properties to the UsuarioModel class
public class UsuarioModel : IdentityUser
{
    [MaxLength(50, ErrorMessage = "O Tamanho máximo do campo  {0} é de {1} caracteres")]
    [Required]

    public string Nome { get; set; }

    [MaxLength(15, ErrorMessage = "O Tamanho máximo do campo  {0} é de {1} caracteres")]

    public string Telefone { get; set; }

}

