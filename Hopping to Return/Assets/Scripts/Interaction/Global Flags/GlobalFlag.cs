using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Global Flag")]
public class GlobalFlag : ScriptableObject
{
  public int id;
  public string description;

  public void SetValue(bool value)
  {
    AllFlags.instance.SetFlag(id, value);
  }

  public bool GetValue()
  {
    return AllFlags.instance.GetFlag(id);
  }
}
