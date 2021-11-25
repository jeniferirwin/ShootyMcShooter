using System;
using System.Collections.Generic;
using System.Collections;
using Shooty.Core;
using UnityEngine;

namespace Shooty
{
    public class GameOverWaiter : MonoBehaviour
    {
        [SerializeField] private float delay;
        [SerializeField] private GameObject gameOverText;
        [SerializeField] private SceneLoader loader;
        
        private void Start()
        {
            PersistentData.GameOver += GameOver;
        }
        
        private void GameOver(object sender, EventArgs e)
        {
            gameOverText.SetActive(true);
            StartCoroutine(GameOverDelay());
        }
        
        private IEnumerator GameOverDelay()
        {
            yield return new WaitForSeconds(delay);
            loader.LoadScene();
        }
    }
}
