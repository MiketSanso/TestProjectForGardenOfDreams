using UnityEngine;

public class CircleLaunchingEnemyAttack : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<EnemyMove>())
            collision.GetComponent<Enemy>().isAttack = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<EnemyMove>())
        {
            collision.GetComponent<Enemy>().isAttack = false;
            collision.GetComponent<Enemy>().stopAndPush = false;
        }
    }
}
