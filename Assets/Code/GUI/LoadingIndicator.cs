using UnityEngine;
using TAMKShooter.Systems;
using System.Collections;
using UnityEngine.UI;
using DG.Tweening;
using System.Collections.Generic;

namespace TAMKShooter.GUI
{
    public class LoadingIndicator : MonoBehaviour
    {
        [SerializeField]
        private Image _indicatorImage;
        [SerializeField]
        private Image _backgroundImage;

        private Coroutine _rotateCoroutine;
        private Color _indicatorImageColor;
        private List<Tweener> _tweeners = new List<Tweener>();

        protected void Awake()
        {
            Global.Instance.gameManager.GameStateChanging += HandleGameStateChanging;
            Global.Instance.gameManager.GameStateChanged += HandleGameStateChanged;
            gameObject.SetActive(false);
            _indicatorImageColor = _indicatorImage.color;
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
            var transparent = new Color(0, 0, 0, 0);

            _backgroundImage.color = transparent;
            _indicatorImage.color = transparent;

            DOTween.To(() => _backgroundImage.color, (value) => _backgroundImage.color = value, Color.black,0.5f);
            DOTween.To(() => _indicatorImage.color, (value) => _indicatorImage.color = value, _indicatorImageColor,0.5f);
        }

        private void HandleGameStateChanged(GameStateType obj)
        {
            StopCoroutine(_rotateCoroutine);
            _rotateCoroutine = null;

            _tweeners.Add(DOTween.To(() => _backgroundImage.color, (value) => _backgroundImage.color = value, Color.clear,0.5f).OnComplete(TweenCompleted));
            _tweeners.Add(DOTween.To(() => _indicatorImage.color, (value) => _indicatorImage.color = value,Color.clear,0.5f));

        }
        private void TweenCompleted()
        {
            foreach (var tweener in _tweeners)
            {
                if (tweener.IsPlaying())
                    tweener.Kill();
            }
            _tweeners.Clear();
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