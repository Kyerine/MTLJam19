using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Reactions/Fade Out")]
public class FadeOut : DelayedReaction
{
  public float fadeDuration = 10.0f;
  CamAR mainCamera;
  public override void Init()
  {
    mainCamera = CamAR.instance;
  }

  public override void React()
  {
    Debug.Log(mainCamera != null);
    mainCamera.FadeOut(fadeDuration);
  }
}
