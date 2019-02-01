using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Reactions/Change Music")]
public class ChangeMusic : Reaction
{
     public string track;
     AudioController musicBox;

  public override void Init()
  {
    musicBox = FindObjectOfType<AudioController>();
  }

  public override void React()
  {
    musicBox.setWorldTrack(track);
  }

}
