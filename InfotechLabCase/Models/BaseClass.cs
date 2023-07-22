namespace InfotechLabCase.Models
{
    public class BaseClass
    {
        #region Consts
        public const string UserNotFound= "Kayıtlı Profil Bulunamadı Kayıt Olarak Devam Ediniz.";
        public const string LoginSuccessfuly = "Giriş Başarılı.";
        #endregion

        #region Enums
        public enum UserRole
        {
            /// <summary>
            /// Usta
            /// </summary>
            Expert=1,
            /// <summary>
            /// Müşteri
            /// </summary>
            Customer=2
        }

        public enum IsActive
        {
            /// <summary>
            /// Pasif
            /// </summary>
            Passive = 0,
            /// <summary>
            /// Aktif
            /// </summary>
            Active = 1
        }

        #endregion


    }
}
