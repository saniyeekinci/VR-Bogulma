using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class VRButtonController : MonoBehaviour
{
    public GameObject character; // Karakter GameObject'i (Görünür olacak olan asset)
    public XRBaseInteractable vrButton; // VR butonunuz (XR Interactable olarak)
    private AudioSource characterAudio; // Karakterin ses bileşeni

    private bool isCharacterVisible = false; // Karakterin görünürlüğü durumu

    private void Start()
    {
        // Karakterin ses bileşenini al
        characterAudio = character.GetComponent<AudioSource>();

        // Karakteri başlangıçta gizli yap
        if (character != null)
        {
            character.SetActive(false);
        }

        // Buton tıklama olayını dinle
        if (vrButton != null)
        {
            vrButton.onSelectEntered.AddListener(OnButtonClicked);
        }
    }

    private void OnDestroy()
    {
        // Buton tıklama olayını kaldır
        if (vrButton != null)
        {
            vrButton.onSelectEntered.RemoveListener(OnButtonClicked);
        }
    }

    private void OnButtonClicked(XRBaseInteractor interactor)
    {
        // Karakterin görünürlüğünü değiştir
        isCharacterVisible = !isCharacterVisible;

        // Karakteri görünür yap veya gizle
        if (character != null)
        {
            character.SetActive(isCharacterVisible);

            // Karakter görünür hale geldiğinde sesi çal
            if (isCharacterVisible && characterAudio != null)
            {
                characterAudio.Play();
            }
        }
    }
}
