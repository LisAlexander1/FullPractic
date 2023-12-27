using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace BackPractice.Models;

[Table("Book")]
public partial class Book : IEntity
{
    [Key]
    [Column("id")]
    public Guid Id { get; set; }

    [Column("name")]
    [StringLength(20)]
    [Unicode(false)]
    public string? Name { get; set; }

    [Column("number_of_pages")]
    public int? NumberOfPages { get; set; }

    [Column("publisher_id")]
    public Guid? PublisherId { get; set; }

    [Column("author_id")]
    public Guid? AuthorId { get; set; }

    [Column("published_at", TypeName = "date")]
    public DateTime? PublishedAt { get; set; }

    [Column("cover")]
    public byte[]? Cover { get; set; }

    // [NotMapped]
    // public string? CoverString => Cover is not null ? "data:image;base64," + Convert.ToBase64String(Cover) : null;

    [ForeignKey("AuthorId")]
    [InverseProperty("Books")]
    public virtual Author? Author { get; set; }

    [InverseProperty("Book")]
    [JsonIgnore]
    public virtual ICollection<BookCopy> BookCopies { get; set; } = new List<BookCopy>();

    [ForeignKey("PublisherId")]
    [InverseProperty("Books")]
    public virtual Publisher? Publisher { get; set; }
}
