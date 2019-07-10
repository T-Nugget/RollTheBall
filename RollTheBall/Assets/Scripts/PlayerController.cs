using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour 
{
    public float speed;
    public Text countText, livesText;
    public Text winText;
     public GameObject other;
   
    private Rigidbody rb;
    public int count;

    private int life;
  
    void Start () 
    {
        rb = GetComponent<Rigidbody> ();
        count = 0;
        life = 3;

        
        countText.text = "Count: " + count.ToString ();
        if (count >= 23) 
        {
            winText.text = "You Win!";
        }
        winText.text = "";

        livesText.text = "Lives: " + life.ToString ();
        if (life <= 0) 
        {
            winText.text = "You Lose!";
            Destroy(this);
        }
        winText.text = "";

       
       
    }

    void FixedUpdate () 
    {
        float moveHorizontal = Input.GetAxis ("Horizontal");
        float moveVertical = Input.GetAxis ("Vertical");
        if (Input.GetKey ("escape"))
            Application.Quit ();
        Vector3 Movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

        rb.AddForce (Movement * speed);  

         if (count >= 8)
        {
            Destroy(other);
        }
    }

    
       void OnTriggerEnter (Collider other) 
    {
        if (other.gameObject.CompareTag ("Pick Up")) 
        {
            other.gameObject.SetActive (false);
            count = count + 1;
            countText.text = "Count: " + count.ToString ();
            if (count >= 23) 
            {
                winText.text = "You Win!";
            }
        }

        
        if (other.gameObject.CompareTag ("Enemy")) 
        {
            other.gameObject.SetActive (false);
            life = life - 1;
            livesText.text = "Lives: " + life.ToString ();
            if (life <= 0) 
            {
                winText.text = "You Lose!";
                Destroy(this);
            }
        }
        
    }




}