using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Reactions/Dialog Reaction")]
public class DialogReaction : DelayedReaction
{
  // Character speaking
  public string character;
  // Text character is saying
  public string text;

  public override void Init()
  {
  }

  public override void React()
  {
    TextManager.instance.CharacterSpeak(character, text);
  }
}
