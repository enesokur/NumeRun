using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour
{
    public GameObject[] Objects = new GameObject[3];
    // path bools control not to overlap more than one object.
    bool firstPath = true;
    bool secondPath = true;
    bool thirdPath = true;
    //bool fourthPath = true;
    void Start(){
        
    }

    public void SpawnObjects(GameObject Road){
        // numOfObjectsRow determines how many objects are going to be in a one row. between 2 and 4
        int numOfObjectsRow = Random.Range(3,4);
        // Spawning objects. Outer loop determines how many rows are going to be.
        for(int i=0;i<=1;i++){
            for(int j=1;j<=numOfObjectsRow;j++){
                int objectPos = Random.Range(1,4);
                if(objectPos == 1 && firstPath == true){
                    int objectIndex = Random.Range(0,3);
                    var objectspawned = Instantiate(Objects[objectIndex]);
                    objectspawned.transform.position = new Vector3(-3.6f,objectspawned.transform.position.y,-20f+Road.transform.position.z+30f*i);
                    objectspawned.transform.parent = Road.transform;
                    firstPath = false;
                }
                else if(objectPos == 2 && secondPath == true){
                    int objectIndex = Random.Range(0,3);
                    var objectspawned = Instantiate(Objects[objectIndex]);
                    objectspawned.transform.position = new Vector3(0f,objectspawned.transform.position.y,-20f+Road.transform.position.z+30f*i);
                    objectspawned.transform.parent = Road.transform;
                    secondPath = false;
                }
                else if(objectPos == 3 && thirdPath == true){
                    int objectIndex = Random.Range(0,3);
                    var objectspawned = Instantiate(Objects[objectIndex]);
                    objectspawned.transform.position = new Vector3(3.6f,objectspawned.transform.position.y,-20f+Road.transform.position.z+30f*i);
                    objectspawned.transform.parent = Road.transform;
                    thirdPath = false;
                }
                /*else if(objectPos == 4 && fourthPath == true){
                    int objectIndex = Random.Range(0,2);
                    var objectspawned = Instantiate(Objects[objectIndex]);
                    objectspawned.transform.position = new Vector3(3.6f,1f,Road.transform.position.z-40*i);
                    objectspawned.transform.parent = Road.transform;
                    fourthPath = false;
                }*/
            }
            firstPath =true;
            secondPath =true;
            thirdPath = true;
            //fourthPath = true;
        }
    }
}
