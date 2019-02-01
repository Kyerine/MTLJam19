using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Reaction : ScriptableObject
{
  // Start is called before the first frame update
  public abstract void React();
  public abstract void Init();

}
