using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(menuName = "Reactions/PlayerTeleport")]
public class TeleportPlayer : DelayedReaction
{
  public Vector3 newPlayerLocation;
  public Vector3 newCameraLocation;

  Player player;
  Camera camera;

  public override void Init()
  {
    player = FindObjectOfType<Player>();
    camera = FindObjectOfType<Camera>();
  }

  public override void React()
  {
    Debug.Log("Moving to new room");
        // Make it so that's the agent's destination
        player.Stop();
        // Set the new player position
        player.transform.position = newPlayerLocation;
    
    // Set the new camera position
    camera.transform.position = new Vector3(newCameraLocation.x, newCameraLocation.y, newCameraLocation.z);
  }
}
