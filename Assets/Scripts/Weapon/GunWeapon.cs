using UnityEngine;
public class GunWeapon : Weapon
{
    [SerializeField] private Projecttile projecttilePrefab;

    public override void UseWeapon()
    {
        PlayShootAnimation();

        Projecttile projecttile =  Instantiate(projecttilePrefab);
        projecttile.transform.position = shootPos.position;
        projecttile.Direction = shootPos.right;

        float randomSpread = Random.Range(itemWeapon. MinSpread, itemWeapon. MaxSpread );
        projecttile.transform.rotation =
            Quaternion.Euler(randomSpread * Vector3.forward);
    }
}
