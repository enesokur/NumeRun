using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlimitedRoad : MonoBehaviour
{
    GameObject Road;
    void Start(){
        Road = this.transform.gameObject;
    }


    void MoveRoad(){ // Moving roads forward to make unlimited road illusion.
        Road.transform.position += new Vector3(0f,0f,Road.GetComponent<Renderer>().bounds.size.z*3);
    }

   private void OnTriggerExit(Collider other) {
       Invoke("MoveRoad",0.5f);
   }
}
