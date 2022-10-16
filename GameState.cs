using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    private enum states {RUN, BOMB, END};
    // private int currState;
    private bool called;

    public ObstacleSpawner spawner;

    // Start is called before the first frame update
    void Start()
    {
        // currState = 0;
        called = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!called) {
            StartCoroutine(spawnSpaceRock());
            called = true;
        }
    }

   public IEnumerator spawnSpaceRock() {
        while(spawner.toSpawn > 0) {
            spawner.spawnObject();
            //Debug.Log("spawning object in coroutine");
            yield return new WaitForSeconds(1);
        }   
        
    }
}
