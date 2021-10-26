using UnityEngine;

public class DestructableStatue : MonoBehaviour
{
    public GameObject Broken;
    public float BrokenDespawnTime = 3;
    public WeaponController SpecificWeapon;

    void OnMouseDown()
    {
        WeaponController playerWeapon = FindObjectOfType<PlayerWeaponsManager>().GetActiveWeapon();
        if (!SpecificWeapon || SpecificWeapon.weaponName == playerWeapon.weaponName) {
            GameObject BrokenInScene = (GameObject)Instantiate(Broken,transform.position,transform.rotation);
            Destroy(gameObject);
            Destroy(BrokenInScene,BrokenDespawnTime);
        }
    }
}
