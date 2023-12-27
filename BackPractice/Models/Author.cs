using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace BackPractice.Models;

public partial class Author : IEntity
{
    [Key]
    [Column("id")]
    public Guid Id { get; set; }

    [Column("first_name")]
    [StringLength(20)]
    public string FirstName { get; set; } = null!;

    [Column("last_name")]
    [StringLength(20)]
    public string LastName { get; set; } = null!;

    [Column("surname")]
    [StringLength(20)]
    public string? Surname { get; set; }

    [InverseProperty("Author")]
    [JsonIgnore]
    public virtual ICollection<Book> Books { get; set; } = new List<Book>();
}
