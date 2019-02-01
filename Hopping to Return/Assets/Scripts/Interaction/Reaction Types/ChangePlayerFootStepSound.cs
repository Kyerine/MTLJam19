using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Reactions/Change Footsteps")]
public class ChangePlayerFootStepSound : Reaction
{
  public AudioClip footStepClip;
  Player player;
  public override void Init()
  {
    player = FindObjectOfType<Player>();
  }

  public override void React()
  {
    player.SetFootStepSound(footStepClip);
  }

}
