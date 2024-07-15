using UnityEngine;

public abstract class Weapon : Item
{
    [SerializeField] private float _damage;
    public float damage
    {
        get { return _damage; }
        protected set { _damage = value; }
    }

    public abstract void Hit();
}
