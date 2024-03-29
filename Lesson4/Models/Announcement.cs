﻿namespace Lesson4.Models
{
    /// <summary>
    /// Модель объявления
    /// </summary>
    public class Announcement
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public int AnnouncementId { get; set; }

        /// <summary>
        /// Заголовок
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Тип объявления
        /// </summary>
        public TypeAnnouncement TypeAnnouncement { get; set; }

        public int TypeAnnouncementId {get; set;}

        public int PersonId { get; set; }
        /// <summary>
        /// Пользователь
        /// </summary>
        public Person Person { get; set; }
        public int ProductId { get; set; }

        /// <summary>
        /// Товар
        /// </summary>
        public Product Product { get; set; }
        public override string ToString()
        {
            return $"AnnouncementId = {AnnouncementId}, Title = {Title} , TypeAnnouncementId = {TypeAnnouncementId}, PersonId = {PersonId}, ProductId = {ProductId};";
        }

    }
}
