﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ST.SceneManagement
{
    public class Fader : MonoBehaviour
    {
        CanvasGroup canvasGroup;
        //Image image;

        private void Start()
        {
            canvasGroup = GetComponent<CanvasGroup>();
            //image = GetComponent<Image>()
        }


        public void FadeOutImmediate()
        {
            canvasGroup.alpha = 1;
        }

        public IEnumerator FadeOut(float time)
        {
            while (canvasGroup.alpha < 1)
            {
                // moving alpha toward 1
                canvasGroup.alpha += Time.deltaTime / time;
                yield return null; // wait one frame;
            }
        }

        public IEnumerator FadeIn(float time)
        {
            while (canvasGroup.alpha > 0)
            {
                // moving alpha toward 1
                canvasGroup.alpha -= Time.deltaTime / time;
                yield return null; // wait one frame;
            }
        }
    }
}
