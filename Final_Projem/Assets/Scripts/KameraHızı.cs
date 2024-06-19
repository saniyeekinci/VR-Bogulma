using UnityEngine;

public class CameraSpeedController : MonoBehaviour
{
    public float speed = 5f; // Hareket hızı

    void Update()
    {
        // Klavye girişine bağlı olarak kamerayı hareket ettir
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        float upDownInput = 0f;

        // Yukarı ve aşağı hareket için tuşları kontrol et
        if (Input.GetKey(KeyCode.E)) // Yukarı hareket
        {
            upDownInput = 1f;
        }
        else if (Input.GetKey(KeyCode.Q)) // Aşağı hareket
        {
            upDownInput = -1f;
        }

        Vector3 moveDirection = new Vector3(horizontalInput, upDownInput, verticalInput);
        transform.Translate(moveDirection * speed * Time.deltaTime);
    }
}
