using UnityEngine;

public class ButtonShoot : MonoBehaviour
{
    [SerializeField] private Weapon weapon;

    public void Shoot()
    {
        weapon.Hit();
    }


#warning ����� ���
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            weapon.Hit();
        }
    }
}
