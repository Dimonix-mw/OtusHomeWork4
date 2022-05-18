using System.ComponentModel.DataAnnotations;

namespace Lesson4.Models
{
    /// <summary>
    /// Модель пользователя
    /// </summary>
    public class Person
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public int PersonId { get; set; }

        /// <summary>
        /// Имя
        /// </summary>
        [Required]
        [StringLength(maximumLength: 100)]
        public string FirstName { get; set; }

        /// <summary>
        /// Фамилия
        /// </summary>
        [StringLength(maximumLength: 100)]
        public string LastName { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        [Required]
        [StringLength(maximumLength: 50)]
        public string Email { get; set; }

        /// <summary>
        /// Телефон
        /// </summary>
        [Required]
        [StringLength(maximumLength: 12)]
        public string PhoneNumber { get; set; }

        public List<Announcement> Announcements { get; set; }

    }
}
