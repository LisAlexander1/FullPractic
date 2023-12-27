using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace BackPractice.Models;

[Table("Publisher")]
public partial class Publisher : IEntity
{
    [Key]
    [Column("id")]
    public Guid Id { get; set; }

    [Column("name")]
    [StringLength(40)]
    [Unicode(false)]
    public string? Name { get; set; }

    [Column("address")]
    [StringLength(100)]
    [Unicode(false)]
    public string? Address { get; set; }

    [InverseProperty("Publisher")]
    [JsonIgnore]
    public virtual ICollection<Book> Books { get; set; } = new List<Book>();
}
