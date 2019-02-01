using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour, ObjectInterface
{
  public Transform interactPosition;

  public ConditionCollection[] conditions;
  public ReactionCollection defaultReaction;
  // Start is called before the first frame update
  void Start()
  {
      for(int i = 0; i < conditions.Length; i++)
    {
      conditions[i].Init(this);
    }
    defaultReaction.Init(this);
  }

  // Update is called once per frame
  void Update()
  {
      
  }

  public void Work()
  {
    for(int i = 0; i < conditions.Length; i++)
    {
      if (conditions[i].CheckAndReact(this))
        return;
    }

    // No reactions satisfied: Do default
    defaultReaction.React(this);
  }

  public void ApplyItem(GameObject item)
  {

  }
}
