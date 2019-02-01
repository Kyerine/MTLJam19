using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;

public class Movement : MonoBehaviour
{
    public GameObject triggeredItem;
    public Vector2 targetPosition;

    private RaycastHit2D hitInfo;
    private Animator anim;




    void Start()
    {
        targetPosition = transform.position;
        anim = GetComponent<Animator>();

    }
    // Update is called once per frame
    void Update()
    {
        MouseDetect();
       
    }

    private void MouseDetect()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Vector2 ray = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (EventSystem.current.IsPointerOverGameObject())
            {
            }
            else
            {
                hitInfo = Physics2D.Raycast(ray, Vector2.zero);
                doWork();
            }
        }
        if (Vector2.Distance(transform.position, targetPosition) > 0.05)
        {
            if (targetPosition.x > transform.position.x)
            {

                anim.SetInteger("BSTATE", 1);
                GetComponent<SpriteRenderer>().flipX = false;
            }
            else if (targetPosition.x < transform.position.x)
            {
                anim.SetInteger("BSTATE", 1);
                GetComponent<SpriteRenderer>().flipX = true;
            }
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, Time.deltaTime * 5);
        }
        else
        {
            anim.SetInteger("BSTATE", 0);

            targetPosition = transform.position;

        }

    }

    public void doWork()
    {
       if (hitInfo.collider == null && triggeredItem == null)
       {
            targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            targetPosition.y = transform.position.y;
        }
        else if (hitInfo.collider != null && triggeredItem == null)
        {
            if (hitInfo.collider.tag == "Untagged" || hitInfo.collider.tag == "Floor") 
            {
                targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                targetPosition.y = transform.position.y;
            }
            else
            {
                Debug.Log("Hellor");

                ObjectInterface obj = hitInfo.collider.gameObject.GetComponent<ObjectInterface>();
                obj.Work();
            }
            
        }
       else if (hitInfo.collider == null && triggeredItem != null)
        {
            triggeredItem = null;

        }
        else if (hitInfo.collider != null && triggeredItem != null)
        {
            if (hitInfo.collider.tag == "Untagged" || hitInfo.collider.tag == "Floor")
            {

                triggeredItem = null;
            }
            else
            {
                ObjectInterface obj = hitInfo.collider.gameObject.GetComponent<ObjectInterface>();
                obj.ApplyItem(triggeredItem);
                triggeredItem = null;
            }

        }
        else
        {
            Debug.Log("Error");
        }
    }

    public void setLoc(Vector2 loc)
    {
        targetPosition = loc;

    }

    public void setTrigerItem(GameObject item)
    {
        this.triggeredItem = item;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Ladder")
        {
            this.GetComponent<Rigidbody2D>().gravityScale = 0f;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Ladder")
        {
            this.GetComponent<Rigidbody2D>().gravityScale = 1f;
        }
    }

}
