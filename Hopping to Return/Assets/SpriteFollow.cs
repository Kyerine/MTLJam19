using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteFollow : MonoBehaviour
{
  public Transform target;
  public float xOffset = 2f;
  public float yOffset = 2f;
  public float zOffset = 2f;
    
  void LateUpdate()
  {
    if(target == null)
    {
      Destroy(this.gameObject);
    }
    else
    {
      transform.position = new Vector3(target.position.x + xOffset,
      target.position.y + yOffset, target.position.z + zOffset);
    }
  }
}
