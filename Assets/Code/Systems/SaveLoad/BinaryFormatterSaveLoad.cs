using System.IO;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;

namespace TAMKShooter.Systems.SaveLoad
{
    public class BinaryFormatterSaveLoad<T> : ISaveLoad<T> where T : class
    {
        public string FileExtension { get { return ".dat"; } }


        public string GetSaveFilePath(string saveFileName)
        {
            return Path.Combine( Application.persistentDataPath, saveFileName + FileExtension );
        }

        public void Save(T objectToSave, string fileName)
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            using (MemoryStream stream = new MemoryStream())
            {
                binaryFormatter.Serialize(stream, objectToSave);

                File.WriteAllBytes(GetSaveFilePath(fileName), stream.GetBuffer());
            }
        }

        public T Load(string fileName)
        {
            if (DoesSaveExist(fileName))
            {
                byte[] data = File.ReadAllBytes(GetSaveFilePath(fileName));

                BinaryFormatter binaryFormatter = new BinaryFormatter();

                using (MemoryStream stream = new MemoryStream(data))
                {
                    return (T)binaryFormatter.Deserialize(stream);
                }
            }

            return default(T);
        }

        public bool DoesSaveExist(string fileName)
        {
            return File.Exists(GetSaveFilePath(fileName));
        }
    }
}
