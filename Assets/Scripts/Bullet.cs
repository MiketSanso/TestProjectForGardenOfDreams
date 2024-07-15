using UnityEngine;
using UnityEngine.Tilemaps;

public class Bullet : MonoBehaviour
{
    private Vector2 vectorRotationBullet;
    [HideInInspector] public GameObject gun;
    public float timeDestroy;
    public float speed;
    public Rigidbody2D rb;

    private void Start()
    {
        vectorRotationBullet = gun.GetComponent<RotationSettings>().vectorRotation;
        rb = GetComponent<Rigidbody2D>();
        Destroy(this.gameObject, timeDestroy);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Collider2D>())
            Destroy(this.gameObject);

        if (collision.gameObject.GetComponent<TilemapCollider2D>())
            Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Collider2D>() && collision.gameObject.GetComponent<Enemy>())
        {
            collision.gameObject.GetComponent<Enemy>().Damage(gun.GetComponent<Gun>().damage);
            Destroy(this.gameObject);
        }
    }

    private void Update()
    {
        transform.Translate(vectorRotationBullet * speed);
    }
}
