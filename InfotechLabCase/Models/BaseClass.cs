namespace InfotechLabCase.Models
{
    public class BaseClass
    {

        #region Base Messages

        public const string ProfileFound = "Profile Bilgileri Getirildi.";
        public const string UpdateProfileSuccess = "Profil Bilgileri Başarılı Bir Şekilde Güncellenmiştir.";
        public const string DeleteProfileSuccess = "Profil Bilgileri Başarılı Bir Şekilde Silinmiştir.";
        public const string BadRequest = "Geçersiz İstek veya Yanlış Format.";

        #endregion

        #region City Messages

        public const string CreateCitySuccess = "Şehir Başarıyla Eklendi.";
        public const string GetCities = "Şehirler Getirildi.";

        #endregion

        #region Customer Messages

        public const string CreateCustomerSuccess = "Müşteri Başarı İle Eklendi.";
        public const string GetCustomers = "Müşteri Kayıtları Getirildi.";
        public const string DataEntryNotFoundForCustomer = "Müşteri Kayıtları Bulunamadı.";
        public const string DataEntryNotFoundForCustomerId = "İstenen CustomerId'ye Ait Müşteri Kaydı Bulunamadı.";
        public const string DataEntryNotFoundOfferWithCustomerId = " Müşteriye Ait Teklif Formu Bulunamadı.";

        #endregion

        #region District Messages

        public const string CreateDistrictSuccess = "Mahalle Başarıyla Eklendi.";
        public const string GetDistricts = "İlçeler Getirildi.";
        public const string GetDistrictsFailed = "İlçeler Bulunamadı.";

        #endregion

        #region Expert Comment Messages

        public const string CreateCommentForExpert = "Usta Yorumu Başarılı Bir Şekilde Gönderildi.";
        public const string GetExpertComment = "Ustaya Ait Yorumlar Getirildi.";

        #endregion

        #region Expert Message

        public const string CreateExpertSuccess = "Usta Başarıyla Eklendi.";
        public const string DataEntryNotFoundForExpert = "Usta Kayıtları Bulunamadı.";
        public const string DataEntryNotFoundForExpertId = "İstenen ExpertId'ye Ait Usta Kaydı Bulunamadı.";
        public const string DataEntryNotFoundOfferWithExpertId = " Ustaya Ait Teklif Formu Bulunamadı.";
        public const string GetExperts = "Kayıtlı Ustalar Getirildi.";
        public const string SearchExpert = "Usta Filtrelemeleri Başarılı.";

        #endregion

        #region Login Message

        public const string LoginSuccess = "Giriş Başarılı.";
        public const string LoginFailed = "Kayıtlı Profil Bulunamadı Lütfen Kayıt Olarak Devam Ediniz.";
        public const string RegisterSuccess = "Giriş Başarılı Lütfen Bir Sonraki Sayfada Diğer Bilgileri Doldurarak Devam Ediniz.";
        public const string RegisterFailed = "Bu Email İle Kayıt Mevcut.";

        #endregion

        #region Neighbourhood Messages

        public const string GetNeighbourdhoods = "Kayıtlı Mahalleler Getirildi.";
        public const string CreateNeighbourhood = "Mahalle başarıyla Eklendi.";

        #endregion

        #region Offer Messages

        public const string SendingOffer = " Teklif Başarılı Bir Şekilde Gönderildi Ustamız En Kısa Zamanda Geri Dönüş Sağlayacaktır.";
        public const string GetOffersForCustomerId = " Müşteriye Ait Teklif Formları Getirildi.";
        public const string GetOffersForExpertId = " Ustaya Ait Teklif Formları Getirildi.";
        public const string UpdateOfferStatus = "Hizmet Durumu Başarıyla Güncellendi.";
        public const string UpdateOfferStatusFailedByOfferId = "İstenilen OfferId'ye Ait Teklif Formu Kaydı Bulunumadı.";
        public const string UpdateOfferSuccess = "İş Teklifi Başarıyla Güncellendi";
        public const string DeleteOfferSuccess = "İş Teklifi Başarıyla Silindi.";
        public const string ExpertCompletedWork = "Ustamız Tarafından Tamamlanan İş Sayısı.";

        #endregion

        #region Service Category Messages

        public const string DataEntryNotFoundServiceForServiceCategoryId = " Hizmet Alanı Bulunamadı.";
        public const string CreateServiceSuccess = "Hizmet Alanı Başarıyla Eklendi.";
        public const string UpdateServiceSuccess = "Hizmet Alanı Başarıyla Güncellendi.";
        public const string DeleteServiceSuccess = "Hizmet Alanı Başarıyla Silindi.";
        public const string GetServicesSuccess = "Hizmet Alanları Başarıyla Getirildi.";

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
        public enum OfferStatus
        {
            /// <summary>
            /// Gönderildi...
            /// </summary>
            Send = 1,
            /// <summary>
            /// Görüldü...
            /// </summary>
            Seen = 2,
            /// <summary>
            /// Tamamlandı...
            /// </summary>
            Completed = 3
        }
        #endregion
    }
}
