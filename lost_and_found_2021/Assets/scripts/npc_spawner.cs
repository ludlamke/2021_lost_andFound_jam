using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class npc_spawner : MonoBehaviour
{
    public GameObject[] npcList;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(npcList[Random.Range(0,npcList.Length)]);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
