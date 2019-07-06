using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {
    public float speed;
    public Text countText;
    public Text winText;

    private Rigidbody rb;
    private int count;
    void Start () {
        rb = GetComponent<Rigidbody> ();
        count = 0;
        countText.text = "Count: " + count.ToString ();
        if (count >= 7) {
            winText.text = "You Win!";
        }
        winText.text = "";
    }

    void FixedUpdate () {
        float moveHorizontal = Input.GetAxis ("Horizontal");
        float moveVertical = Input.GetAxis ("Vertical");
        if (Input.GetKey ("escape"))
            Application.Quit ();
        Vector3 Movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

        rb.AddForce (Movement * speed);
    }

    void OnTriggerEnter (Collider other) {
        if (other.gameObject.CompareTag ("Pick Up")) {
            other.gameObject.SetActive (false);
            count = count + 1;
            countText.text = "Count: " + count.ToString ();
            if (count >= 7) {
                winText.text = "You Win!";
            }
        }
    }

}