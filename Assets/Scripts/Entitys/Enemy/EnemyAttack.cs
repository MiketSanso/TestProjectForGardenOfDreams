using System.Collections;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private Enemy enemy;
    [HideInInspector] public Entity player;

    private void FixedUpdate()
    {
        if (enemy.isAttack && enemy.stopAndPush && player.health > 0)
        {
            enemy.stopAndPush = false;
            enemy.isAgressive = false;
            StartCoroutine(Attacking());
        }
    }

    private IEnumerator Attacking()
    {
        yield return new WaitForSeconds(0.2f);

        player.Damage(GetComponent<Enemy>().damageEnemy);
        yield return new WaitForSeconds(0.6f);

        enemy.stopAndPush = true;
        enemy.isAgressive = true;
        yield return null;
    }
}
