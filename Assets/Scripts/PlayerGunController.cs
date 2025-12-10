using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerGunController : MonoBehaviour
{
    // This component is for controlling how the player shoots their gun in the world

    [SerializeField]
    private GameObject bulletPrefab;
    [SerializeField]
    private Transform gunPositionTransform;

    public float bulletSpeed = 10.0f;


    private void Update()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            FireBullet();
        }
    }

    private void FireBullet()
    {
        if (bulletPrefab != null)
        {
            // Instantiate the bullet from the bullet prefab
            GameObject bullet = Instantiate(bulletPrefab, gunPositionTransform.position, gunPositionTransform.rotation);
            // Shoot bullet prefab from gun position transform
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.linearVelocity = gunPositionTransform.up * bulletSpeed; 
            }
        }
    }
}
