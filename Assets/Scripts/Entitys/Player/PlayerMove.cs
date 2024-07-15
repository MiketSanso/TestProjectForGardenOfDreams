using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private float dirX, dirY;
    [SerializeField] private float speed;

    [SerializeField] private Joystick joystick;
    [SerializeField] private Rigidbody2D rb;

    private void Update()
    {
        dirX = joystick.Horizontal * speed;
        dirY = joystick.Vertical * speed;
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector3(dirX, dirY);
    }
}
