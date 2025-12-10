using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float maxY = 7.0f;

    void Update()
    {
        if (transform.position.y > maxY)
        {
            Destroy(gameObject);
        }
    }
}
