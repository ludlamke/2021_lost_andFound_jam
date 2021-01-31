using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controler : MonoBehaviour
{
    private float playerspeed;
    private float moveVertical = 15;
    private float moveHorizonal = 15;
    private float moveVVolisty;
    private float moveHVolisity;

    public bool objHeld = false;

    Vector3 newplace;
    private Rigidbody2D rigid;
    private Animator playerAnim;
    [SerializeField] private string PlayerInputV;
    [SerializeField] private string PlayerInputH;

    public Transform hands;
    public LayerMask intObj;
    public float handCheck;
    [SerializeField] private bool Pickable;

    public GameObject NewFreind;
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        playerAnim = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        Pickable = Physics2D.OverlapCircle(hands.position, handCheck, intObj);
    }
    // Update is called once per frame
    void Update()
    {
        GetInput();
        setAnim();
        flip();
        pickUp();
        placeObject();
        if(objHeld && NewFreind == null)
        {
            foreach (Transform child in transform)
            {
                if (child.tag == "object")
                {
                    NewFreind = child.gameObject;
                   
                }
            }
            
        }
        if(objHeld && NewFreind !=null)
        {
            NewFreind.transform.position = Vector3.MoveTowards(NewFreind.transform.position, new Vector3(transform.position.x, transform.position.y + 1, 10), 50 * Time.deltaTime);
        }
       
        
    }

    private void GetInput()
    {

        if (Mathf.Abs(Input.GetAxisRaw(PlayerInputV)) > 0)
        {
            moveHorizonal = 0;
            moveVertical = 15;
        }
        else if(Mathf.Abs(Input.GetAxisRaw(PlayerInputH)) > 0)
        {
            moveHorizonal = 15;
            moveVertical = 0;
        }
        moveVVolisty = moveVertical * Input.GetAxisRaw(PlayerInputV);
        moveHVolisity = moveHorizonal * Input.GetAxisRaw(PlayerInputH);
      
        rigid.velocity = new Vector2(moveHVolisity, moveVVolisty);
        
        
    }

    private void pickUp()
    {
        if(Input.GetButtonDown("Fire1") && Pickable && !objHeld)
        {
            NewFreind.transform.parent = this.transform;

            
            objHeld = true;
        }

    }

    private void flip()
    {
        if(rigid.velocity.x > 0)
        {
            transform.localScale = new Vector2(1, 1);

        }
        else if(rigid.velocity.x < 0)
        {
            transform.localScale = new Vector2(-1, 1);
        }
    }

    private void setAnim()
    {
        playerAnim.SetBool("Holding", objHeld);

        if(rigid.velocity.x == 0 && rigid.velocity.y == 0 )
        {
            playerAnim.SetBool("notMovming", true);
        }
        else
        {
            playerAnim.SetBool("notMovming", false);
        }
        playerAnim.SetFloat("MovmentH", Mathf.Abs(rigid.velocity.x));
        playerAnim.SetFloat("MovmentV", rigid.velocity.y);

        if(rigid.velocity.x > 0)
        {
            hands.transform.position = new Vector3(transform.position.x + 1.5f, transform.position.y, transform.position.z);
            playerAnim.SetBool("side", true);
            playerAnim.SetBool("up", false);
            playerAnim.SetBool("down", false);
        }

        if (rigid.velocity.y > 0)
        {
            hands.transform.position = new Vector3(transform.position.x , transform.position.y + 1.5f, transform.position.z);
            playerAnim.SetBool("side", false);
            playerAnim.SetBool("up", true);
            playerAnim.SetBool("down", false);
        }

        if (rigid.velocity.y < 0)
        {
            hands.transform.position = new Vector3(transform.position.x, transform.position.y - 1.5f, transform.position.z);
            playerAnim.SetBool("side",false);
            playerAnim.SetBool("up", false);
            playerAnim.SetBool("down", true);
        }
    }

    private void placeObject()
    {
        if (Input.GetButtonDown("Fire2") && objHeld)
        {

            objHeld = false;

            NewFreind.transform.parent = null;

            if (hands.transform.position.x == transform.position.x + 1.5)
            {
                newplace = new Vector3(NewFreind.transform.position.x + 5, NewFreind.transform.position.y - 5 , 10);
                
                
            }

            if (hands.transform.position.x == transform.position.x - 1.5)
            {
                newplace = new Vector3(NewFreind.transform.position.x - 5, NewFreind.transform.position.y - 5, 10);
                
                
            }

            if (hands.transform.position.y == transform.position.y + 1.5)
            {
                newplace = new Vector3(NewFreind.transform.position.x , NewFreind.transform.position.y + 5, 10);
                 
            }

            if (hands.transform.position.y == transform.position.y - 1.5)
            {
                newplace = new Vector3(NewFreind.transform.position.x, NewFreind.transform.position.y - 10, 10);
                
            }

            NewFreind.transform.position = Vector3.MoveTowards(NewFreind.transform.position, newplace, 50 * Time.deltaTime);
            if (NewFreind.transform.position == newplace)
            {
                NewFreind = null;
            }
            

        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "object")
        {
            NewFreind = other.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "object")
        {
            NewFreind = null;
        }
    }
}
