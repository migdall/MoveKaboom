using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovementController : MonoBehaviour
{
    [SerializeField]
    private float speed =3;
    [SerializeField]
    private GameObject Body;

    private Vector2 moveAmount;

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.GetGameOver())
        {
            return;
        }
        MovePlayer();
    }

    private void MovePlayer()
    {
        // Move the player left and right
        transform.position = new Vector2(transform.position.x + moveAmount.x * speed * Time.deltaTime, transform.position.y);
    }

    public void KaboomSpinUpAnimation()
    {
        Vector2 up = new Vector2 (transform.position.x, transform.position.y + 3);
        Body.transform.Translate(up);
        // Spin the Body transform
        transform.Rotate(0f, 0f, 270f);
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        // read the value for the "move" action each event call
        moveAmount = context.ReadValue<Vector2>();
    }
}
