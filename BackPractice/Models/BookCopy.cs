using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace BackPractice.Models;

[Table("BookCopy")]
public partial class BookCopy : IEntity
{
    [Key]
    [Column("id")]
    public Guid Id { get; set; }

    [Column("book_id")]
    public Guid? BookId { get; set; }

    [Column("rack")]
    public int? Rack { get; set; }

    [Column("shelf")]
    public int? Shelf { get; set; }

    [ForeignKey("BookId")]
    [InverseProperty("BookCopies")]
    public virtual Book? Book { get; set; }

    [InverseProperty("BookCopy")]
    [JsonIgnore]
    public virtual ICollection<BorrowedBook> BorrowedBooks { get; set; } = new List<BorrowedBook>();
}
