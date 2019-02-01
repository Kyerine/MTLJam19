using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class ItemManager : MonoBehaviour
{

    public GameObject inventory;
    public Image slot1;
    public Image slot2;
    public Image slot3;
    public Image slot4;

    public bool activeInv = false;

    private ArrayList pack = new ArrayList(4);
    private Image[] imgarr;
    GraphicRaycaster m_Raycaster;
    PointerEventData m_PointerEventData;
    EventSystem m_EventSystem;

    // Start is called before the first frame update
    void Start()
    {
        m_Raycaster = inventory.GetComponent<GraphicRaycaster>();
        m_EventSystem = GetComponent<EventSystem>();
        imgarr = new Image[] { slot1, slot2, slot3, slot4 };

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            if (activeInv)
            {
                inventory.SetActive(false);
                activeInv = false;
            }
            else
            {
                inventory.SetActive(true);
                activeInv = true;
            
            }

        }
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            //Set up the new Pointer Event
            m_PointerEventData = new PointerEventData(m_EventSystem);
            //Set the Pointer Event Position to that of the mouse position
            m_PointerEventData.position = Input.mousePosition;

            //Create a list of Raycast Results
            List<RaycastResult> results = new List<RaycastResult>();
            //RaycastResult results;
            //Raycast using the Graphics Raycaster and mouse click position
            m_Raycaster.Raycast(m_PointerEventData, results);

            //For every result returned, output the name of the GameObject on the Canvas hit by the Ray
            foreach (RaycastResult result in results)
            {
                    Debug.Log(result.gameObject.tag);
                    GameObject temp = result.gameObject;
                    ObjectInterface obj = temp.GetComponent<ObjectInterface>();
                    obj.Work();
                    break;
            }
           
        }
    }

    public void Build()
    {
        int temp = 0;
        foreach (GameObject obj in pack)
        {
            ObjectInterface img = imgarr[temp].GetComponent<ObjectInterface>();
            img.ApplyItem(obj);
            temp++;
        }
    }

    public void pickUp(GameObject listitem)
    {
        Debug.Log(listitem);
        pack.Add(listitem);
        Build();

    }


    public void useCard(GameObject refer)
    {
        pack.Remove(refer);
    }
}
