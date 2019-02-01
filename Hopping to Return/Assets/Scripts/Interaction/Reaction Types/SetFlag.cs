using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Reactions/Set Flag Reaction")]
public class SetFlag : Reaction
{
    public GlobalFlag flag;
    public bool value;

  public override void Init()
  {
  }

  public override void React()
  {
    flag.SetValue(value);
  }
}
