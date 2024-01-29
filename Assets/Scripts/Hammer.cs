using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hammer : MonoBehaviour
{
    [SerializeField]
    private float fallingSpeed = 2.0f;
    [SerializeField]
    private float horizontalRangeMin = -9f;
    [SerializeField]
    private float horizontalRangeMax = 9f;
    [SerializeField]
    private float endZ = -10.0f;
    [SerializeField]
    private Vector2 startLocation = Vector2.zero;

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.GetGameOver())
        {
            return;
        }
        MoveJewel();
        CheckRespawn();
    }

    private void MoveJewel()
    {
        transform.position = new Vector2(transform.position.x, transform.position.y - (fallingSpeed * Time.deltaTime));
        // Update X in a random berserker kind of way
    }

    private void CheckRespawn()
    {
        if (transform.position.y < endZ)
        {
            // Respawn at a random X
            float newX = Random.Range(horizontalRangeMin, horizontalRangeMax);
            transform.position = new Vector2(newX, startLocation.y);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null && collision.gameObject.CompareTag("Player"))
        {
            // GameManager.Instance.RemovePoint();
            // Debug.Log("KABOOM");
            // Reset player points to zero
            GameManager.Instance.GetKaboomed();
        }
    }
}
