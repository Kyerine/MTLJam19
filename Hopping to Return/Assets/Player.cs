using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

public class Player : MonoBehaviour
{
  public GameObject player;

  // Components
  NavMeshAgent agent;
  Animator anim;
  SpriteRenderer spriteRenderer;
  AudioSource footsteps;

  // State
  Interactable currentInteractable;
  GameObject triggeredItem;
  bool handleInput;
  

  // Start is called before the first frame update
  void Start()
  {
    handleInput = true;
    agent = GetComponent<NavMeshAgent>();
    anim = player.GetComponent<Animator>();
    spriteRenderer = player.GetComponent<SpriteRenderer>();
    footsteps = GetComponent<AudioSource>();
  }

  // Update is called once per frame
  void Update()
  {
    if (agent.pathPending)
      return;

    if(agent.remainingDistance <= agent.stoppingDistance || !agent.hasPath)
    {
      Stopping();
    }

    if(agent.hasPath)
    {
      Moving();
    }
  }

  public void Stop()
  {
    agent.ResetPath();
  }

  void Stopping()
  {
    footsteps.Stop();
    agent.isStopped = true;
    // Set to idle animation
    anim.SetInteger("BSTATE", 0);
    if (currentInteractable != null)
    {
      currentInteractable.Work();
      currentInteractable = null;
    }
  }

  void Moving()
  {
    agent.isStopped = false;
    Vector3 targetPosition = agent.destination;

      if (targetPosition.x > transform.position.x)
      {

        anim.SetInteger("BSTATE", 1);
        spriteRenderer.flipX = false;
      }
      else if (targetPosition.x < transform.position.x)
      {
        anim.SetInteger("BSTATE", 1);
        spriteRenderer.flipX = true;
      }
  }

  public void OnGroundClicked(BaseEventData data)
  {
    if (!handleInput)
      return;

    if (!footsteps.isPlaying)
    {
      footsteps.Play();
    }

    currentInteractable = null;
    PointerEventData pData = (PointerEventData)data;
    NavMeshHit hit;
    Vector3 destinationPosition;
    if (NavMesh.SamplePosition(pData.pointerCurrentRaycast.worldPosition, out hit, 4f, NavMesh.AllAreas))
      destinationPosition = hit.position;
    else
      destinationPosition = pData.pointerCurrentRaycast.worldPosition;
    agent.SetDestination(destinationPosition);
  }

  public void OnInteractableClicked(Interactable interactable)
  {
    // Approach the interactable
    agent.SetDestination(interactable.interactPosition.position);
    currentInteractable = interactable;
  }

  public bool SelectedItemIs(string tag)
  {
    return this.triggeredItem.tag == tag;
  }

  public void SetTriggerItem(GameObject item)
  {
        Debug.Log(item);
    this.triggeredItem = item;
  }

  public string GetTriggerItem()
  {
    if(triggeredItem == null)
    {
      return "";
    }
    return triggeredItem.tag;
  }

  public void SetFootStepSound(AudioClip clip)
  {
    footsteps.clip = clip;
  }
}
