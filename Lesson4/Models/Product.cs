using Lesson4.Enum;
using System.ComponentModel.DataAnnotations;

namespace Lesson4.Models
{
    /// <summary>
    /// Модель товара
    /// </summary>
    public class Product
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// Наименование
        /// </summary>
        [Required]
        [StringLength(maximumLength: 50)]
        public string? Name { get; set; }

        /// <summary>
        /// Стоимость
        /// </summary>
        [Required]
        public decimal Price { get; set; }

        /// <summary>
        /// Описание
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// Тип товара
        /// </summary>
        [Required]
        public TypeProduct TypeProduct { get; set; }
        

    }
}
