using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BackPractice.Models;

[Index("Pass", Name = "UQ__Readers__8320F63E51E674C8", IsUnique = true)]
public partial class Reader : IEntity
{
    [Key]
    [Column("id")]
    public Guid Id { get; set; }

    [Column("first_name")]
    [StringLength(20)]
    [Unicode(false)]
    public string FirstName { get; set; } = null!;

    [Column("last_name")]
    [StringLength(20)]
    [Unicode(false)]
    public string LastName { get; set; } = null!;

    [Column("surname")]
    [StringLength(20)]
    [Unicode(false)]
    public string? Surname { get; set; }

    [Column("birthday", TypeName = "date")]
    public DateTime? Birthday { get; set; }

    [Column("pass")]
    [StringLength(10)]
    [Unicode(false)]
    public string? Pass { get; set; }

    [Column("photo")]
    public byte[]? Photo { get; set; }
    
    // [NotMapped]
    // public string? PhotoString => Photo is not null ? "data:image;base64," + Convert.ToBase64String(Photo) : null;

    [InverseProperty("Reader")]
    public virtual ICollection<BorrowedBook> BorrowedBooks { get; set; } = new List<BorrowedBook>();
}
