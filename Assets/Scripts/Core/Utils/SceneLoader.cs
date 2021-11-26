using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Shooty.Core
{
    public class SceneLoader : MonoBehaviour
    {
        [SerializeField] private bool immediate;
        [SerializeField] private Scenes scene;

        private void Start()
        {
            if (!immediate) return;
            StartCoroutine(FrameWait());
        }
        
        public void LoadScene()
        {
            SceneManager.LoadScene(scene.ToString().Replace(" ", ""));
        }
        
        private IEnumerator FrameWait()
        {
            yield return new WaitForEndOfFrame();
            LoadScene();
        }
    }
}
