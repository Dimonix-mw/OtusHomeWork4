﻿namespace Lesson4.Models
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
        public TypeProductEnum Type { get; set; }
        public override string ToString()
        {
            return $"TypeProductId = {TypeProductId}, Type = {Type};";
        }
    }
}
