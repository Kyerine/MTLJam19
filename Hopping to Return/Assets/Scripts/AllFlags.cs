using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllFlags : MonoBehaviour
{
  public static AllFlags instance = null;

  private Hashtable conditions;
  // Singleton
  void Awake()
  {
    if(instance == null)
    {
      instance = this;
      DontDestroyOnLoad(this);
    }
    else
    {
      Destroy(this);
    }
  }
  // Start is called before the first frame update
  void Start()
  {
    conditions = new Hashtable();
  }

  public void SetFlag(int id, bool value)
  {
    conditions.Add(id, value);
  }

  public bool GetFlag(int id)
  {
    bool hasFlag = conditions.ContainsKey(id);
    if(hasFlag)
    {
      return (bool) conditions[id];
    }
    return false;
  }
}
