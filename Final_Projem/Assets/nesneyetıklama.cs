using UnityEngine;

public class PlaySoundOnDistance : MonoBehaviour
{
    public Transform cameraTransform; // Reference to the camera's transform
    public float triggerDistance = 5f; // Distance at which the sound should play
    private AudioSource audioSource;
    private bool soundPlayed = false;

    void Start()
    {
        // Get the AudioSource component attached to the character
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        // Calculate the distance between the camera and the character
        float distance = Vector3.Distance(cameraTransform.position, transform.position);

        // Check if the distance is less than the trigger distance and the sound hasn't been played yet
        if (distance < triggerDistance && !soundPlayed)
        {
            // Play the audio source
            audioSource.Play();
            soundPlayed = true;
        }
        // Reset the soundPlayed flag and stop the audio if the camera moves away again
        else if (distance >= triggerDistance && soundPlayed)
        {
            audioSource.Stop();
            soundPlayed = false;
        }
    }
}
