using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ST.SceneManagement
{
    public class RoundLauncher : MonoBehaviour
    {
        [SerializeField] Round round;


        public void ButtonPressed()
        {
            LoadRound();
        }

    
        public void LoadRound()
        {
            StartCoroutine(FindObjectOfType<SceneLoader>().LoadRound(round));
        }

    }
}

