using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace ST.SceneManagement
{
    public class SceneLoader : MonoBehaviour
    {
        [SerializeField] float splashScreenDelay = 2.0f;
        [SerializeField] [Range(0, 2)] float fadeDelay = 0.5f;
        [SerializeField] [Range(0, 2)] float fadedDelayTime = 0.5f;
        int buildIndex = 0;

        Round roundToLoad;

        IEnumerator Start()
        {
            buildIndex  = SceneManager.GetActiveScene().buildIndex;
            if (buildIndex == 0)
            {
                yield return StartCoroutine(SplashScreenLoad());
            }            
        }

        IEnumerator SplashScreenLoad()
        {
            yield return new WaitForSeconds(splashScreenDelay);
            SceneManager.LoadScene(1);
        }

        public IEnumerator LoadRound(Round round)
        {
            print("Attempt to Load Round");

            SetRoundToLoad(round);

            DontDestroyOnLoad(gameObject);

            Fader fader = FindObjectOfType<Fader>();

            // Fade out
            yield return StartCoroutine(fader.FadeOut(fadeDelay));
            
            // Load Next Scene
            yield return SceneManager.LoadSceneAsync(2);
            yield return new WaitForSeconds(fadedDelayTime);
            yield return StartCoroutine(fader.FadeIn(fadeDelay));

            // Pass the round to the "Game" object.

            // Note. I feel like this could be buggy if a lot of data is loaded at once.
            // Possibly add a bv to wait and see if the SetRoundToLoad method had been called yet and wait on that.
            Destroy(gameObject); 
      

        }

        private void SetRoundToLoad(Round round)
        {
            roundToLoad = round;
        }


        public Round GetRoundToLoad()
        {
            return roundToLoad;
        }
    }
}

