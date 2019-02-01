using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DarkObjects : MonoBehaviour, ObjectInterface
{

    public GameObject self;
    private GameObject box;
    private GameObject flashlight;
    public Canvas can;
    public Sprite spr;

    // Start is called before the first frame update
    void Start()
    {
        flashlight = GameObject.FindWithTag("flashlight");
    }

    private void OnTriggerEnter(Collider other)
    {
         box = Instantiate(self, gameObject.transform.position, Quaternion.identity);
    }

    private void OnTriggerExit(Collider other)
    {
        
            if(box != null)
        {
            Destroy(box);
        }
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if(gameObject.tag == "exit")
            {
                Debug.Log("Zoomable Clicked");
                StartCoroutine(MoveCamera(0, -29));
            }
            else
            {
                other.GetComponent<zoo>().score++;
                can.GetComponentInChildren<Image>().sprite = spr;
                StartCoroutine(img());
               
                Debug.Log("Zoomable Clicked");
            }
          //  flashlight.GetComponent<flashlight>().foundItem();
        }
    }





    public void Work()
    {
        //reaction shows picture of clue
        //Destroy(gameObject);
    }

    public void ApplyItem(GameObject item)
    {

    }
    IEnumerator MoveCamera(float x, float y)
    {
        Camera.main.transform.Translate(x, y, 0);
        yield return new WaitForSeconds(1f);
    }
    IEnumerator img()
    {
        can.gameObject.SetActive(true);
        yield return new WaitForSeconds(1f);
        Debug.Log("HELO");
        can.gameObject.SetActive(false); Destroy(gameObject);
        self.GetComponent<ParticleSystem>().Stop();
    }


}
