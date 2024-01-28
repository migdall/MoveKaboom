using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingJewel : MonoBehaviour
{
    [SerializeField]
    private float fallingSpeed = 2.0f;
    [SerializeField]
    private float endZ = -10.0f;
    [SerializeField]
    private Vector2 startLocation = Vector2.zero;

    // Update is called once per frame
    void Update()
    {
        MoveJewel();
        CheckRespawn();
    }

    private void MoveJewel()
    {
        transform.position = new Vector2(transform.position.x, transform.position.y - (fallingSpeed * Time.deltaTime));
    }

    private void CheckRespawn()
    {
        if (transform.position.y < endZ)
        {
            transform.position = startLocation;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null && collision.gameObject.CompareTag("Player"))
        {
            GameManager.Instance.AddPoint();
        }
    }
}
