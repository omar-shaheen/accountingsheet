using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.IO;
namespace ACCOUNTINGSHEET.Helper
{
     public static class ComputeHash
    {
                                                       
        public static string ComputeMD5Hash(string str)
        {
            var BytesClientSecret = System.Text.Encoding.UTF8.GetBytes(str);
            var MD5 = System.Security.Cryptography.MD5.Create();
            var MD5ClientSecretBytesArr = MD5.ComputeHash(BytesClientSecret);
            var MD5ClientSecretString = System.Text.Encoding.UTF8.GetString(MD5ClientSecretBytesArr);
            return MD5ClientSecretString;
        }

        public static string GetHash(string input)
        {
            HashAlgorithm hashAlgorithm = new SHA256CryptoServiceProvider();

            byte[] byteValue = System.Text.Encoding.UTF8.GetBytes(input);

            byte[] byteHash = hashAlgorithm.ComputeHash(byteValue);

            return Convert.ToBase64String(byteHash);
        }

        public static string GetMD5Password(string Password)
        {
            var Crypto = new System.Security.Cryptography.MD5CryptoServiceProvider();
            byte[] bs = System.Text.Encoding.UTF8.GetBytes(Password);
            bs = Crypto.ComputeHash(bs);
            var Builder = new System.Text.StringBuilder();
            foreach (byte b in bs)
            {
                Builder.Append(b.ToString("x2").ToLower());
            }
            return Builder.ToString();
        }
        //this function Convert to Decord your Password
        public static string DecodeFrom64(string encodedData)
        {
            System.Text.UTF8Encoding encoder = new System.Text.UTF8Encoding();
            System.Text.Decoder utf8Decode = encoder.GetDecoder();
            byte[] todecode_byte = Convert.FromBase64String(encodedData);
            int charCount = utf8Decode.GetCharCount(todecode_byte, 0, todecode_byte.Length);
            char[] decoded_char = new char[charCount];
            utf8Decode.GetChars(todecode_byte, 0, todecode_byte.Length, decoded_char, 0);
            string result = new String(decoded_char);
            return result;
        }
        //this function Convert to Encord your Password 
        public static string EncodePasswordToBase64(string password)
        {
            try
            {
                byte[] encData_byte = new byte[password.Length];
                encData_byte = System.Text.Encoding.UTF8.GetBytes(password);
                string encodedData = Convert.ToBase64String(encData_byte);
                return encodedData;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in base64Encode" + ex.Message);
            }
        }




    }
    }