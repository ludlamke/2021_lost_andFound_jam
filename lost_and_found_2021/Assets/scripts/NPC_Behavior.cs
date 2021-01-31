using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Behavior : MonoBehaviour
{
    public int order;
    public int objgevvin;
    public Game_Manger manger;
    public Sprite[] thoghtHandler;
    public GameObject thought;
    public GameObject bubble;
    // Start is called before the first frame update
    void Start()
    {
        manger = FindObjectOfType<Game_Manger>();
        order = Random.Range(0, 14);
        bubble = transform.Find("bubble").gameObject;
        thought = transform.Find("bubble").transform.Find("whatiwant").gameObject;
        thought.GetComponent<SpriteRenderer>().sprite = thoghtHandler[order];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "object")
        {
            Destroy(other.gameObject);
           objgevvin = other.GetComponent<ObjectID_Handler>().objID;
            manger.spawnNew(order);
            if (other.GetComponent<ObjectID_Handler>().objID == order)
            {
                manger.didPoint(100);
            }
            else if(other.GetComponent<ObjectID_Handler>().objID != order)
            {
                manger.didnotPoint(50);
            }
            Destroy(this.gameObject);
        }
        
        
    }
}
