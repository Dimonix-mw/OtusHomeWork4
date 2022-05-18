using Lesson4.Enum;

namespace Lesson4.Models
{
    /// <summary>
    /// Модель тип товара
    /// </summary>
    public class TypeProduct
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public int TypeProductId { get; set; }

        /// <summary>
        /// Тип товара
        /// </summary>
        public EnumTypeProduct Type { get; set; }

    }
}
