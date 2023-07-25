namespace InfotechLabCase.Models
{
    public class BaseClass
    {

        #region Consts
        public const string LoginSuccess = "Giriş Başarılı.";
        public const string LoginFailed = "Kayıtlı Profil Bulunamadı Lütfen Kayıt Olarak Devam Ediniz.";
        public const string RegisterSuccess = "Profil Kayıt Edildi Lütfen Bir Sonraki Sayfada Diğer Bilgileri Doldurarak Devam Ediniz";
        public const string RegisterFailed = "Bu Email İle Kayıt Mevcut";
        public const string ProfileFound = "Profile Bilgileri Getirildi.";
        public const string UpdateProfileSuccess = "Profil Bilgileri Başarılı Bir Şekilde Güncellenmiştir.";
        public const string DeleteProfileSuccess = "Profil Bilgileri Başarılı Bir Şekilde Silinmiştir.";
        public const string BadRequest = "Geçersiz İstek veya Yanlış Format.";
        public const string CreateCustomerSuccess = "Müşteri Başarı İle Eklendi.";
        public const string DataEntryNotFoundForCustomer = "Müşteri Kayıtları Bulunamadı.";
        public const string DataEntryNotFoundForCustomerId = "İstenen CustomerId'ye Ait Müşteri Kaydı Bulunamadı.";
        public const string CreateExpertSuccess = "Usta Başarıyla Eklendi";
        public const string DataEntryNotFoundForExpert = "Usta Kayıtları Bulunamadı.";
        public const string DataEntryNotFoundForExpertId = "İstenen ExpertId'ye Ait Usta Kaydı Bulunamadı.";
        public const string DataEntryNotFoundOfferWithCustomerId = " Müşteriye Ait Teklif Formu Bulunamadı.";
        public const string DataEntryNotFoundOfferWithExpertId = " Ustaya Ait Teklif Formu Bulunamadı.";
        public const string DataEntryNotFoundServiceForServiceCategoryId = " Hizmet Alanı Bulunamadı.";
        public const string SendingOffer = " Teklif Başarılı Bir Şekilde Gönderildi Ustamız En Kısa Zamanda Geri Dönüş Sağlayacaktır";
        public const string GetOffersForCustomerId = " Müşteriye Ait Teklif FormLarı Getirildi.";
        public const string GetOffersForExpertId = " Ustaya Ait Teklif FormLarı Getirildi.";
        public const string CreateCitySuccess = "Şehir Başarıyla Eklendi.";
        public const string CreateDistrictSuccess = "Mahalle Başarıyla Eklendi.";
        public const string CreateServiceSuccess = "Hizmet Alanı Başarıyla Eklendi";
        public const string UpdateServiceSuccess = "Hizmet Alanı Başarıyla Güncellendi";
        public const string DeleteServiceSuccess = "Hizmet Alanı Başarıyla Silindi";

        #endregion

        #region Enums
        public enum UserRole
        {
            /// <summary>
            /// Usta
            /// </summary>
            Expert = 1,
            /// <summary>
            /// Müşteri
            /// </summary>
            Customer = 2,
            /// <summary>
            /// Admin
            /// </summary>
            Admin = 3

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

        #region
        public enum OfferStatus
        {
            Send = 1,
            Seen = 2,
            Completed = 3
        }

        #endregion
    }
}
