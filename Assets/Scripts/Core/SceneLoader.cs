using UnityEngine;
using UnityEngine.SceneManagement;

namespace Shooty.Core
{
    public class SceneLoader : MonoBehaviour
    {
        private enum Scenes
        {
            InitializeAudio,
            InitializePersistentData,
            Volume,
            Title,
            Credits,
            HighScores,
            Main,
            GameChoices,
            Instructions
        }

        [SerializeField] private bool immediate;
        [SerializeField] private Scenes scene;

        private void Start()
        {
            if (!immediate) return;
            LoadScene();
        }
        
        public void LoadScene()
        {
            SceneManager.LoadScene(scene.ToString().Replace(" ", ""));
        }
    }
}
