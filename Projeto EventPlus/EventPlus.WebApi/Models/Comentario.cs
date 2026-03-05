using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EventPlus.WebApi.Models;

[Table("Comentario")]
public partial class Comentario
{
    [Key]
    public Guid IdComentario { get; set; }

    [StringLength(200)]
    [Unicode(false)]
    public string Descricao { get; set; } = null!;

    public bool Exibe { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime DataComentarioEvento { get; set; }

    public Guid? IdUsuario { get; set; }

    public Guid? IdEvento { get; set; }

    [ForeignKey("IdEvento")]
    [InverseProperty("Comentarios")]
    public virtual Evento? IdEventoNavigation { get; set; }

    [ForeignKey("IdUsuario")]
    [InverseProperty("Comentarios")]
    public virtual Usuario? IdUsuarioNavigation { get; set; }
}
