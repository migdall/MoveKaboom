using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingJewel : MonoBehaviour
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
    [SerializeField]
    private float cooldownTimer = 3.0f;

    private float remainingCooldownTime;
    private float minimumCooldownTime;

    private bool inUse = false;
    private bool cooldownTimerOn = false;

    private const string playerTagString = "Player";

    private SpriteRenderer spriteRendererObject;
    private BoxCollider2D spriteBoxCollider;

    private void Awake()
    {
        spriteRendererObject = GetComponent<SpriteRenderer>();
        spriteBoxCollider = GetComponent<BoxCollider2D>();
        remainingCooldownTime = cooldownTimer;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.GetGameOver())
        {
            return;
        }
        MoveJewel();
        CheckRespawn();

        if (cooldownTimerOn)
        {
            remainingCooldownTime -= Time.deltaTime;
            if (remainingCooldownTime < minimumCooldownTime)
            {
                StopCooldownTimer();
            }
        }
    }

    private void MoveJewel()
    {
        transform.position = new Vector2(transform.position.x, transform.position.y - (fallingSpeed * Time.deltaTime));
    }

    private void CheckRespawn()
    {
        if (transform.position.y < endZ)
        {
            // Respawn at a random X
            float newX = Random.Range(horizontalRangeMin, horizontalRangeMax);
            transform.position = new Vector2(newX, startLocation.y);
        }

        Respawn();
    }

    private void ResetTransformPositionY()
    {
        transform.position = new Vector2(transform.position.x, startLocation.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null && collision.gameObject.CompareTag(playerTagString))
        {
            GameManager.Instance.AddPoint();
            spriteRendererObject.enabled = false;
            spriteBoxCollider.enabled = false;
            SetInUse(false);
            StartCooldownTimer();
        }
    }

    private void ResetCooldownTimer()
    {
        remainingCooldownTime = cooldownTimer;
        cooldownTimerOn = true;
    }

    private void StartCooldownTimer()
    {
        ResetCooldownTimer();
        cooldownTimerOn = true;
    }

    private void StopCooldownTimer()
    {
        cooldownTimerOn = false;
    }

    private void Respawn()
    {
        if (this.inUse && spriteRendererObject.enabled == false && spriteBoxCollider.enabled == false)
        {
            ResetTransformPositionY();
            spriteRendererObject.enabled = true;
            spriteBoxCollider.enabled = true;
        }
    }

    public void SetFallingSpeed(float speed)
    {
        this.fallingSpeed = speed;
    }

    public bool GetInUse()
    {
        return inUse;
    }

    public void SetInUse(bool value)
    {
        if (cooldownTimerOn)
        {
            this.inUse = false;
        }
        else
        {
            this.inUse = value;
        }
    }
}
