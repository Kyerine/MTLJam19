using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Reactions/Fade In")]
public class FadeIn : DelayedReaction
{  
    public float fadeDuration = 0.7f;
    CamAR mainCamera;

    public override void Init()
    {
     mainCamera = FindObjectOfType<CamAR>();
    }

    public override void React()
    {
      mainCamera.FadeIn(fadeDuration);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
