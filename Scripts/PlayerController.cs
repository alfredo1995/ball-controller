using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float speed = 0.0f;
    public TextMeshProUGUI countText;
    public GameObject winTextObject;

    private Rigidbody rb;
    private int count;

    private float movementX;
    private float movementY;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        winTextObject.SetActive(false); 
    }

    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    void SetCountText()
    {
        countText.text = "Count " + count.ToString();
        if(count >= 8)
        {
            winTextObject.SetActive(true);

        }
    }

    void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);
        rb.AddForce(movement * speed);
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


//    void OnTriggerEnter(Collider other)
//    {
//        // ..and if the GameObject you intersect has the tag 'Pick Up' assigned to it..
//        if (other.gameObject.CompareTag("PickUp"))
//        {
//            other.gameObject.SetActive(false);

//            // Add one to the score variable 'count'
//            count = count + 1;

//            // Run the 'SetCountText()' function (see below)
//            SetCountText();
//        }
//    }

//    void OnMove(InputValue value)
//    {
//        Vector2 v = value.Get<Vector2>();

//        movementX = v.x;
//        movementY = v.y;
//    }

//    void SetCountText()
//    {
//        countText.text = "Count: " + count.ToString();

//        if (count >= 12)
//        {
//            // Set the text value of your 'winText'
//            winTextObject.SetActive(true);
//        }
//    }
//}


