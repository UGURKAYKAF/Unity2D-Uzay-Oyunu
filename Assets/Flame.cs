using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flame : MonoBehaviour
{

    public Transform flame;
    public static bool move;
    AudioSource audioSource2;
    private void Start()
    {
        flame.GetComponent<Renderer>().enabled = false;
        audioSource2 = GetComponent<AudioSource>();
    }
    void Update()
    {
        //Debug.Log(move);
        if (Input.GetKeyDown(KeyCode.W)|| Input.GetKeyDown(KeyCode.A)|| Input.GetKeyDown(KeyCode.S)|| Input.GetKeyDown(KeyCode.D))
        {
            //audioSource2.Play();
        }
        if (move==true)
        {
            flame.GetComponent<Renderer>().enabled = true;
        }
        else
        {
            flame.GetComponent<Renderer>().enabled = false;
        }
    }
}
