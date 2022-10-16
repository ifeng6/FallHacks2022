using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public Vector3 direction;
    public int speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        updatePosition();
    }

    void updatePosition() {
        transform.position += speed*direction*Time.deltaTime;
        // Debug.Log($"Direction: {direction}, Speed: {speed}, Position: {transform.position}");
    }

    void OnCollisionEnter(Collision collision) {
        Debug.Log("Collision Detected");
        if (collision.gameObject.tag == "Player") {
            Debug.Log("Player was hit");
        }
    }
}
