using UnityEngine;

public class PersistentAudio : MonoBehaviour
{
    public AudioClip backgroundSound;
    private AudioSource audioSource;

    private static PersistentAudio instance;

    private void Awake()
    {
        if (instance == null)
        {
            // Mantén este objeto vivo entre las escenas
            DontDestroyOnLoad(gameObject);
            instance = this;

            // Configura el componente AudioSource
            audioSource = gameObject.AddComponent<AudioSource>();
            audioSource.clip = backgroundSound;
            audioSource.loop = true; // Repetir el sonido continuamente
            audioSource.playOnAwake = true;
            audioSource.Play();
        }
        else
        {
            // Si ya existe otro objeto PersistentAudio, destruye este
            Destroy(gameObject);
        }
    }
}
