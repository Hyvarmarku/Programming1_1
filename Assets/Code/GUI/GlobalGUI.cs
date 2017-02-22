using UnityEngine;
using TAMKShooter.Systems;
using UnityEngine.UI;
using System.Collections;

namespace TAMKShooter.GUI
{
    public class GlobalGUI : MonoBehaviour
    {
        protected void Awake()
        {
            DontDestroyOnLoad(this.gameObject);
        }
    }
}