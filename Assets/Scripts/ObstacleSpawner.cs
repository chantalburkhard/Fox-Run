using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour {
    
    public GameObject[] obstacles;
    public List<GameObject> obstaclesToSpawn = new List<GameObject> ();
    int index;
    float speed;

    void Awake() {
    	InitObstacles();
    }

    // Start is called before the first frame update
    void Start() {
        StartCoroutine(SpawnRandomObstacle());
       // StartCoroutine(ChangeSpeed());
    }

    
    void InitObstacles() {
       index = 0;
        //initialize game objects
        for (int i = 0; i < obstacles.Length * 3; i++){
        	GameObject obj = Instantiate(obstacles[index], transform.position, Quaternion.identity);
        	obstaclesToSpawn.Add(obj);
        	obstaclesToSpawn [i].SetActive (false);
        	index++;

        	//endless loop to spawn obstacles 
        	if (index == obstacles.Length){
        		index = 0;
        	}
        }
    }

    IEnumerator SpawnRandomObstacle(){
    	yield return new WaitForSeconds(Random.Range(1.5f, 4.5f));

    	int index = Random.Range(0, obstaclesToSpawn.Count);

    	while(true) {
    		if (!obstaclesToSpawn [index].activeInHierarchy){
    			obstaclesToSpawn [index].SetActive (true);
    			obstaclesToSpawn [index].transform.position = transform.position;
    			break;
    		} else {
    			index = Random.Range (0, obstaclesToSpawn.Count);
    		}
    	}
    	StartCoroutine (SpawnRandomObstacle());
    }

    /*IEnumerator ChangeSpeed(){
        //change obstacle speed to make the game more difficult by time
        //new speed
        speed -= 1f;
        //allocate speed to Game Object
        foreach(GameObject myObstacle in obstaclesToSpawn){
            myObstacle.GetComponent<Obstacle>().speed = speed;
        }
        //wait certain amount of time
        yield return new WaitForSeconds(10f);
        //repeat method
        StartCoroutine(ChangeSpeed());
    }*/
}
