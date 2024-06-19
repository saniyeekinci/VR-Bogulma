using UnityEngine;

public class RotateAndMoveObject : MonoBehaviour
{
    public enum MovementType { RotateOnly, RotateAndMove }
    public MovementType movementType;

    public float rotationSpeed = 100f; // Dönme hızını buradan ayarlayabilirsiniz.
    public float moveSpeed = 2.0f; // Hareket hızını buradan ayarlayabilirsiniz.
    public float moveRange = 2.0f; // Hareket mesafesini buradan ayarlayabilirsiniz.

    private float startPositionY;

    void Start()
    {
        startPositionY = transform.position.y;
    }

    void Update()
    {
        // Objeyi döndür
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);

        if (movementType == MovementType.RotateAndMove)
        {
            // Objeyi yukarı aşağı hareket ettir
            float newYPosition = startPositionY + Mathf.Sin(Time.time * moveSpeed) * moveRange;
            transform.position = new Vector3(transform.position.x, newYPosition, transform.position.z);
        }
    }
}
