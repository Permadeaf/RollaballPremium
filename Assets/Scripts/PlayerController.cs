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

    Vector3 initialPosition;

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
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    void OnJump(InputValue jumpVal)
    {
        //Debug.LogWarning("Jumped");
        if (!jumpCheck.IsInAir() && jumpVal.isPressed)
        {
            rb.AddForce(Vector3.up * jumpForce);
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
    }

    public void ResetPosition()
    {
        transform.position = initialPosition;
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
