using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.ServiceModel;
using Mernis.Kps.Sample.Net.WCF.KPSKimlik;
using Microsoft.IdentityModel.Protocols.WSTrust;
using TcIdentityChecker.Common;
using TcIdentityChecker.Interfaces;
using TcIdentityChecker.Models;

namespace TcIdentityChecker
{
    public static class TcIdentity
    {
        public static IReturnData<PersonData> KisiBilgileriniGetir(long tcKimlikNumarasi)
        {
            try
            {
                var isSuccess = false;
                var message = "";
                PersonData personData = null;

                var algoritmaSonucu = TcKimlikAlgoritmaDogrulama(tcKimlikNumarasi);
                var userNameCheck = UserNamePasswordCheck();

                if (!userNameCheck)
                {
                    message = "KPS Kullanıcı Adı veya Parolası Yazılmamış";
                }
                else if (algoritmaSonucu != "OK")
                {
                    message = algoritmaSonucu;
                }
                else
                {
                    var channelFactory = new ChannelFactory<KisiSorgulaTCKimlikNoServis>("BindingKisiSorgulaTCKimlikNoServis", new EndpointAddress(KpsConfiguration.Instance.EndPoint));
                    if (channelFactory.Credentials != null) channelFactory.Credentials.SupportInteractive = false;

                    channelFactory.ConfigureChannelFactory();
                    var servis = channelFactory.CreateChannelWithIssuedToken(KpsServiceFactory.Instance.CreateToken());

                    var list = new List<KisiSorgulaTCKimlikNoSorguKriteri>
                    {
                        new KisiSorgulaTCKimlikNoSorguKriteri {TCKimlikNo = tcKimlikNumarasi}
                    };

                    var sonuc = servis.ListeleCoklu(list);

                    if (sonuc.HataBilgisi == null)
                    {
                        foreach (var data in from kisi in sonuc.SorguSonucu where kisi.HataBilgisi == null select sonuc.SorguSonucu.ToList())
                        {
                            //Kişi bilgileri dolduruluyor
                            personData = new PersonData
                            {
                                Ad = data[0].TemelBilgisi.Ad,
                                Soyad = data[0].TemelBilgisi.Soyad,
                                DogumYeri = data[0].TemelBilgisi.DogumYer,
                                Cinsiyet = data[0].TemelBilgisi.Cinsiyet.Aciklama,
                                MedeniDurumu = data[0].DurumBilgisi.MedeniHal.Aciklama,
                                NufusIl = data[0].KayitYeriBilgisi.Il.Aciklama,
                                NufusIlce = data[0].KayitYeriBilgisi.Ilce.Aciklama,
                                MahalleKoy = data[0].KayitYeriBilgisi.Cilt.Aciklama,
                                AileSiraNo = data[0].KayitYeriBilgisi.AileSiraNo,
                                BireySiraNo = data[0].KayitYeriBilgisi.BireySiraNo,
                                Cilt = data[0].KayitYeriBilgisi.Cilt.Kod,
                                AnneAdi = data[0].TemelBilgisi.AnneAd,
                                BabaAdi = data[0].TemelBilgisi.BabaAd,
                            };

                            //Doğum tarihi varsa
                            if (data[0].TemelBilgisi.DogumTarih.Yil != null && data[0].TemelBilgisi.DogumTarih.Ay != null && data[0].TemelBilgisi.DogumTarih.Gun != null)
                            {
                                personData.DogumTarihi =
                                    new DateTime(data[0].TemelBilgisi.DogumTarih.Yil.Value,
                                        data[0].TemelBilgisi.DogumTarih.Ay.Value,
                                        data[0].TemelBilgisi.DogumTarih.Gun.Value);
                            }

                            //Ölüm tarihi varsa
                            if (data[0].DurumBilgisi.OlumTarih.Yil != null && data[0].DurumBilgisi.OlumTarih.Ay != null && data[0].DurumBilgisi.OlumTarih.Gun != null)
                            {
                                personData.OlumTarihi =
                                    new DateTime(
                                        data[0].DurumBilgisi.OlumTarih.Yil.Value,
                                        data[0].DurumBilgisi.OlumTarih.Ay.Value,
                                        data[0].DurumBilgisi.OlumTarih.Gun.Value);
                            }
                            isSuccess = true;
                        }
                    }
                    else
                    {
                        message = sonuc.HataBilgisi.Aciklama;
                    }
                }
                return new ReturnData<PersonData>
                {
                    IsSuccess = isSuccess,
                    Message = message,
                    Data = personData
                };
            }
            catch (Exception ex)
            {
                return new ReturnData<PersonData>
                {
                    IsSuccess = false,
                    Message = "Sistem hatası oluştu. Lütfen daha sonra tekrar deneyiniz. / " + ex.Message,
                    Data = null
                };
            }
        }

        internal static bool UserNamePasswordCheck()
        {
            var userName = ConfigurationManager.AppSettings["KpsUserName"];
            var password = ConfigurationManager.AppSettings["KpsPassword"];
            return !string.IsNullOrEmpty(userName) || !string.IsNullOrEmpty(password);
        }

        internal static string TcKimlikAlgoritmaDogrulama(long tcKimlikNumarasi)
        {
            if (11 != tcKimlikNumarasi.ToString().Length)
                return "T.C. Kimlik Numarası 11 Karakter Olmalıdır";

            Int64 ATCNO, BTCNO, TcNo;
            long C1, C2, C3, C4, C5, C6, C7, C8, C9, Q1, Q2;

            TcNo = tcKimlikNumarasi;
            ATCNO = TcNo / 100;
            BTCNO = TcNo / 100;
            C1 = ATCNO % 10; ATCNO = ATCNO / 10;
            C2 = ATCNO % 10; ATCNO = ATCNO / 10;
            C3 = ATCNO % 10; ATCNO = ATCNO / 10;
            C4 = ATCNO % 10; ATCNO = ATCNO / 10;
            C5 = ATCNO % 10; ATCNO = ATCNO / 10;
            C6 = ATCNO % 10; ATCNO = ATCNO / 10;
            C7 = ATCNO % 10; ATCNO = ATCNO / 10;
            C8 = ATCNO % 10; ATCNO = ATCNO / 10;
            C9 = ATCNO % 10; ATCNO = ATCNO / 10;
            Q1 = ((10 - ((((C1 + C3 + C5 + C7 + C9) * 3) + (C2 + C4 + C6 + C8)) % 10)) % 10);
            Q2 = ((10 - (((((C2 + C4 + C6 + C8) + Q1) * 3) + (C1 + C3 + C5 + C7 + C9)) % 10)) % 10);


            var returnvalue = ((BTCNO * 100) + (Q1 * 10) + Q2 == TcNo);


            return returnvalue ? "OK" : "T.C. Kimlik Numarası Hatalı";
        }
    }
}