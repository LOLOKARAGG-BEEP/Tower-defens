using UnityEngine;
using UnityEngine.UI;

public class VolumeControl : MonoBehaviour
{
    public Slider menuMusicSlider;   
    public Slider battleMusicSlider; 
    public AudioSource menuMusicSource;
    public AudioSource battleMusicSource;

    void Start()
    {
        
        menuMusicSlider.onValueChanged.AddListener(ChangeMenuMusicVolume);
        battleMusicSlider.onValueChanged.AddListener(ChangeBattleMusicVolume);
       
        menuMusicSource.volume = menuMusicSlider.value;
        battleMusicSource.volume = battleMusicSlider.value;
    }

    public void ChangeMenuMusicVolume(float value)
    {
        menuMusicSource.volume = value;
    }

    public void ChangeBattleMusicVolume(float value)
    {
        battleMusicSource.volume = value;
    }
}
