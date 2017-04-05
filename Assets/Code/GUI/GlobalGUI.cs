using UnityEngine;
using TAMKShooter.Systems;
using UnityEngine.UI;
using System.Collections;

namespace TAMKShooter.GUI
{
    public class GlobalGUI : MonoBehaviour
    {
        private LoadingIndicator _loadingIndicator;

        private static GlobalGUI _current;

        protected void Awake()
        {
            if (_current == null)
            {
                _current = this;
                DontDestroyOnLoad(this.gameObject);
                _loadingIndicator = GetComponentInChildren<LoadingIndicator>(true);
                _loadingIndicator.Init();
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}