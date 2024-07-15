using UnityEngine;

public class HPBarSettings : MonoBehaviour
{
    [SerializeField] private Entity entity;

    void Update()
    {
        if (entity.health / entity.maxHealth != transform.localScale.x)
            transform.localScale = new Vector3(entity.health / entity.maxHealth, 1, 1);
    }
}
