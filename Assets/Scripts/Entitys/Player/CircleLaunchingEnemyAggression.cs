using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class CircleLaunchingEnemyAggression : MonoBehaviour
{
    [SerializeField] private Player player;
    [HideInInspector] public List<Enemy> enemyInCircle;

    private List<float> distance = new List<float>();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Enemy>())
        {
            collision.GetComponent<EnemyAttack>().player = player;
            collision.GetComponent<EnemyMove>().player = player;
            collision.GetComponent<Enemy>().isAgressive = true;

            enemyInCircle.Add(collision.GetComponent<Enemy>());
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (distance.Count < enemyInCircle.Count || distance.Count > enemyInCircle.Count)
        {
            distance.Clear();

            for (int i = 0; i < enemyInCircle.Count; i++)
                distance.Add(Vector3.Distance(enemyInCircle[i].transform.position, transform.position));
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<Enemy>())
            enemyInCircle.Remove(collision.GetComponent<Enemy>());
    }

    public Enemy SearchEnemyWithMinDistanceToPlayer()
    {
        for (int i = 0; i < distance.Count; i++)
        {
            if (distance.Min() == distance[i] && enemyInCircle[i] != null)
                return enemyInCircle[i];
            else if (enemyInCircle[i] == null)
                enemyInCircle.RemoveAt(i);
        }
        return null;
    }
}
