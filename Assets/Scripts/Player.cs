using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float Speed;
    public float JumpPow;

    private bool JumpAll = true;
    private GameManager GameManager;
    private Rigidbody2D Rigidbody2D;
    private RectTransform Joystick;

    private void Awake()
    {
        GameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
        Rigidbody2D = GetComponent<Rigidbody2D>();
        if (GameManager.IsMobile)
        {
            Joystick = GameObject.Find("Handle").GetComponent<RectTransform>();
        }
        else
        {
            GameObject.Find("JoyCanvas").SetActive(false);
        }
    }

    private void FixedUpdate()
    {
        if (GameManager.IsMobile)
        {
            if (Joystick.anchoredPosition.x > 0) Move(1);
            else if (Joystick.anchoredPosition.x < 0) Move(-1);
            else Move(0);
        }
        else
        {
            float x = Input.GetAxisRaw("x");
            Move(x);
        }
    }

    private void Update()
    {
        if (!GameManager.IsMobile)
        {
            float y = Input.GetAxisRaw("y");
            if (y > 0)
            {
                Jump();
            }
        }
    }

    private void Move(float x)
    {
        Rigidbody2D.linearVelocityX = x * Speed;
    }

    private void Jump()
    {
        if (JumpAll)
        {
            JumpAll = false;
            Rigidbody2D.linearVelocityY = JumpPow;
        }
    }

    public void OnJumpButton()
    {
        Jump();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.name == "Floor")
        {
            JumpAll = true;
        }
    }
}
