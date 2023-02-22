using Core.Utilities.Business;
using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Helpers.FileHelper
{

    public class FileHelperManager : IFileHelper
    {
        public void Delete(string filePath)
        {//if kontrolü ile parametrede gelen adreste öyle bir dosya var mı diye kontrol ediliyor.
            if (File.Exists(filePath))
            {//Eğer aynı dosya var ise dosya bulunduğu yerden siliniyor.
                File.Delete(filePath);
            }
        }

        public string Update(IFormFile file, string filePath, string root)
        {



            // Tekrar if kontrolü ile parametrede gelen adreste öyle bir dosya var mı diye kontrol ediliyor.
            if (File.Exists(filePath))
            {//Eğer yine aynı dosya var ise dosya bulunduğu yerden siliniyor.
                File.Delete(filePath);
            }

            // Eski dosya silindikten sonra yerine geçecek yeni dosyaiçin alttaki *Upload* metoduna yeni dosya ve kayıt edileceği adres parametre olarak döndürülüyor.
            return Upload(file, root);  
        }

        public string Upload(IFormFile file, string root)
        {

         



            if (file.Length > 0)//file.Length=>Dosya uzunluğunu bayt olarak alır. Burada gönderilen dosya kontrol edilir.( Dosya gönderilmiş mi gönderilmemiş diye test işlemi yapıldı.)
            {
                //Directory=>System.IO'nın bir class'ı. burada ki işlem tam olarak şu.
                //Bu Upload metodumun parametresi olan string root CarManager'dan gelmekte
                //Business > Concrete > CarImageManager içerisine girdiğinizde buraya parametre olarak *PathConstants.ImagesPath*
                //şeklinde bir parametre gönderilidğini görürsünüz. Business > Contains > PathConstants clası içerisine girdiğinizde string bir dizin adres mevcut.
                //O adres bizim Yükleyeceğimiz dosyaların kayıt edileceği adrestir.
                //*Check if a directory Exists* ifadesi: Dosyanın kaydedileceği adres dizini var mı? kontrol ediyor
                //varsa if yapısının kod bloğundan ayrılır eğer yoksa içinde ki kodda dosyaların kayıt edilecek dizini oluşturur.
                if (!Directory.Exists(root))
                {                           
                                          
                    Directory.CreateDirectory(root);
                }
                //Path.GetExtension(file.FileName)=>> Seçmiş olduğumuz dosyanın uzantısını elde ediyoruz.
                string extension = Path.GetExtension(file.FileName);
             

                //Core.Utilities.Helpers.GuidHelper klasürünün içinde ki GuidManager klasörüne giderseniz GUID bir değer türetildiğini görürsünüz.
                string guid = GuidHelper.GuidHelper.CreateGuid();



                //Dosyanın oluşturduğum adını ve uzantısını yan yana getiriyorum.
                //Mesela metin dosyası ise .txt gibi bu projemizde resim yükyeceğimiz için .jpg olacak uzantılar 
                string filePath = guid + extension;

                using (FileStream fileStream = File.Create(root + filePath))//Burada en başta FileStream class'ının bir örneği oluşturulu., sonrasında File.Create(root + newPath)=>Belirtilen yolda bir dosya oluşturur veya üzerine yazar. (root + newPath)=>Oluşturulacak dosyanın yolu ve adı.
                {
                    file.CopyTo(fileStream);//Dosyanın kopyalanacağı akışı belirttik. yani yukarıda gelen IFromFile türündeki file dosyasının nereye kopyalacağını söyledik.
                    fileStream.Flush();//arabellekten siler.
                    return filePath;//Sql'de yer alan tabloya dosya, kendi adı ile eklenmesi için dosya yerini döndürüyoruz.
                }
            }
            return null;
        }


      
    }
}
