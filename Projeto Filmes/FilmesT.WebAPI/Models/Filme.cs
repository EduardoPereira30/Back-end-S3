using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FilmesT.WebAPI.Models;

[Table("Filme")]
public partial class Filme
{
    [Key]
    [Column("IDFilme")]
    [StringLength(40)]
    [Unicode(false)]
    public string Idfilme { get; set; } = null!;

    [StringLength(100)]
    [Unicode(false)]
    public string Imagem { get; set; } = null!;

    [StringLength(100)]
    [Unicode(false)]
    public string Titulo { get; set; } = null!;

    [Column("IDGenero")]
    [StringLength(40)]
    public string? Idgenero { get; set; }

    [ForeignKey("Idgenero")]
    [InverseProperty("Filmes")]
    public virtual Genero? IdgeneroNavigation { get; set; }
}
