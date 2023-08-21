using System;
using System.Collections;
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
                var tempPercentage = Mathf.InverseLerp(0, loadingTime, tempTime);
                loadingText.SetText($"%{(tempPercentage * 100).ToString("F0")}");
                loadingImg.fillAmount = tempPercentage;
                yield return null;
            }
        }
    }
}