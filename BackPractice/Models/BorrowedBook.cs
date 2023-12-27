using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace BackPractice.Models;

[Index("BookCopyId", "ReaderId", "TakenAt", Name = "BorrowedBooks_index_0", IsUnique = true)]
public partial class BorrowedBook : IEntity
{
    [Key]
    [Column("id")]
    public Guid Id { get; set; }

    [Column("book_copy_id")]
    public Guid BookCopyId { get; set; }

    [Column("reader_id")]
    public Guid ReaderId { get; set; }

    [Column("taken_at", TypeName = "datetime")]
    public DateTime TakenAt { get; set; }

    [Column("returned_at", TypeName = "datetime")]
    public DateTime? ReturnedAt { get; set; }

    [Column("return_to", TypeName = "date")]
    public DateTime ReturnTo { get; set; }

    [ForeignKey("BookCopyId")]
    [InverseProperty("BorrowedBooks")]
    [JsonIgnore]
    public virtual BookCopy BookCopy { get; set; } = null!;

    [ForeignKey("ReaderId")]
    [InverseProperty("BorrowedBooks")]
    [JsonIgnore]
    public virtual Reader Reader { get; set; } = null!;
}
