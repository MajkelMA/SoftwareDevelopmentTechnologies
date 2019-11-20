using System.IO;
using System.Text;

namespace Serialization
{
    public static class WriteReadFile
    {
        public static void Write(string path, string toSerialize)
        {
            if (File.Exists(path))
            {
                File.Delete(path);
            }

            using (FileStream fs = File.Create(path))
            {
                AddText(fs, toSerialize);
            }
        }

        public static string Read(string path)
        {
            using (FileStream fs = File.OpenRead(path))
            {
                StreamReader reader = new StreamReader(fs);
                return reader.ReadToEnd();
            }
        }

        private static void AddText(FileStream fs, string value)
        {
            byte[] info = new UTF8Encoding(true).GetBytes(value);
            fs.Write(info, 0, info.Length);
        }
    }
}
