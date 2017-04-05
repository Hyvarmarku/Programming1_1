using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TAMKShooter.Exceptions;
using TAMKShooter.Systems.SaveLoad;

namespace TAMKShooter.Systems
{
    public enum LangCode
    {
        NA = 0,
        EN = 1,
        FI = 2,
        DE = 3
    }

    public static class Localization
    {
        public const string LocalizationFolderName = "Localizations";
        public const string FileExtension = ".json";

        public static event Action LanguageLoaded;

        public static string LocalizationPath
        {
            get { return Path.Combine(Application.streamingAssetsPath, LocalizationFolderName); }
        }

        public static Langugage CurrentLangugage { get; private set; }

        public static string GetLocalizationFilePath(LangCode langCode)
        {
            return Path.Combine(LocalizationPath, langCode.ToString()) + FileExtension;
        }

        public static void LoadLanguage(LangCode langCode)
        {
            if (Application.isPlaying)
            {
                SaveManager.Language = langCode;
            }

            var path = GetLocalizationFilePath(langCode);
            if (File.Exists(path))
            {
                string jsonLocalization = File.ReadAllText(path);
                CurrentLangugage = JsonUtility.FromJson<Langugage>(jsonLocalization);
                CurrentLangugage.LanguageCode = langCode;

                if(LanguageLoaded != null)
                    LanguageLoaded();
            }
            else
            {
                throw new LocalizationNotFoundException(langCode);
            }
        }

        public static void CreateNewLanguage(LangCode langCode)
        {
            CurrentLangugage = new Langugage(langCode);
        }

        public static void SaveCurrentLanguage()
        {
            if (CurrentLangugage.LanguageCode == LangCode.NA)
                return;

            if (!Directory.Exists(LocalizationPath))
            {
                Directory.CreateDirectory(LocalizationPath);
            }

            string path = GetLocalizationFilePath(CurrentLangugage.LanguageCode);
            string jsonLanguage = JsonUtility.ToJson(CurrentLangugage);
            File.WriteAllText(path, jsonLanguage);
        }
    }

    [Serializable]
    public class Langugage
    {
        [SerializeField]
        private List<string> _keys = new List<string>();
        [SerializeField]
        private List<string> _values = new List<string>();

        private bool _isInitialized = false;
        private LangCode _langCode;

        public LangCode LanguageCode
        {
            get { return _langCode; }
            set
            {
                _langCode = value;
                _isInitialized = true;
            }
        }

        public Langugage()
        {
            Debug.Log("Language created but not initialized");
        }
        public Langugage(LangCode langCode)
        {
            LanguageCode = langCode;
            Debug.Log("Language created and initialized");
        }

        public string GetTranslation(string key)
        {
            string result = null;

            int index = _keys.IndexOf(key);
            if (index >= 0)
            {
                result = _values[index];
            }

            return result;
        }

#if UNITY_EDITOR

        public void SetValues(Dictionary<string, string> values)
        {
            _keys.Clear();
            _values.Clear();

            foreach (var kvp in values)
            {
                _keys.Add(kvp.Key);
                _values.Add(kvp.Value);
            }
        }

        public Dictionary<string, string> GetValues()
        {
            Dictionary<string, string> result = new Dictionary<string, string>();

            for (int i = 0; i < _keys.Count; i++)
            {
                result.Add(_keys[i], _values[i]);
            }

            return result;
        }

#endif
    }
}
