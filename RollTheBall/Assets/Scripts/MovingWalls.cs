using UnityEngine;
using System.Collections;
public class MovingWalls : MonoBehaviour
{
public float speed = 2;
void Update()
{
transform.position = new Vector3(transform.position.x, transform.position.y, Mathf.PingPong(Time.time*speed, 8));
}
 
}
