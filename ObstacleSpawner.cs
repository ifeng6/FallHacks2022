using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public int toSpawn = 1;
    public GameObject obstaclePrefab;
    public GameObject player;
    private System.Random rnd;

    // speed of the rock
    private int lowerSpeed;
    private int upperSpeed;

    // variance of the rock's direction towards the player
    private float vertVar;
    private float horizVar;

    // fields that determine where to spawn the rock
    private int lowerxzDist; // distance in xz plane spawned away from player
    private int upperxzDist;
    private int lowerHeight; // distance in y spawned away from player
    private int upperHeight;
    private Vector2 xzplane;
    private Vector3 direction;
    
    // Start is called before the first frame update
    void Start()
    {
        // used to generate random speed
        lowerSpeed = 8;
        upperSpeed = 12;
        rnd = new System.Random();
        // used to generate direction randomness
        vertVar = rnd.Next(-500, 300)/100;
        horizVar = rnd.Next(-500, 300)/100;
        // values away from the player for the rocks to spawn from
        lowerxzDist = 50;
        lowerxzDist = 100;
        lowerHeight = 10;
        upperHeight = 50;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void spawnObject() {
        int speed = rnd.Next(lowerSpeed, upperSpeed);
        int xzDist = rnd.Next(50, 100); // 
        // set the x, y, and z position of the space rock
        // x and y use xzDist and a mulitplier so that the space rock spawns in a cone in front of the player (facing -z)
        float z = (float)((rnd.NextDouble() * 2) - 1) * xzDist;
        float x = (float)rnd.NextDouble() * xzDist;
        float y = (float)rnd.Next(lowerHeight, upperHeight);

        // set the direction of the space rock based on it's position relative to the player and some slight variance
        float xvar = 0;
        float yvar = vertVar;
        float zvar = 0;
        if (horizVar < 0) {
            xvar = horizVar;
        } else {
            zvar = horizVar;
        }
        direction = new Vector3(player.transform.position.x - x - xvar, player.transform.position.y - y - yvar, player.transform.position.z - z - zvar);
        direction.Normalize();

        // set obstacle's direction and speed and starting position
        Vector3 position = new Vector3(x, y, z);
        GameObject obstacle = (GameObject)Instantiate(obstaclePrefab, position, Quaternion.identity);
        obstacle.GetComponent<Obstacle>().speed = speed;
        obstacle.GetComponent<Obstacle>().direction = direction;
        //Debug.Log($"spawned an object at {position} with speed {speed}");
        toSpawn--;
    }
}
