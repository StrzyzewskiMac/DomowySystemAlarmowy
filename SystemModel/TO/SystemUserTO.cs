namespace SystemModel.TO
{
    /// <summary>
    /// Transport Object przetrzymujący niezbędne informacje o użytkowniku.
    /// </summary>
    public class SystemUserTO
    {
        /// <summary>
        /// Unikalne id użytkownika.
        /// </summary>
        public int? UserId { get; set; }

        /// <summary>
        /// Nazwa użytkownika. Wyświetlana dla ludzi - w systemie używa się id użytkownika.
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Hasło użytkownika poddane hashowaniu.
        /// </summary>
        public string UserPassword { get; set; }

        /// <summary>
        /// Poziom uprawnień użytkownika.
        /// </summary>
        public int? PrivilegeId { get; set; }

        /// <summary>
        /// Telefon kontaktowy.
        /// </summary>
        public string PhoneNumber { get; set; }
    }
}
