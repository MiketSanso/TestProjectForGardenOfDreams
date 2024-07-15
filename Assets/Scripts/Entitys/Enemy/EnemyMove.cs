using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    [SerializeField] private int speed = 5;

    private Rigidbody2D rb;
    private Vector2 movement;

    [SerializeField] private Enemy enemy;
    [HideInInspector] public Entity player;

    private void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (enemy.isAgressive)
        {
            Vector3 direction = player.transform.position - transform.position;
            direction.Normalize();
            movement = direction;
        }
    }

    private void FixedUpdate()
    {
        if (enemy.isAgressive && !enemy.isAttack && player.health > 0)
            MoveChar(movement);
    }

    private void MoveChar(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * speed * Time.deltaTime));
    }
}
