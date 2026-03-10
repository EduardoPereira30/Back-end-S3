using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace EventPlus.WebApi.Models;

[Table("Usuario")]
[Index("Email", Name = "UQ__Usuario__A9D105343584CCA0", IsUnique = true)]
public partial class Usuario
{
    [Key]
    public Guid IdUsuario { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string Nome { get; set; } = null!;

    [StringLength(256)]
    [Unicode(false)]
    public string Email { get; set; } = null!;

    [StringLength(60)]
    [Unicode(false)]
    public string Senha { get; set; } = null!;

    public Guid? IdTipoUsuario { get; set; }

    [InverseProperty("IdUsuarioNavigation")]
    [JsonIgnore]
    public virtual ICollection<Comentario> Comentarios { get; set; } = new List<Comentario>();

    [ForeignKey("IdTipoUsuario")]
    [InverseProperty("Usuarios")]
    [JsonIgnore]
    public virtual TipoUsuario? IdTipoUsuarioNavigation { get; set; }

    [InverseProperty("IdUsuarioNavigation")]
    [JsonIgnore]
    public virtual ICollection<Presenca> Presencas { get; set; } = new List<Presenca>();
}
