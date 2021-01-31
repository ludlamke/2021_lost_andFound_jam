using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectID_Handler : MonoBehaviour


{

    public int objID;
    private Sprite objimg;
    public GameObject[] spawn_pont;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = spawn_pont[Random.Range(0,spawn_pont.Length)].transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
