using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class CubeTrigger : MonoBehaviour
{
    public GameObject videoPanel; // Video panelinizin referansı
    public VideoPlayer videoPlayer; // Video player bileşeninin referansı
    public float triggerDistance = 6f; // Kamera ile küp arasındaki mesafe

    void Update()
    {
        // Kameranın pozisyonunu alın
        Vector3 cameraPosition = Camera.main.transform.position;

        // Kameranın küp ile arasındaki mesafeyi hesaplayın
        float distance = Vector3.Distance(cameraPosition, transform.position);

        // Belirli bir mesafenin altında ise videoyu oynatın
        if (distance < triggerDistance)
        {
            videoPanel.SetActive(true); // Paneli aktif hale getir
            videoPlayer.Play(); // Videoyu oynat
        }
        else
        {
            videoPanel.SetActive(false); // Paneli deaktif hale getir
            videoPlayer.Stop(); // Videoyu durdur
        }
    }
}