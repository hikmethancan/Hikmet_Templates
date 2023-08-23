using DG.Tweening;
using System;
using System.Collections;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace HikmetTemplate.Scripts
{
    public class SplashLoader : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private Image loadingImg;
        [SerializeField] private TMP_Text loadingText;
        [SerializeField] private GameObject splash;

        [Header("Values")]
        [SerializeField] private int loadingTime;
        [SerializeField] private AnimationCurve loadingCurve;

        private const string SplashPlayedKey = "SplashPlayed";


        private void Start()
        {
            splash.SetActive(false);
            bool isSplashPlayed = PlayerPrefs.GetInt(SplashPlayedKey, 0) == 1;
            if (!isSplashPlayed)
            {
                splash.SetActive(true);
                StartCoroutine(Loader());
                PlayerPrefs.SetInt(SplashPlayedKey, 1); // Set the value to 1 (true)
            }
        }

        private IEnumerator Loader()
        {
            float tempTime = 0f;
            while (tempTime < loadingTime)
            {
                tempTime += Time.deltaTime;
                var curveTime = Mathf.InverseLerp(0, loadingTime, tempTime);
                var tempLoadingValue = loadingCurve.Evaluate(curveTime);
                string tempPercentage = (tempLoadingValue * 100).ToString("F0");

                loadingText.SetText($"%{tempPercentage}");
                loadingImg.fillAmount = tempLoadingValue;
                yield return null;
            }
            splash.transform.DOScale(Vector3.zero, .4f).OnComplete(() =>
            {
                splash.transform.localScale = Vector3.zero;
                splash.SetActive(false);
            });
        }
    }
}