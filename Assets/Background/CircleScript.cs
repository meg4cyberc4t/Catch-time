using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider collider) {
        Debug.Log(collider);
        // if (collision.gameObject.tag == "Player") {
        //     Debug.Log("Check!");
        //     // collision.gameObject.SendMessage("Apply")
        // }
    }
}
