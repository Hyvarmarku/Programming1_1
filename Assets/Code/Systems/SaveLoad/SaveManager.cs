using System.Collections.Generic;
using TAMKShooter.Data;
using System.IO;
using UnityEngine;

namespace TAMKShooter.Systems.SaveLoad
{
    public class SaveManager
    {
        public string FileExtension { get { return _saveLoad.FileExtension; } }

        private readonly ISaveLoad<GameData> _saveLoad;

        public SaveManager(ISaveLoad<GameData> saveLoad)
        {
            _saveLoad = saveLoad;
        }

        public void Save(GameData data, string saveFileName)
        {
            _saveLoad.Save(data, saveFileName);
        }

        public GameData Load(string saveFileName)
        {
            GameData loadFile = null;
            loadFile = _saveLoad.Load(saveFileName);
            return loadFile;
        }

        public List<string> GetAllSaveNames()
        {
            List<string> saveNames = new List<string>();
            DirectoryInfo directoryInfo = new DirectoryInfo( Application.persistentDataPath );
            FileInfo[] files = directoryInfo.GetFiles("*" + FileExtension );

            foreach (var fileInfo in files)
            {
                string fileName = fileInfo.Name;
                fileName = fileName.Replace(FileExtension, "");
                saveNames.Add(fileName);
            }

            return saveNames;
        }
    }
}
