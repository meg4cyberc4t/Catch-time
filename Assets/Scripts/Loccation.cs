using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loccation : MonoBehaviour
{
    public Transform Player;
    public Animator anim;
    public Vector3 Coords = new Vector3(0,0,0);

    void OnTriggerEnter2D(Collider2D other)
    {
        Player = other.gameObject.transform;
        Player.transform.position = Coords;
        if (other.tag =="Player")
        {
            anim.Play("shade");
        }
        // SceneManager.LoadScene("Bedroom");


    }

    void Start()
    {
        // anim = GetComponent<Animator>();
    }


    void Update()
    {
        
    }
}
