using System;
using System.Collections.Generic;
using System.Web;
using System.Collections;

// Benim eklediklerim...
using System.Linq;
using System.Web.UI;
using System.Text;
using Microsoft.SqlServer;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Xml;
using System.Drawing;
using System.Drawing.Imaging;
using System.Web.UI.WebControls;
using System.IO;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.Security;

namespace WdHelper
{
    /// Timuçin Özmaya Tarafından Web  işlemlerine yardımcı olması amacıyla geliştirilmiştir.
    /// ihtiyaç duyuldukça gelişimi devam etmektedir.
    /// .... 

    // JavaScript ve Web işlemleri

    // Uyarı Mesajı görüntüle..
    public class _MeBox
    {
        private static Hashtable m_executingPages = new Hashtable();
        private _MeBox() { }
        public static void Show(string sMessage)
        {

            if (!m_executingPages.Contains(HttpContext.Current.Handler))
            {

                Page executingPage = HttpContext.Current.Handler as Page;
                if (executingPage != null)
                {

                    Queue messageQueue = new Queue();

                    messageQueue.Enqueue(sMessage);

                    m_executingPages.Add(HttpContext.Current.Handler, messageQueue);

                    executingPage.Unload += new EventHandler(ExecutingPage_Unload);
                }
            }
            else
            {

                Queue queue = (Queue)m_executingPages[HttpContext.Current.Handler];

                queue.Enqueue(sMessage);
            }
        }


