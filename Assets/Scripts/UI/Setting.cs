using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Setting : MonoBehaviour
{
    [SerializeField]
    private Slider musicVolumeBar, effectVolumeBar;
    [SerializeField]
    private VolumeController controller;

    private void OnEnable()
    {
        musicVolumeBar.value = controller.musicVolume;
        effectVolumeBar.value = controller.effectVolume;
    }
}
