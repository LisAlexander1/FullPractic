using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BackPractice.Models;

public partial class User : IEntity
{
    [Key]
    [Column("id")]
    public Guid Id { get; set; }

    [Column("login")]
    [StringLength(30)]
    [Unicode(false)]
    public string Login { get; set; }

    [Column("password")]
    [StringLength(100)]
    [Unicode(false)]
    public string Password { get; set; }
}
