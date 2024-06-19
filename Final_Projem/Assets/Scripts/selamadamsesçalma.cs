using UnityEngine;

public class CharacterAudio : MonoBehaviour
{
    public Transform cameraTransform; // Kamera transformu
    public float activationDistance = 3f; // Sesin başlayacağı mesafe

    private AudioSource audioSource;
    private bool isPlaying = false;

    void Start()
    {
        // Karakterinizdeki Audio Source bileşenini alın
        audioSource = GetComponent<AudioSource>();

        // Eğer kamera transformu atanmadıysa, varsayılan kamera kullanılacak
        if (cameraTransform == null)
        {
            cameraTransform = Camera.main.transform;
        }
    }

    void Update()
    {
        if (cameraTransform != null)
        {
            // Kameranın karaktere olan uzaklığını alın
            float distance = Vector3.Distance(transform.position, cameraTransform.position);

            // Eğer kamera karaktere yakınsa ve ses çalmıyorsa
            if (distance <= activationDistance && !isPlaying)
            {
                PlayAudio(); // Ses çalma fonksiyonunu çağır
            }
            // Eğer kamera karakterden uzaklaşırsa ve ses çalıyorsa
            else if (distance > activationDistance && isPlaying)
            {
                StopAudio(); // Ses durdurma fonksiyonunu çağır
            }
        }
    }

    // Ses çalma fonksiyonu
    void PlayAudio()
    {
        audioSource.Play();
        isPlaying = true;
    }

    // Ses durdurma fonksiyonu
    void StopAudio()
    {
        audioSource.Stop();
        isPlaying = false;
    }
}
