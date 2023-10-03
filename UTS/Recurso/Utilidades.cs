using System.Security.Cryptography;
using System.Text;


namespace UTS.Recurso
{
    public class Utilidades
    {
        public static string EncriptarClave(string password)
        {
            //stringbuilder permite crear cadenas de textos mas eficientes
            // a diferencia de las cadenas tradicionales estas son mutable lo que
            // permite añadir, eliminar nuevos caracteres
            StringBuilder sb = new StringBuilder();
            // crear HASH para encriptar
            using (SHA256 hash = SHA256Managed.Create())
            {
                //codificacion UTF8
                Encoding enc = Encoding.UTF8;
                byte[] result = hash.ComputeHash(enc.GetBytes(password));
                foreach (byte b in result)
                {
                    //Concatenar todo los que debe ser el resultado del cifrado
                    sb.Append(b.ToString("x2"));//x2 es el formato para que la cadena obtenga un formato hexadecimal
                }
            }
            return sb.ToString();
        }
    }
}
