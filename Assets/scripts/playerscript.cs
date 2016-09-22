﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class playerscript : MonoBehaviour {

    public float speed;
    public Text countText;
    public Text winText;
    public Text hint;

    private Rigidbody rb;
    private int count;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        setCountText();
        winText.text = "";
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);
    }
    void OnTriggerEnter(Collider other){
        if(other.gameObject.CompareTag("Pick up"))
        {
            other.gameObject.SetActive(false);
            count++;
            setCountText();
            hint.text = "";
            
        }
    }
    void setCountText()
    {
        countText.text = "Count: " + count.ToString();
        if (count >= 9)
            winText.text = "You Win!";
    }
    
}
    