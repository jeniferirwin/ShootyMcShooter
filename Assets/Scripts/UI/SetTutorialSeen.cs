using Shooty.Core;
using UnityEngine;

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
            }
            else
            {
                loader.LoadScene();
            }
        }
    }
}