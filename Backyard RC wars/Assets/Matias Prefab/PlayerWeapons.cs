using UnityEngine;

public class PlayerWeapons : MonoBehaviour
{
    [Header("Weapons")]
    public GameObject potatoCannon;
    public GameObject drill;
    public GameObject stapleGun;
    public GameObject waterMortar;

    private void Awake()
    {
        DisableAllWeapons();
    }

    public void DisableAllWeapons()
    {
        potatoCannon.SetActive(false);
        drill.SetActive(false);
        stapleGun.SetActive(false);
        waterMortar.SetActive(false);
    }

    public void EnableWeapon(WeaponType weaponType)
    {
        switch (weaponType)
        {
            case WeaponType.PotatoCannon:
                potatoCannon.SetActive(true);
                break;

            case WeaponType.Drill:
                drill.SetActive(true);
                break;

            case WeaponType.StapleGun:
                stapleGun.SetActive(true);
                break;

            case WeaponType.WaterMortar:
                waterMortar.SetActive(true);
                break;
        }
    }
}