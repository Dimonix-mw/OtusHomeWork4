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
        public TypeAnnouncementEnum Type { get; set; }
        public override string ToString()
        {
            return $"TypeAnnouncementId = {TypeAnnouncementId}, Type = {Type};";
        }
    }
}
