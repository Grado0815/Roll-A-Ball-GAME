using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using Debug = UnityEngine.Debug;

public class PlayerController : MonoBehaviour
{

    public float speed = 0;
    public TextMeshProUGUI countText;
    
    public GameObject winTextObject;
    
    
    //Rigidbody variable privat (isolated)
    private Rigidbody rb;
    
    //counter of natural numbers
    private int count;
    
    private float movementX;
    private float movementY;

    
    
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        //everytime the count variable is updated
        SetCountText();
      
        
        //only display, if the player completed the game
        winTextObject.SetActive(false);
        
        
    }

    void OnMove(InputValue movementValue)
    {
        //Function input parameters
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        
        //if counter number higher than 11 - show Text "You Win!"
        if (count >= 13)
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
        
        //set Pickup Element to false if collision happen
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            //if Pickup Element collected set count +1
            count = count + 1;
            
            SetCountText();
        }
        else if (other.gameObject.CompareTag("Enemy"))
        {
            // works only in Unity Development Environment
            Debug.Log( message: "GAME OVER!");
            
#if UNITY_EDITOR
            UnityEditor.EditorApplication.ExitPlaymode();
#endif
            // works only with built Apps
            // Application.Quit();
        }
        
    
    }
    
    
}
