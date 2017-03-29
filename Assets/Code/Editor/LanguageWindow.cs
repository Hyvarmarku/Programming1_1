using System;
using System.Collections.Generic;
using System.IO;
using TAMKShooter.Systems;
using UnityEditor;
using UnityEngine;

public class LanguageWindow : EditorWindow
{
    [MenuItem("Localization/Edit")]
    static void OpenWindow()
    {
        LanguageWindow window = GetWindow<LanguageWindow>();
        window.Show();
    }

    private const string LocalizationKey = "Localization";

    public LangCode LanguageCode = LangCode.NA;

    private Langugage _currentLanguage;
    private Dictionary<string, string> _localizations = new Dictionary<string, string>();

    private void OnEnable()
    {
        string language = EditorPrefs.GetString(LocalizationKey, LangCode.NA.ToString());
        LangCode langCode = (LangCode) Enum.Parse(typeof (LangCode), language);
        SetLanguage(langCode);
    }

    private void OnGUI()
    {
        LangCode langCode = (LangCode) EditorGUILayout.EnumPopup(LanguageCode);
        SetLanguage(langCode);

        EditorGUILayout.BeginVertical();

        Dictionary<string, string> newValues = new Dictionary<string, string>();
        foreach (var localization in _localizations)
        {
            EditorGUILayout.BeginHorizontal();

            string key = EditorGUILayout.TextField(localization.Key);
            string value = EditorGUILayout.TextField(localization.Value);
            newValues.Add(key, value);

            EditorGUILayout.EndHorizontal();
        }

        _localizations = newValues;

        if (GUILayout.Button("Add Value"))
        {
            if (!_localizations.ContainsKey(""))
            {
                _localizations.Add("", "");
            }
        }

        if (GUILayout.Button("Save"))
        {
            Localization.CurrentLangugage.SetValues(_localizations);
            Localization.SaveCurrentLanguage();
        }

        EditorGUILayout.EndVertical();
    }

    private void SetLanguage(LangCode langCode)
    {
        if (LanguageCode != langCode)
        {
            LanguageCode = langCode;
            EditorPrefs.SetString(LocalizationKey, LanguageCode.ToString());
            _localizations.Clear();

            var path = Localization.GetLocalizationFilePath(langCode);

            if (File.Exists(path))
            {
                Localization.LoadLanguage(langCode);
                _localizations = Localization.CurrentLangugage.GetValues();
            }
            else
            {
                Localization.CreateNewLanguage(langCode);
            }
        }
    }
}

