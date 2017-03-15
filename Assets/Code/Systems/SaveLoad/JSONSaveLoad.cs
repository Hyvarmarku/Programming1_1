using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using UnityEngine;

namespace TAMKShooter.Systems.SaveLoad
{
    public class JSONSaveLoad<T> : ISaveLoad<T> where T : class
    {
        public string FileExtension { get { return ".json"; }}

        public string GetSaveFilePath(string saveFileName)
        {
            return Path.Combine(Application.persistentDataPath, saveFileName + FileExtension);
        }

        public void Save(T objectToSave, string fileName)
        {
            var saveFile = JsonUtility.ToJson(objectToSave,true);
            File.WriteAllText(GetSaveFilePath(fileName), saveFile, Encoding.UTF8);

            //using (FileStream fs = new FileStream(GetSaveFilePath(fileName), FileMode.Create))
            //{
            //    using (StreamWriter writer = new StreamWriter(fs))
            //    {
            //        writer.Write(saveFile);
            //    }
            //}
        }

        public T Load(string fileName)
        {
            if (DoesSaveExist(fileName))
            {
                var loadFile = File.ReadAllText(GetSaveFilePath(fileName), Encoding.UTF8);
                return JsonUtility.FromJson<T>(loadFile);
            }

            return default(T);
        }

        public bool DoesSaveExist(string fileName)
        {
            return File.Exists(GetSaveFilePath(fileName));
        }
    }
}
