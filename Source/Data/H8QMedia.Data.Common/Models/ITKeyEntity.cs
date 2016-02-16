namespace H8QMedia.Data.Common.Models
{
    using System.ComponentModel.DataAnnotations;

    public interface ITKeyEntity<TKey>
    {
        [Key]
        TKey Id { get; set; }
    }
}
