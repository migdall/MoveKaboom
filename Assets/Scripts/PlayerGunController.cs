using UnityEngine;

public class PlayerGunController : MonoBehaviour
{
    // This component is for controlling how the player shoots their gun in the world

    [SerializeField]
    private GameObject bulletPrefab;
    [SerializeField]
    private Transform gunPositionTransform;

    private void FireBullet()
    {
        if (bulletPrefab != null)
        {
            // Instantiate the bullet from the bullet prefab

            // Shoot bullet prefab from gun position transform
        }
    }

    private void OnSpaceBar()
    {
        // Find out when the player taps the spacebar button
    }
}
