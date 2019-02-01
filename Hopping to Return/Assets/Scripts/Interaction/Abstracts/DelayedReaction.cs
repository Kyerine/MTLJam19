using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class DelayedReaction : Reaction
{ 
  public float secondDelay;
  private WaitForSeconds delay;
  private Coroutine currentCoroutine;

  public void React(MonoBehaviour mono)
  {
    mono.StartCoroutine(DelayedReact());
  }

  public void Init(MonoBehaviour mono)
  {
    Init();
  }

  IEnumerator DelayedReact()
  {
    yield return new WaitForSeconds(secondDelay);
    React();
  }
}
