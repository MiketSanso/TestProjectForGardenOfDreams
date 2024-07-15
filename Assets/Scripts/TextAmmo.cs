using UnityEngine;

public class TextAmmo : MonoBehaviour
{
    [SerializeField] private TMPro.TMP_Text textAmmo;

    void Update()
    {
        textAmmo.text = PlayerPrefs.GetInt("activeGunVariableAmmo").ToString() + "/" + PlayerPrefs.GetInt("activeGunConstantAmmo").ToString();
    }
}
