using UnityEngine;
using UnityEngine.UI;
using Shooty.Core;

namespace Shooty.UI
{
    public class VolumeSlider : MonoBehaviour
    {
        [SerializeField] private VolumeType type;
        [SerializeField] private Slider slider;
        [SerializeField] private AudioSource source;
        [SerializeField] private string sourceName;

        public void SetSourceVolume()
        {
            if (type == VolumeType.Music)
            {
                VolumeController.SetMusicVolume(slider.value);
            }
            else if (type == VolumeType.SFX)
            {
                VolumeController.SetSFXVolume(slider.value);
            }
        }

        private void Start()
        {
            if (source == null)
            {
                source = GameObject.Find(sourceName).GetComponent<AudioSource>();
                if (source == null)
                {
                    Debug.LogError($"The audio source {sourceName} can't be found!");
                }
            }
            SetInitialVolume();
        }

        private void SetInitialVolume()
        {
            if (source == null)
            {
                slider.value = 0.1f;
                return;
            }
            float curVolume = source.volume;
            slider.SetValueWithoutNotify(curVolume);
        }
    }
}
