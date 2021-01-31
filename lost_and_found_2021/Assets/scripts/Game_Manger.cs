using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Game_Manger : MonoBehaviour
{
    public GameObject[] obj_arry;
    public Text cloke;
    private float timer = 30;
    // Start is called before the first frame update
    void Start()
    {
       for(int i = 0; i < obj_arry.Length; ++i)
            {
            Instantiate(obj_arry[i]);
            }
           
    }

    // Update is called once per frame
    void Update()
    {
       

        if (timer <= 0)
        {
            cloke.text = "scrooob";
        }
        else
        {
                timer -= Time.deltaTime;
            cloke.text = "" + (int)timer;
        }
    }

    
}
