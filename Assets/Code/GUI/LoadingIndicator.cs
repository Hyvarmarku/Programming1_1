using UnityEngine;
using TAMKShooter.Systems;
using System.Collections;
using UnityEngine.UI;
using DG.Tweening;
using System;

namespace TAMKShooter.GUI
{
    public class LoadingIndicator : MonoBehaviour
    {
        [SerializeField]
        private Image _indicatorImage;
        [SerializeField]
        Image _backgroundImage;

        private Coroutine _rotateCoroutine;

        protected void Awake()
        {
            Global.Instance.gameManager.GameStateChanging += HandleGameStateChanging;
            Global.Instance.gameManager.GameStateChanged += HandleGameStateChanged;
            gameObject.SetActive(false);
        }

        protected void OnDestroy()
        {
            Global.Instance.gameManager.GameStateChanging -= HandleGameStateChanging;
            Global.Instance.gameManager.GameStateChanged -= HandleGameStateChanged;
        }

        private void HandleGameStateChanging(GameStateType obj)
        {
            gameObject.SetActive(true);
            _rotateCoroutine = StartCoroutine(Rotate());
            _backgroundImage.color = new Color(0,0,0,0);
            DOTween.To(() => _backgroundImage.color, (value) => _backgroundImage.color = value, Color.black,0.5f);
        }

        private void HandleGameStateChanged(GameStateType obj)
        {
            StopCoroutine(_rotateCoroutine);
            _rotateCoroutine = null;
            var tweener = DOTween.To(() => _backgroundImage.color, (value) => _backgroundImage.color = value, new Color(0,0,0,0),0.5f);
            tweener.OnComplete(TweenCompleted);
        }

        private void TweenCompleted()
        {
            gameObject.SetActive(false);
        }

        private IEnumerator Rotate()
        {
            while (true)
            {
                _indicatorImage.transform.Rotate(Vector3.forward, -180 * Time.deltaTime, Space.Self);
                yield return null;
            }
        }
    }
}