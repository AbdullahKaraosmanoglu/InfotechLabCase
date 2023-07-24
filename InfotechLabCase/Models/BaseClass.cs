namespace InfotechLabCase.Models
{
    public class BaseClass
    {

        #region Consts
        public const string LoginSuccess = "Giriş Başarılı.";
        public const string LoginFailed= "Kayıtlı Profil Bulunamadı Kayıt Olarak Devam Ediniz.";
        public const string ProfileFound = "Profile Bilgileri Getirildi.";
        public const string UpdateProfileSuccess = "Profil Bilgileri Başarılı Bir Şekilde Güncellenmiştir.";
        public const string DeleteProfileSuccess = "Profil Bilgileri Başarılı Bir Şekilde Silinmiştir.";
        public const string BadRequest = "Geçersiz İstek veya Yanlış Format.";
        public const string DataEntryNotFoundForCustomer = "Müşteri Kayıtları Bulunamadı.";
        public const string DataEntryNotFoundForCustomerId = "İstenen CustomerId'ye Ait Müşteri Kaydı Bulunamadı.";
        public const string DataEntryNotFoundForExpert = "Usta Kayıtları Bulunamadı.";
        public const string DataEntryNotFoundForExpertId = "İstenen ExpertId'ye Ait Usta Kaydı Bulunamadı.";
        public const string SendingOffer = " Teklif Başarılı Bir Şekilde Gönderildi Ustamız En Kısa Zamanda Geri Dönüş Sağlayacaktır";
        public const string DataEntryNotFoundOfferWithCustomerId = " Müşteriye Ait Teklif Formu Bulunamadı.";
        public const string GetOffersForCustomerId = " Müşteriye Ait Teklif FormLarı Getirildi.";
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
