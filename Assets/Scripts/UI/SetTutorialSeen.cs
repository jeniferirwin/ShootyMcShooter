using Shooty.Core;
using UnityEngine;
using Shooty.UI;

namespace Shooty
{
    public class SetTutorialSeen : MonoBehaviour
    {
        [SerializeField] private GameObject instructions;
        [SerializeField] private SceneLoader loader;

        private void Awake()
        {
            if (!PersistentData.HasPlayedBefore)
            {
                instructions.SetActive(true);
                PersistentData.SetTutorialSeen();
                UserPrefs.SavePrefs();
            }
            else
            {
                loader.LoadScene();
            }
        }
    }
}