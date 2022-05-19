using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlimitedRoad : MonoBehaviour
{
    GameObject Road;
    int count = 1;
    void Start(){
        Road = this.transform.gameObject;
        Obstacles script = GameObject.Find("Character").GetComponent<Obstacles>();
        script.SpawnObjects(Road);
    }


    void MoveRoad(){ // Moving roads forward to make unlimited road illusion.
        Road.transform.position += new Vector3(0f,0f,Road.GetComponent<Renderer>().bounds.size.z*3);
    }

   private void OnTriggerExit(Collider other) {
        if(count % 2 == 1){
            for(int i=0;i<Road.transform.childCount;i++){
            Destroy(Road.transform.GetChild(i).gameObject);
            }
            Invoke("MoveRoad",0.5f);
            Obstacles script = GameObject.Find("Character").GetComponent<Obstacles>();
            script.SpawnObjects(Road);
        }
        count++;


   }
}
