using UnityEngine;
using TMPro;
using System.Collections;
using Zenject;

public class Gun : Weapon
{
    [SerializeField] private GameObject bulletObject;
    [SerializeField] private Transform ponintShoot;

    [SerializeField] private int constantAmmo, variableAmmo;
    [SerializeField] private float timeRecharge;
    [SerializeField] private Vector2 speedBullet;
    [SerializeField] private float timeShootOneBulletInSecond;

    [SerializeField] private string idTypeBullet;

    private SearchSuitableCell _searchSuitableCell;
    private bool isReloading = false;
    private TMP_Text _reloadingText;

    [Inject]
    public void Construct(TMP_Text reloadingText, SearchSuitableCell searchFreeCell)
    {
        _reloadingText = reloadingText;
        _searchSuitableCell = searchFreeCell;
    }

    void OnEnable()
    {
        PlayerPrefs.SetInt("activeGunConstantAmmo", constantAmmo);
        PlayerPrefs.SetInt("activeGunVariableAmmo", variableAmmo);
        PlayerPrefs.Save();
    }

    public override void Hit()
    {
        StartCoroutine(Shoot());
    }

    public IEnumerator Shoot()
    {
        if (variableAmmo > 0 && !isReloading)
        {
            variableAmmo -= 1;

            GameObject bullet = Instantiate(bulletObject, ponintShoot.position, transform.rotation);
            bullet.GetComponent<Bullet>().gun = gameObject;

            PlayerPrefs.SetInt("activeGunVariableAmmo", variableAmmo);
            PlayerPrefs.Save();
        }
        else  if (!isReloading && variableAmmo < constantAmmo)
        {
            isReloading = true;
            StartCoroutine(Recharge());
        }

        yield return new WaitForSeconds(timeShootOneBulletInSecond);
        yield return null;
    }

    public IEnumerator Recharge()
    {
        ItemConsumables bulletInventoryItem = _searchSuitableCell.SearchMainCellInInventory(idTypeBullet) != null ? _searchSuitableCell.SearchMainCellInInventory(idTypeBullet).transform.GetChild(0).GetComponent<ItemConsumables>() : null;

        Debug.Log(bulletInventoryItem);

        if (bulletInventoryItem != null)
        {
            _reloadingText.enabled = true;

            yield return new WaitForSeconds(timeRecharge / 2);

            if (bulletInventoryItem.countItemsInObject > constantAmmo - variableAmmo)
            {
                bulletInventoryItem.countItemsInObject = bulletInventoryItem.countItemsInObject - (constantAmmo - variableAmmo);
                variableAmmo = constantAmmo;
            }
            else
            {
                variableAmmo = variableAmmo + bulletInventoryItem.countItemsInObject;
                bulletInventoryItem.countItemsInObject = 0;
            }

            PlayerPrefs.SetInt("activeGunVariableAmmo", variableAmmo);
            PlayerPrefs.Save();

            yield return new WaitForSeconds(timeRecharge / 2);
            _reloadingText.enabled = false;
        }

        isReloading = false;
        yield return null;
    }
}
