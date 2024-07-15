using UnityEngine;

public class ButtonShoot : MonoBehaviour
{
    [SerializeField] private Weapon weapon;

    public void Shoot()
    {
        weapon.Hit();
    }


#warning ÓÄÀËÈ ıòî
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            weapon.Hit();
        }
    }
}
