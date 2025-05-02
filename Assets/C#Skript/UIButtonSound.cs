using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class UIButtonSound : MonoBehaviour
{
    public AudioClip clickSound;
    private AudioSource audioSource;

    void Start()
    {
       
        audioSource = FindObjectOfType<AudioSource>();
        if (audioSource == null)
        {
            GameObject audioObj = new GameObject("UI Audio");
            audioSource = audioObj.AddComponent<AudioSource>();
            DontDestroyOnLoad(audioObj);
        }

        GetComponent<Button>().onClick.AddListener(PlayClick);
    }

    void PlayClick()
    {
        if (clickSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(clickSound);
        }
    }
}
