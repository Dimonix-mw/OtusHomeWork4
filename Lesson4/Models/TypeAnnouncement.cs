using Lesson4.Enum;

namespace Lesson4.Models
{
    /// <summary>
    /// Модель тип объявления
    /// </summary>
    public class TypeAnnouncement
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public int TypeAnnouncementId { get; set; }
       
        /// <summary>
        /// Тип объявления
        /// </summary>
        public EnumTypeAnnouncement Type { get; set; }
    }
}
