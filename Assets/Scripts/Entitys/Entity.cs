using UnityEngine;

public abstract class Entity : MonoBehaviour, IDamageable
{
    [SerializeField] private float _health, _maxHealth;

    public float health
    {
        get { return _health; }
        protected set { _health = value; }
    }

    public float maxHealth
    {
        get { return _maxHealth; }
        protected set { _maxHealth = value; }
    }

    public virtual void Damage(float damage)
    {
        if (_health - damage > 0)
            _health -= damage;
        else
        {
            _health = 0;
            DestroyObject();
        }
    }

    protected abstract void DestroyObject();
}