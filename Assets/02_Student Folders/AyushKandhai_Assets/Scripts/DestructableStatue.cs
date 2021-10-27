using UnityEngine;

public class DestructableStatue : MonoBehaviour
{
    public GameObject Broken;
    public AudioClip Break;
    public float BrokenDespawnTime = 3;
    public WeaponController SpecificWeapon;

    void OnMouseDown()
    {
        WeaponController playerWeapon = FindObjectOfType<PlayerWeaponsManager>().GetActiveWeapon();
        if (!SpecificWeapon || SpecificWeapon.weaponName == playerWeapon.weaponName) {
            GameObject BrokenInScene = (GameObject)Instantiate(Broken,transform.position,transform.rotation);
            AudioSource Source = BrokenInScene.AddComponent<AudioSource>();
            Source.volume = 0.5f;
            Source.PlayOneShot(Break);
            Destroy(gameObject);
            Destroy(BrokenInScene,BrokenDespawnTime);
        }
    }
}