        private static void ExecutingPage_Unload(object sender, EventArgs e)
        {

            Queue queue = (Queue)m_executingPages[HttpContext.Current.Handler];
            if (queue != null)
            {
                StringBuilder sb = new StringBuilder();

                int iMsgCount = queue.Count;

                sb.Append("<script language='javascript'>");

                string sMsg;
                while (iMsgCount-- > 0)
                {
                    sMsg = (string)queue.Dequeue();
                    sMsg = sMsg.Replace("\n", "\\n");
                    sMsg = sMsg.Replace("\"", "'");
                    sb.Append(@"alert( """ + sMsg + @""" );");
                }

                sb.Append(@"</script>");

                m_executingPages.Remove(HttpContext.Current.Handler);

                HttpContext.Current.Response.Write(sb.ToString());
            }
        }
    }

    // Veri İşlem Sınıfım, Data Processing dp

    public sealed class _WebEx
    {

        /// <summary>
        /// Id si verilen kontrolu bulur.
        /// </summary>
        /// <param name="root"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public static Control FindControlRecursive(Control root, string id)
        {
            if (root.ID == id)
            {
                return root;
            }

            foreach (Control c in root.Controls)
            {
                Control t = FindControlRecursive(c, id);
                if (t != null)
                {
                    return t;
                }
            }

            return null;
        }


        public static string XKarakterdenSonrasiUcNokta(string metin, int kacinciKarakter)
        {

            string cikti = string.Empty;

            if (!string.IsNullOrEmpty(metin))
            {
                if (metin.Length>kacinciKarakter)
                {
                    cikti = metin.Remove(kacinciKarakter) + "...";
                }
                else
                {
                    cikti = metin;
                }
            }

            return cikti;

        }

        /// <summary>
        /// Belirli bir turdeki tüm controlleri getirir.
        /// Örnek Kullanım -> List<CheckBoxList> ret = GetControlsOfType<CheckBoxList>(this.Page.Controls);
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="controls"></param>
        /// <returns></returns>
        public static List<T> GetControlsOfType<T>(ControlCollection controls)
        {
            List<T> ret = new List<T>();
            try
            {
                foreach (Control control in controls)
                {
                    if (control is T)
                        ret.Add((T)((object)control));
                    else if (control.Controls.Count > 0)
                        ret.AddRange(GetControlsOfType<T>(control.Controls));
                }
            }
            catch (Exception ex)
            {
                //Log the exception
            }
            return ret;
        }



        public static int CreateRandomNumber(int BaslangicDegeri, int BitisDegeri)
        {
            Random rnd = new Random();

            return rnd.Next(BaslangicDegeri, BitisDegeri);

        }


        // Boşluk ve Türkçe karakterleri kaldır.
        public static string ReplaceFileNameForWeb(string DosyaAdi)
        {
            DosyaAdi.Trim();
            DosyaAdi = DosyaAdi.Replace(" ", "-");
            DosyaAdi = DosyaAdi.Replace("%20", "-");
            DosyaAdi = DosyaAdi.Replace("ı", "i");
            DosyaAdi = DosyaAdi.Replace("ç", "c");
            DosyaAdi = DosyaAdi.Replace("ü", "u");
            DosyaAdi = DosyaAdi.Replace("ö", "o");
            DosyaAdi = DosyaAdi.Replace("ğ", "g");
            DosyaAdi = DosyaAdi.Replace("ş", "s");

            DosyaAdi = DosyaAdi.Replace("İ", "I");
            DosyaAdi = DosyaAdi.Replace("Ç", "C");
            DosyaAdi = DosyaAdi.Replace("Ü", "U");
            DosyaAdi = DosyaAdi.Replace("Ö", "O");
            DosyaAdi = DosyaAdi.Replace("Ğ", "G");
            DosyaAdi = DosyaAdi.Replace("Ş", "S");


            // Diger

            DosyaAdi = DosyaAdi.Replace("€", "E");
            DosyaAdi = DosyaAdi.Replace("é", "e");
            DosyaAdi = DosyaAdi.Replace("ë", "e");
            DosyaAdi = DosyaAdi.Replace("ã", "a");

            // bunlari kaldir
            DosyaAdi = DosyaAdi.Replace("'", string.Empty);
            DosyaAdi = DosyaAdi.Replace("/", string.Empty);
            DosyaAdi = DosyaAdi.Replace("\\", string.Empty);
            DosyaAdi = DosyaAdi.Replace("\"", string.Empty);
            DosyaAdi = DosyaAdi.Replace("<", string.Empty);
            DosyaAdi = DosyaAdi.Replace(">", string.Empty);
            DosyaAdi = DosyaAdi.Replace("--", "-");
            DosyaAdi = DosyaAdi.Replace("---", "-");
            DosyaAdi = DosyaAdi.Replace("----", "-");
            DosyaAdi = DosyaAdi.Replace("-----", "-");
            DosyaAdi = DosyaAdi.Replace("%2c", "-");

            return DosyaAdi;

        }

        public static string ReplaceStringForNoScript(string Text)
        {
            Text.Trim();
            Text = Text.Replace("%20", "-");
           
            Text = Text.Replace("ı", "i");
            Text = Text.Replace("ç", "c");
            Text = Text.Replace("ü", "u");
            Text = Text.Replace("ö", "o");
            Text = Text.Replace("ğ", "g");
            Text = Text.Replace("ş", "s");

            Text = Text.Replace("İ", "I");
            Text = Text.Replace("Ç", "C");
            Text = Text.Replace("Ü", "U");
            Text = Text.Replace("Ö", "O");
            Text = Text.Replace("Ğ", "G");
            Text = Text.Replace("Ş", "S");


            // Diger

            Text = Text.Replace("€", "E");
            Text = Text.Replace("é", "e");
            Text = Text.Replace("ë", "e");
            Text = Text.Replace("ã", "a");

            // bunlari kaldir
            Text = Text.Replace("'", " ");
            Text = Text.Replace("/", string.Empty);
            Text = Text.Replace("\\", string.Empty);
            Text = Text.Replace("\"", string.Empty);
            Text = Text.Replace("<", string.Empty);
            Text = Text.Replace(">", string.Empty);


            return Text;


        }

        public static string RemoveNoHtml(string inputHTML)
        {
            return Regex.Replace(inputHTML, @"<[^>]*(>|$)|&nbsp;|&zwnj;|&raquo;|&laquo;", string.Empty).Trim();
        }

       public static bool RegexHEX(string hexValue)
        {

            return Regex.IsMatch(hexValue, "^([A-Fa-f0-9]{2}){8,9}$");

        }

        public static DropDownList DropOrderByName(DropDownList ddl)
        {
            List<ListItem> listCopy = new List<ListItem>();
            foreach (ListItem item in ddl.Items)
                listCopy.Add(item);
            ddl.Items.Clear();
            foreach (ListItem item in listCopy.OrderBy(item => item.Text))
                ddl.Items.Add(item);

            return ddl;
        }

        public static DropDownList DropOrderByValue(DropDownList ddl)
        {

            List<ListItem> listCopy = new List<ListItem>();
            foreach (ListItem item in ddl.Items)
                listCopy.Add(item);
            ddl.Items.Clear();
            foreach (ListItem item in listCopy.OrderBy(item => item.Value))
                ddl.Items.Add(item);

            return ddl;
        }


        public static DropDownList DropOrderByValueInt(DropDownList ddl)
        {

            List<ListItem> listCopy = new List<ListItem>();
            foreach (ListItem item in ddl.Items)
                listCopy.Add(item);
            ddl.Items.Clear();
            foreach (ListItem item in listCopy.OrderBy(item => int.Parse(item.Value)))
                ddl.Items.Add(item);

            return ddl;
        }


        public static RadioButtonList RadioOrderByValueInt(RadioButtonList rdl)
        {

            List<ListItem> listCopy = new List<ListItem>();
            foreach (ListItem item in rdl.Items)
                listCopy.Add(item);
            rdl.Items.Clear();
            foreach (ListItem item in listCopy.OrderBy(item => int.Parse(item.Value)))
                rdl.Items.Add(item);

            return rdl;
        }

        public static RadioButtonList RadioOrderByName(RadioButtonList rdl)
        {
            List<ListItem> listCopy = new List<ListItem>();
            foreach (ListItem item in rdl.Items)
                listCopy.Add(item);
            rdl.Items.Clear();
            foreach (ListItem item in listCopy.OrderBy(item => item.Text))
                rdl.Items.Add(item);

            return rdl;
        }


        public static RadioButtonList RadioOrderByValue(RadioButtonList rdl)
        {

            List<ListItem> listCopy = new List<ListItem>();
            foreach (ListItem item in rdl.Items)
                listCopy.Add(item);
            rdl.Items.Clear();
            foreach (ListItem item in listCopy.OrderBy(item => item.Value))
                rdl.Items.Add(item);

            return rdl;
        }


        // 8 karakterli Rastgele 16 lık düzende kod
        public static string CreateNewGuid()
        {
            return Guid.NewGuid().ToString().Remove(8);
        }

        // Resimi kaydeder ve kaydettiği resmin adını verir.
        // Kullanımı...
        //Bitmap src = Bitmap.FromStream(fupImage.PostedFile.InputStream) as Bitmap;
        public static string SaveImageResized(Bitmap bmp, string dosya_adi, string yol, int genislik, int yukseklik, ImageFormat resim_formati)
        {

            // Otomatik ölçeklendirme yapıyoruz.
            Bitmap yeniResim = ProportionallyResizeBitmap(bmp, genislik, yukseklik);

            yeniResim.Save(yol + "/" + dosya_adi + "." + resim_formati.ToString().ToLower(), resim_formati);

            return dosya_adi + "." + resim_formati.ToString().ToLower();

        }

        // Dosyayi okur ve içeriğini string olarak verir.
        // Email için kullanıyorum...
        public static string ReadFileForString(string yol)
        {
            StreamReader sr = new StreamReader(yol, Encoding.Default);
            string line;
            StringBuilder sb = new StringBuilder();
            do
            {
                line = sr.ReadLine();
                sb.AppendLine(line);

            }
            while (line != null);
            sr.Close();

            return sb.ToString();
        }


        public static Stream ReadFileForStream(string yol)
        {

            StreamReader sr = new StreamReader(yol, Encoding.Default);

            sr.ReadToEnd();

            sr.Close();

            return sr.BaseStream;

        }

        public static string ReadFile(string yol)
        {
            StreamReader sr = new StreamReader(yol, Encoding.Default);
            string line;
            StringBuilder sb = new StringBuilder();
            do
            {
                line = sr.ReadLine();
                sb.AppendLine(line);

            }
            while (line != null);
            sr.Close();

            return sb.ToString();
        }

        // REGEX İşlemleri

        // Email uygunluk kontrolü yapar.
        public static bool RegexEmail(string eposta)
        {
            if (string.IsNullOrEmpty(eposta))
            {

                return false;
            }
            else
            {

                return System.Text.RegularExpressions.Regex.IsMatch(eposta, @"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*");

            }

        }


        // string tarih bilgisini kontrol eder. saniye haric
        public static bool TarihKontrolu(string tarih)
        {
            DateTime fake_date;

            return DateTime.TryParse(tarih, out fake_date);
        }


        public static bool tarihKontrolu2(string tarih)
        {
            // (0[1-9]|[12][0-9]|3[01]([- /.])(0[1-9]|1[012])\2(19|20)\d\d)

            // REGEX pattern ^(?:(?:31(\/|-|\.)(?:0?[13578]|1[02]))\1|(?:(?:29|30)(\/|-|\.)(?:0?[1,3-9]|1[0-2])\2))(?:(?:1[6-9]|[2-9]\d)?\d{2})$|^(?:29(\/|-|\.)0?2\3(?:(?:(?:1[6-9]|[2-9]\d)?(?:0[48]|[2468][048]|[13579][26])|(?:(?:16|[2468][048]|[3579][26])00))))$|^(?:0?[1-9]|1\d|2[0-8])(\/|-|\.)(?:(?:0?[1-9])|(?:1[0-2]))\4(?:(?:1[6-9]|[2-9]\d)?\d{2})$
            return System.Text.RegularExpressions.Regex.IsMatch(tarih, @"^(?:(?:31(\/|-|\.)(?:0?[13578]|1[02]))\1|(?:(?:29|30)(\/|-|\.)(?:0?[1,3-9]|1[0-2])\2))(?:(?:1[6-9]|[2-9]\d)?\d{2})$|^(?:29(\/|-|\.)0?2\3(?:(?:(?:1[6-9]|[2-9]\d)?(?:0[48]|[2468][048]|[13579][26])|(?:(?:16|[2468][048]|[3579][26])00))))$|^(?:0?[1-9]|1\d|2[0-8])(\/|-|\.)(?:(?:0?[1-9])|(?:1[0-2]))\4(?:(?:1[6-9]|[2-9]\d)?\d{2})$");
            // return false;

        }


        /// <summary>
        /// Farklı bir tarih yazımı
        /// </summary>
        /// <param name="tarih"></param>
        /// <returns></returns>
        public static string tarihDuzelt(DateTime tarih)
        {
            return String.Format("{0:dd MMMM yyyy}", tarih);
        }


        public static bool SayiKontrolu(string sayi)
        {

            int fake_int = 0;
            return int.TryParse(sayi, out fake_int);

        }

        public static string IpAdresiniVer()
        {
            string IpAdresi;
            IpAdresi = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (string.IsNullOrEmpty(IpAdresi))
            {
                IpAdresi = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
            }

            return IpAdresi;

        }





        public static bool youtubeAdresKontrolu(string youtube_url, out string videokod)
        {

            bool kontrol = false;

            videokod = youtube_url.Trim();


            // & karakteri bulunamadı  video parametre içermiyor.
            if (videokod.IndexOf('&') == -1)
            {
                // Herhangi bir parametre eklenmeyen kod


                if (videokod.IndexOf("http://www.youtube.com/watch?v=") == 0)
                {

                    videokod = videokod.Substring(videokod.IndexOf('='), (videokod.Length - videokod.IndexOf('=')));
                    // '=' i kaldıralım
                    videokod = videokod.Remove(0, 1);
                    kontrol = true;

                }
                else if (videokod.IndexOf("https://www.youtube.com/watch?v=") == 0)
                {

                    videokod = videokod.Substring(videokod.IndexOf('='), (videokod.Length - videokod.IndexOf('=')));
                    // '=' i kaldıralım
                    videokod = videokod.Remove(0, 1);
                    kontrol = true;

                }
                else
                {
                    kontrol = false;
                }
            }
            else
            {
                if (videokod.IndexOf("http://www.youtube.com/watch?v=") == 0)
                {

                    videokod = videokod.Substring(videokod.IndexOf('='), (videokod.Length - videokod.IndexOf('=')));
                    // '=' i kaldıralım
                    videokod = videokod.Remove(0, 1);
                    // Toparla;

                    videokod = videokod.Remove(videokod.IndexOf('&'));
                    kontrol = true;

                }
                else if (videokod.IndexOf("https://www.youtube.com/watch?v=") == 0)
                {

                    videokod = videokod.Substring(videokod.IndexOf('='), (videokod.Length - videokod.IndexOf('=')));
                    // '=' i kaldıralım
                    videokod = videokod.Remove(0, 1);
                    // Toparla;

                    videokod = videokod.Remove(videokod.IndexOf('&'));
                    kontrol = true;

                }
                else
                {
                    kontrol = false;
                }
            }



            // Embeed kodu yerleştirelim.

            return kontrol;

            // Youtube videonuz hazır Afiyet olsun. ;-)
            // Timuçin Özmaya
        }

        public static string ConvertMoneyToText(decimal moneyVal)
        {


            string[,] digits = {{"","Bir","İki","Üç","Dört","Beş","Altı","Yedi",

"Sekiz","Dokuz"},

{"","On","Yirmi","Otuz","Kırk","Elli","Altmış","Yetmiş","Seksen",

"Doksan"},

{"","Yüz","İkiYüz","ÜçYüz","DörtYüz","BeşYüz","AltıYüz","YediYüz",

"SekizYüz","DokuzYüz"}};

            string[] groupPostfix = { "", "Bin", "Milyon", "Milyar", "Trilyon", "Katrilyon" };

            // Değerin ondalık kısmı iki basamağa ayarlanıyor ve sayı ondalık-tam

            // kısım olmak üzere iki parçaya bölünüyor.

            string[] numberParts = Math.Round(moneyVal, 2).ToString().Split(',');

            // Elde edilen rakamı işlemeye en sağdaki basamaktan başladığımız için

            // sayıyı sağdan sola doğru metine çeviriyoruz. Fakat bu değerlerin sol-

            // dan sağa doğru yazdırılması lazım. Ben bunun için stack yapısı kullan-

            // dım. Bildiğiniz gibi stack ilk girenin son çıktığı bir liste yapısını

            // ifade ediyor.

            Stack<string> words = new Stack<string>();

            long integerPart;

            int decimalPart;

            // Sağdan sola gittiğimiz için önce ondalık kısmı çeviriyoruz.
            if (numberParts.GetLength(0) == 2 && (decimalPart = int.Parse(numberParts[1])) != 0)
            {
                words.Push("<b> KR </b>");

                words.Push(digits[0, decimalPart % 10]);

                words.Push(digits[1, decimalPart / 10]);

            }



            integerPart = long.Parse(numberParts[0]);//sayının tam kısmı

            for (int digitIndex = 0; integerPart != 0; digitIndex++)
            {

                if (digitIndex == 0)

                    words.Push("<b> TL </b>");



                // her üç basamaktan sonra bin-milyon vb. uygun son ek ekleniyor.

                if (digitIndex % 3 == 0)

                    words.Push(groupPostfix[digitIndex / 3]);

                // digitIndex % 3 ile rakamın üçlü grubun neresinde olduğunu buluyoruz.

                // ona göre rakamın metin karşılığını buluyoruz.

                // örneğin 234 sayısında 3 rakamı otuz ile ifade edilirken, 123

                // sayısında üç olarak ifade edilir.

                words.Push(digits[digitIndex % 3, integerPart % 10]);

                integerPart /= 10;

                // tamsayımızı her seferinde 10'a bölüp, döngünün sonraki turunda  elde

                // ettiğimiz bu sayının 10'a bölümünden kalanı buluyoruz. Yaptığımız sa-

                // dece sayının rakamlarını elde etmek.

            }

            string sonuc = string.Concat(words.ToArray());


            // bir bin yazmasın diye 
            string soldan_temizlik = sonuc.Substring(0, 3);
            string soldan_kontrol = sonuc.Substring(3, 3);

            if (soldan_temizlik == "Bir" && soldan_kontrol == "Bin")
            {
                sonuc = sonuc.Remove(0, 3);
            }

            return sonuc;


        }


        public static string TutarDuzelt(string tutar)
        {
            tutar = tutar.Trim();

            tutar = tutar.Replace(".", ","); // nokta yerine virgul Kurus ayıracıdır. Decimal çevriminde gerekli.

            // -1 İSE YOK
            // Virgul yoksa ekleyip ,00 KR yaparız.

            int virgul_varmi = tutar.LastIndexOf(",");

            string TL = string.Empty;
            string KR = string.Empty;

            if (tutar.Contains(','))
            {
                int virgulden_sonrasi = tutar.Length - (virgul_varmi + 1);

                if (virgulden_sonrasi == 0)
                {
                    KR = "00";
                }
                else if (virgulden_sonrasi == 1)
                {
                    KR = tutar.Substring((virgul_varmi + 1), 1) + "0";
                }
                else if (virgulden_sonrasi >= 2)
                {
                    KR = tutar.Substring((virgul_varmi + 1), 2);
                }

                TL = tutar.Remove(virgul_varmi);

            }
            else
            {
                TL = tutar;
                KR = "00";
            }

            return TL + "," + KR;
        }
        /// <summary>
        /// Düzeltilmiş olarak aktarılır.
        /// </summary>
        /// <param name="tutar"></param>
        /// <returns>string değer düzeltilerek decimale çevirilir.</returns>
        public static decimal TutarStrToDecimal(string tutar)
        {
            // string değer düzeltilerek decimale çevirilir.

            decimal dec = 0;

            decimal.TryParse(TutarDuzelt(tutar), out dec);

            return dec;

        }





        // iç metodlar
        private static Bitmap ResizeBitmap(Bitmap src, int newWidth, int newHeight)
        {
            Bitmap result = new Bitmap(newWidth, newHeight);
            using (Graphics g = Graphics.FromImage((System.Drawing.Image)result)) { g.DrawImage(src, 0, 0, newWidth, newHeight); }


            return result;


        }


        private static Bitmap ProportionallyResizeBitmap(Bitmap src, int maxWidth, int maxHeight)
        {

            // original dimensions
            int w = src.Width;
            int h = src.Height;

            // Longest and shortest dimension 

            int longestDimension = (w > h) ? w : h;

            int shortestDimension = (w < h) ? w : h;

            // propotionality 

            float factor = ((float)longestDimension) / shortestDimension;

            // default width is greater than height 

            double newWidth = maxWidth;

            double newHeight = maxWidth / factor;

            // if height greater than width recalculate 

            if (w < h)
            {
                newWidth = maxHeight / factor;
                newHeight = maxHeight;

            }


            // Create new Bitmap at new dimensions

            Bitmap result = new Bitmap((int)newWidth, (int)newHeight);

            using (Graphics g = Graphics.FromImage((System.Drawing.Image)result)) g.DrawImage(src, 0, 0, (int)newWidth, (int)newHeight);

            return result;
        }

        public static bool TcNoDogrula(string tcKimlikNo)
        {

            bool returnvalue = false;

            if (tcKimlikNo.Length == 11)
            {

                Int64 ATCNO, BTCNO, TcNo;

                long C1, C2, C3, C4, C5, C6, C7, C8, C9, Q1, Q2;



                TcNo = Int64.Parse(tcKimlikNo);



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



                returnvalue = ((BTCNO * 100) + (Q1 * 10) + Q2 == TcNo);

            }

            return returnvalue;

        }





        #region Resim Kayıt

        // Bitmap src = Bitmap.FromStream(fupImage.PostedFile.InputStream) as Bitmap;


        //   Bitmap resultResized = ProportionallyResizeBitmap(src, 800, 800);
        //   Bitmap resultThumb = ProportionallyResizeBitmap(src, 160, 160);

        //   string ImgName = tuz + fupImage.FileName;

        //   string ThumbImgName = tuz + fupImage.FileName;


        //   ImgName = ImgName.Replace(" ", "-");
        //   ThumbImgName = ThumbImgName.Replace(" ", "-");


        //   string saveImgName = Server.MapPath(@"~\Images\Gallery\resized\") + ImgName;

        //   string saveThumbImgName = Server.MapPath(@"~\Images\Gallery\thumb\") + ThumbImgName;

        //   resultResized.Save(saveImgName, ImageFormat.Jpeg);

        //   resultThumb.Save(saveThumbImgName, ImageFormat.Jpeg);

        #endregion


    }

    //  Şifreleme İşlemleri





    public sealed class _Crypto
    {

        // Tuz ekle...
        private static byte[] _salt = Encoding.ASCII.GetBytes("72!85B23e#231");

        // Ön tanımlı parola
        private static string _sharedSecret = "Er4Tfcs½4&#122sdfa"; // ÖNEMLİ

        /// <summary>
        ///  Verilen string ifadeyi AES kullanarak şifreler. Şifrelenen metin        
        ///  DecryptStringAES() kullanılarak şifresi çözülebilir. 
        /// </summary>
        /// <param name="plainText">şifrelenecek metin</param>
        /// <param name="sharedSecret">şifreleme için kullanılacak parola</param>
        public static string SifreleAES(string plainText, string sharedSecret)
        {
            if (string.IsNullOrEmpty(plainText))
                throw new ArgumentNullException("plainText");
            if (string.IsNullOrEmpty(sharedSecret))
                throw new ArgumentNullException("sharedSecret");

            string outStr = null;
            RijndaelManaged aesAlg = null;

            try
            {

                Rfc2898DeriveBytes key = new Rfc2898DeriveBytes(sharedSecret, _salt);
                aesAlg = new RijndaelManaged();
                aesAlg.Key = key.GetBytes(aesAlg.KeySize / 8);


                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);


                using (MemoryStream msEncrypt = new MemoryStream())
                {

                    msEncrypt.Write(BitConverter.GetBytes(aesAlg.IV.Length), 0, sizeof(int));
                    msEncrypt.Write(aesAlg.IV, 0, aesAlg.IV.Length);
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            swEncrypt.Write(plainText);
                        }
                    }
                    outStr = Convert.ToBase64String(msEncrypt.ToArray());
                }
            }
            finally
            {

                if (aesAlg != null)
                    aesAlg.Clear();
            }


            return outStr;
        }

        /// <summary>
        ///  Verilen string ifadeyi AES kullanarak şifreler. Şifrelenen metin        
        ///  DecryptStringAES() kullanılarak şifresi çözülebilir. 
        /// </summary>
        /// <param name="plainText">şifrelenecek metin</param>
        public static string SifreleAES(string plainText)
        {
            if (string.IsNullOrEmpty(plainText))
                throw new ArgumentNullException("plainText");
            if (string.IsNullOrEmpty(_sharedSecret))
                throw new ArgumentNullException("sharedSecret");

            string outStr = null;
            RijndaelManaged aesAlg = null;

            try
            {

                Rfc2898DeriveBytes key = new Rfc2898DeriveBytes(_sharedSecret, _salt);
                aesAlg = new RijndaelManaged();
                aesAlg.Key = key.GetBytes(aesAlg.KeySize / 8);


                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);


                using (MemoryStream msEncrypt = new MemoryStream())
                {

                    msEncrypt.Write(BitConverter.GetBytes(aesAlg.IV.Length), 0, sizeof(int));
                    msEncrypt.Write(aesAlg.IV, 0, aesAlg.IV.Length);
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            swEncrypt.Write(plainText);
                        }
                    }
                    outStr = Convert.ToBase64String(msEncrypt.ToArray());
                }
            }
            finally
            {

                if (aesAlg != null)
                    aesAlg.Clear();
            }


            return outStr;
        }

        /// <summary>
        /// EncryptStringAES() ile şifrelenen metnin şifresini çözer.      
        /// </summary>
        /// <param name="cipherText">Deşifre edilecek metin uzmanim.net</param>
        /// <param name="sharedSecret">Paylaşılan gizli anahtar</param>
        public static string SifreyiCozAES(string cipherText, string sharedSecret)
        {
            if (string.IsNullOrEmpty(cipherText))
                throw new ArgumentNullException("cipherText");
            if (string.IsNullOrEmpty(sharedSecret))
                throw new ArgumentNullException("sharedSecret");


            RijndaelManaged aesAlg = null;


            string plaintext = null;

            try
            {

                Rfc2898DeriveBytes key = new Rfc2898DeriveBytes(sharedSecret, _salt);


                byte[] bytes = Convert.FromBase64String(cipherText);
                using (MemoryStream msDecrypt = new MemoryStream(bytes))
                {

                    aesAlg = new RijndaelManaged();
                    aesAlg.Key = key.GetBytes(aesAlg.KeySize / 8);
                    aesAlg.IV = ReadByteArray(msDecrypt);

                    ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))

                            //uzmanim.net
                            plaintext = srDecrypt.ReadToEnd();
                    }
                }
            }
            finally
            {

                if (aesAlg != null)
                    aesAlg.Clear();
            }

            return plaintext;
        }

        /// <summary>
        /// EncryptStringAES() ile şifrelenen metnin şifresini çözer.      
        /// </summary>
        /// <param name="cipherText">Deşifre edilecek metin uzmanim.net</param>
        public static string SifreyiCozAES(string cipherText)
        {
            if (string.IsNullOrEmpty(cipherText))
                throw new ArgumentNullException("cipherText");
            if (string.IsNullOrEmpty(_sharedSecret))
                throw new ArgumentNullException("sharedSecret");


            RijndaelManaged aesAlg = null;


            string plaintext = null;

            try
            {

                Rfc2898DeriveBytes key = new Rfc2898DeriveBytes(_sharedSecret, _salt);


                byte[] bytes = Convert.FromBase64String(cipherText);
                using (MemoryStream msDecrypt = new MemoryStream(bytes))
                {

                    aesAlg = new RijndaelManaged();
                    aesAlg.Key = key.GetBytes(aesAlg.KeySize / 8);
                    aesAlg.IV = ReadByteArray(msDecrypt);

                    ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))

                            //uzmanim.net
                            plaintext = srDecrypt.ReadToEnd();
                    }
                }
            }
            finally
            {

                if (aesAlg != null)
                    aesAlg.Clear();
            }

            return plaintext;
        }

        private static byte[] ReadByteArray(Stream s)
        {
            byte[] rawLength = new byte[sizeof(int)];
            if (s.Read(rawLength, 0, rawLength.Length) != rawLength.Length)
            {
                throw new SystemException("Stream did not contain properly formatted byte array");
            }

            byte[] buffer = new byte[BitConverter.ToInt32(rawLength, 0)];
            if (s.Read(buffer, 0, buffer.Length) != buffer.Length)
            {
                throw new SystemException("Did not read byte array properly");
            }

            return buffer;
        }
    }


    public sealed class _Crypto2
    {

        private const string AesIV = @"!FRY7WSX#EDC4RFV";
        private static string AesKey = @"3TGB&YHN7UJM(IK<";

        public static string SifreleAES(string text)
        {

            AesCryptoServiceProvider aes = new AesCryptoServiceProvider();
            aes.BlockSize = 128;
            aes.KeySize = 128;

            aes.IV = Encoding.UTF8.GetBytes(AesIV);
            aes.Key = Encoding.UTF8.GetBytes(AesKey);
            aes.Mode = CipherMode.CBC;
            aes.Padding = PaddingMode.PKCS7;

            byte[] src = Encoding.Unicode.GetBytes(text);

            using (ICryptoTransform encrypt = aes.CreateEncryptor())
            {

                byte[] dest = encrypt.TransformFinalBlock(src, 0, src.Length);

                return Convert.ToBase64String(dest);
            }
        }

        public static string SifreyiCozAES(string text)
        {

            AesCryptoServiceProvider aes = new AesCryptoServiceProvider();
            aes.BlockSize = 128;
            aes.KeySize = 128;
            aes.IV = Encoding.UTF8.GetBytes(AesIV);
            aes.Key = Encoding.UTF8.GetBytes(AesKey);
            aes.Mode = CipherMode.CBC;
            aes.Padding = PaddingMode.PKCS7;

            byte[] src = System.Convert.FromBase64String(text);

            using (ICryptoTransform decrypt = aes.CreateDecryptor())
            {
                byte[] dest = decrypt.TransformFinalBlock(src, 0, src.Length);
                return Encoding.Unicode.GetString(dest);
            }

        }

    }

    public static class _XML
    {
       //public static string RemoveInvalidXmlChars2(string text)
       // {
       //     var validXmlChars = text.Where(ch => XmlConvert.IsXmlChar(ch)).ToArray();
       //     return new string(validXmlChars);
       // }

       //public static bool IsValidXmlString(string text)
       // {
       //     try
       //     {
       //         XmlConvert.VerifyXmlChars(text);
       //         return true;
       //     }
       //     catch
       //     {
       //         return false;
       //     }
       // }

       public static string CleanInvalidXmlChars(string Xml, string XMLVersion)
       {
           string pattern = String.Empty;
           switch (XMLVersion)
           {
               case "1.0":
                   pattern = @"&#x((10?|[2-F])FFF[EF]|FDD[0-9A-F]|7F|8[0-46-9A-F]9[0-9A-F]);";
                   break;
               case "1.1":
                   pattern = @"&#x((10?|[2-F])FFF[EF]|FDD[0-9A-F]|[19][0-9A-F]|7F|8[0-46-9A-F]|0?[1-8BCEF]);";
                   break;
               default:
                   throw new Exception("Error: Invalid XML Version!");
           }

           Regex regex = new Regex(pattern, RegexOptions.IgnoreCase);
           if (regex.IsMatch(Xml))
               Xml = regex.Replace(Xml, String.Empty);
           return Xml;
       }

       //public static string RemoveInvalidXmlChars(string text)
       //{
       //    if (string.IsNullOrEmpty(text))
       //        return text;

       //    int length = text.Length;
       //    StringBuilder stringBuilder = new StringBuilder(length);

       //    for (int i = 0; i < length; ++i)
       //    {
       //        if (XmlConvert.IsXmlChar(text[i]))
       //        {
       //            stringBuilder.Append(text[i]);
       //        }
       //        else if (i + 1 < length && XmlConvert.IsXmlSurrogatePair(text[i + 1], text[i]))
       //        {
       //            stringBuilder.Append(text[i]);
       //            stringBuilder.Append(text[i + 1]);
       //            ++i;
       //        }
       //    }

       //    return stringBuilder.ToString();
       //}

       public static string XmlCharacterWhitelist(string in_string)
       {
           if (in_string == null) return null;

           StringBuilder sbOutput = new StringBuilder();
           char ch;

           for (int i = 0; i < in_string.Length; i++)
           {
               ch = in_string[i];
               if ((ch >= 0x0020 && ch <= 0xD7FF) ||
                   (ch >= 0xE000 && ch <= 0xFFFD) ||
                   ch == 0x0009 ||
                   ch == 0x000A ||
                   ch == 0x000D)
               {
                   sbOutput.Append(ch);
               }
           }
           return sbOutput.ToString();
       }



    }

    public static class _Security
    {
        public static string RemoveEscapeChar(string text)
        {
            // string text = "Escape characters ： < > & \" \'";
         return SecurityElement.Escape(text); // XML içinde kullanılabilir.
        }

    }


    public static class _DataTableToEXCEL
    {

        //public static string ToCSV(DataTable tbl)
        //{
        //    StringBuilder strb = new StringBuilder();

        //    //column headers
        //    strb.AppendLine(tbl.Columns.Cast<DataColumn>().Aggregate(
        //        (object x, object y) => x + "," + y).ToString());

        //    //rows
        //    tbl.AsEnumerable().Select(s => strb.AppendLine(
        //        s.ItemArray.Aggregate((x, y) => x + "," + y).ToString())).ToList();

        //    return strb.ToString();
        //}

    }

    public static class HtmlRemoval
    {
        /// <summary>
        /// Remove HTML from string with Regex.
        /// </summary>
        public static string StripTagsRegex(string source)
        {
            return Regex.Replace(source, "<.*?>", string.Empty);
        }

        /// <summary>
        /// Compiled regular expression for performance.
        /// </summary>
        static Regex _htmlRegex = new Regex("<.*?>", RegexOptions.Compiled);

        /// <summary>
        /// Remove HTML from string with compiled Regex.
        /// </summary>
        public static string StripTagsRegexCompiled(string source)
        {
            return _htmlRegex.Replace(source, string.Empty);
        }

        /// <summary>
        /// Remove HTML tags from string using char array.
        /// </summary>
        public static string StripTagsCharArray(string source)
        {
            char[] array = new char[source.Length];
            int arrayIndex = 0;
            bool inside = false;

            for (int i = 0; i < source.Length; i++)
            {
                char let = source[i];
                if (let == '<')
                {
                    inside = true;
                    continue;
                }
                if (let == '>')
                {
                    inside = false;
                    continue;
                }
                if (!inside)
                {
                    array[arrayIndex] = let;
                    arrayIndex++;
                }
            }

            return new string(array, 0, arrayIndex);
        }
    }



}

