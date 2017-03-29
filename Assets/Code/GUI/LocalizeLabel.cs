using System.Collections;
using System.Collections.Generic;
using TAMKShooter.Systems;
using UnityEngine;
using UnityEngine.UI;

namespace TAMKShooter.GUI
{
    public class LocalizeLabel : MonoBehaviour
    {
        [SerializeField]
        private Text _text;
        [SerializeField]
        private string _key;

        private void Awake()
        {
            if (_text == null)
            {
                _text = GetComponent<Text>();
            }
            Localization.LanguageLoaded += LanguageLoaded;
        }

        private void LanguageLoaded()
        {
            _text.text = Localization.CurrentLangugage.GetTranslation(_key);
        }

        private void Start()
        {
            LanguageLoaded();
        }
    }
}