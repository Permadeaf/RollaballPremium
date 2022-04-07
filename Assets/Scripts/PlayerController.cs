using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float speed = 0;
    public float jumpForce;
    public TextMeshProUGUI countText;
    public GameObject winTextObject;

    private Rigidbody rb;

    public Rigidbody Body { get { return rb; } }

    private int count;
    private float movementX;
    private float movementY;

    [SerializeField]
    JumpCheck jumpCheck;

    [SerializeField]
    bool canJump = true;

    [SerializeField]
    bool canMove = true;

    public bool CanMove
    {
        get
        {
            return canMove;
        }
        set
        {
            canMove = value;
        }
    }

    Vector3 initialPosition;


    bool isBraking = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        initialPosition = transform.position;

        SetCountText();
        winTextObject.SetActive(false);
    }

    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = canMove ? movementValue.Get<Vector2>() : Vector2.zero;

        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    void OnJump(InputValue jumpVal)
    {
        //Debug.LogWarning("Jumped");
        if (canJump && !jumpCheck.IsInAir() && jumpVal.isPressed)
        {
            rb.AddForce(Vector3.up * jumpForce);
        }
    }

    void OnBrake(InputValue brakeValue)
    {
        if (brakeValue.isPressed)
        {
            isBraking = true;
            rb.angularVelocity = Vector3.zero;
        }
        else
        {
            isBraking = false;
        }
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if (count >= 12)
        {
            winTextObject.SetActive(true);
        }

    }
    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);

        rb.AddForce(movement * speed);

        if (isBraking)
        {
            rb.angularVelocity = Vector3.zero;
        }
    }

    public void ResetPosition()
    {
        transform.position = initialPosition;
    }

    public void Stop()
    {
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;

            SetCountText();
        }
    }
}
