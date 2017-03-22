using UnityEngine;
using TAMKShooter.Systems;
using UnityEngine.UI;
using System.Collections;

namespace TAMKShooter.GUI
{
    public class GlobalGUI : MonoBehaviour
    {
        private LoadingIndicator _loadingIndicator;
        protected void Awake()
        {
            DontDestroyOnLoad(this.gameObject);
            _loadingIndicator = GetComponentInChildren<LoadingIndicator>(true);
            _loadingIndicator.Init();
        }
    }
}