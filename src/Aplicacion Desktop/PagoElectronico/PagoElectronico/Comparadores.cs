using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using PagoElectronico;

namespace Comparadores
{
    public static class Comparadores 
    {
        /*VERIFICA QUE UN STRING SOLO CONTENGA NUMEROS*/
        public static bool IsNumeric(this string numero)
        {
            Regex rgx = new Regex(@"^([\d]+)$"); /*+\.  -->  ([\w-]+\.)*?*/
            return rgx.IsMatch(numero);
        }
        
        /*DEVUELVE UNA CADENA ENCRIPTADA POR EL ALGORITMO SHA256*/
        public static string Sha256(this string password)
        {
            SHA256Managed crypt = new SHA256Managed();
            string hash = String.Empty;
            byte[] crypto = crypt.ComputeHash(Encoding.UTF8.GetBytes(password), 0, Encoding.UTF8.GetByteCount(password));
            foreach (byte bit in crypto)
            {
                hash += bit.ToString("x2");
            }
            return hash;
        }
    }

}
