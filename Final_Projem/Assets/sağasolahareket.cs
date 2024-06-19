using UnityEngine;

public class MoveObject : MonoBehaviour
{
    public enum MovementDirection { Horizontal, Vertical }
    public MovementDirection movementDirection;

    public float speed = 2.0f;
    public float range = 2.0f;
    public Light pointLight;
    public Color lightColor = Color.red;
    public float lightIntensity = 1.0f;

    private float startPositionX;
    private float startPositionY;

    void Start()
    {
        startPositionX = transform.position.x;
        startPositionY = transform.position.y;

        // Işık kaynağının rengini ve parlaklığını ayarla
        if (pointLight != null)
        {
            pointLight.color = lightColor;
            pointLight.intensity = lightIntensity;
        }
    }

    void Update()
    {
        float newPositionX = startPositionX;
        float newPositionY = startPositionY;

        if (movementDirection == MovementDirection.Horizontal)
        {
            newPositionX = startPositionX + Mathf.Sin(Time.time * speed) * range;
        }
        else if (movementDirection == MovementDirection.Vertical)
        {
            newPositionY = startPositionY + Mathf.Sin(Time.time * speed) * range;
        }

        transform.position = new Vector3(newPositionX, newPositionY, transform.position.z);

        // Işığın pozisyonunu güncelle
        if (pointLight != null)
        {
            pointLight.transform.position = transform.position;
        }
    }
}
