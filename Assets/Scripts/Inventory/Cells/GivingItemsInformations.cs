using UnityEngine;

public class GivingItemsInformations : MonoBehaviour
{
    public void GiveGunInformation()
    {
         PlayerPrefs.SetString("idActiveGun", transform.GetChild(0).GetComponent<Item>().id);
    }
}