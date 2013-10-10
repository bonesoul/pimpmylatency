using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using System.IO;

namespace pimpmylatency
{
    public static class config_manager
    {
        public static config loaded_config;

        public static void serialize(string file, config cfg)
        {
            //encrpyt 
            cfg.password = encrpyt(cfg.password, cfg.username);
            cfg.server_address = encrpyt(cfg.server_address, cfg.username);
            cfg.wow_path = encrpyt(cfg.wow_path, cfg.username);
            cfg.username = encrpyt(cfg.username, cfg.password);

            Stream stream = File.Open(file, FileMode.Create);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(stream, cfg);
            stream.Close();
        }

        public static config deserialize(string file)
        {
            config cfg = new config();
            Stream stream = File.Open(file, FileMode.Open);
            BinaryFormatter bf = new BinaryFormatter();
            cfg = (config)bf.Deserialize(stream);
            stream.Close();

            //decrypt
            cfg.username = decrypt(cfg.username, cfg.password);
            cfg.wow_path = decrypt(cfg.wow_path, cfg.username);
            cfg.server_address = decrypt(cfg.server_address, cfg.username);
            cfg.password = decrypt(cfg.password, cfg.username);
            return cfg;
        }

        public static string encrpyt(string data, string key)
        {
            byte[] key_array;
            byte[] data_array = UTF8Encoding.UTF8.GetBytes(data);

            MD5CryptoServiceProvider hash_md5 = new MD5CryptoServiceProvider();
            key_array = hash_md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));

            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
            tdes.Key = key_array;
            tdes.Mode = CipherMode.ECB;
            ICryptoTransform ctransform = tdes.CreateEncryptor();
            byte[] result_array = ctransform.TransformFinalBlock(data_array, 0, data_array.Length);

            hash_md5.Clear();
            tdes.Clear();
            return Convert.ToBase64String(result_array, 0, result_array.Length);
        }

        public static string decrypt(string data, string key)
        {
            byte[] key_array;
            byte[] data_array = Convert.FromBase64String(data);

            MD5CryptoServiceProvider hash_md5 = new MD5CryptoServiceProvider();
            key_array = hash_md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));

            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
            tdes.Key = key_array;
            tdes.Mode = CipherMode.ECB;
            tdes.Padding = PaddingMode.PKCS7;
            ICryptoTransform ctransform = tdes.CreateDecryptor();
            byte[] result_array = ctransform.TransformFinalBlock(data_array, 0, data_array.Length);
            
            hash_md5.Clear();
            tdes.Clear();
            return UTF8Encoding.UTF8.GetString(result_array);
        }

        public static Boolean load_config()
        {
            try
            {
                string cfg_file = utils.get_app_path() + @"\pml";
                config cfg = deserialize(cfg_file );
                loaded_config = cfg;
                return true;
            }
            catch(Exception e)
            {
                return false;
            }
        }

        public static void save_config(config cfg)
        {
            string cfg_file = utils.get_app_path() + @"\pml";
            serialize(cfg_file, cfg);
        }



    }

    [Serializable]
    public class config : ISerializable
    {
        public string server_address;
        public Int32 port;
        public string username;
        public string password;
        public Boolean remember_password;
        public string wow_path;

        public config()
        {

        }

        public config(SerializationInfo info, StreamingContext ctxt)
        {
                this.server_address = (string)info.GetValue("addr", typeof(string));
                this.port = (Int32)info.GetValue("port", typeof(Int32));
                this.username = (string)info.GetValue("usr", typeof(string));
                this.password = (string)info.GetValue("pwd", typeof(string));
                this.remember_password = (Boolean)info.GetValue("rememberpw", typeof(Boolean));
                this.wow_path = (string)info.GetValue("path", typeof(string));
        }

        public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
        {
            info.AddValue("addr", this.server_address);
            info.AddValue("port", this.port);
            info.AddValue("usr", this.username);
            info.AddValue("pwd", this.password);
            info.AddValue("rememberpw", this.remember_password);
            info.AddValue("path", this.wow_path);
        }
    }
}
