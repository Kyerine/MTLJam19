using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{

  AudioSource greyWorld;
  AudioSource redWorld;
  AudioSource purpleWorld;
  AudioSource blueWorld;

  AudioSource currentlyPlaying;
  Coroutine audioCoroutine;

  // Start is called before the first frame update
  void Start()
  {
    AudioSource[] audioSources = GetComponents<AudioSource>();
    greyWorld = audioSources[0];
    redWorld = audioSources[1];
    purpleWorld = audioSources[2];
    blueWorld = audioSources[3];

    setWorldTrack("greyWorld");
  }

  public void setWorldTrack(string world)
  {
    Debug.Log("Switching tracks");
    if (audioCoroutine != null)
    {
      StopCoroutine(audioCoroutine);
    }
    switch (world)
    {
      case "greyWorld":
        audioCoroutine = StartCoroutine(PlayTrack(greyWorld));
        break;
      case "redWorld":
        Debug.Log("TRACK: Red World");
        audioCoroutine = StartCoroutine(PlayTrack(redWorld));
        break;
      case "purpleWorld":
        Debug.Log("TRACK: Purple World");
        audioCoroutine = StartCoroutine(PlayTrack(purpleWorld));
        break;
      case "blueWorld":
        Debug.Log("TRACK: Blue World");
        audioCoroutine = StartCoroutine(PlayTrack(blueWorld));
        break;
      default:
        break;
    }
  }

  IEnumerator PlayTrack(AudioSource track)
  {
    float inOut = 0.5f;
    float step;
    if (currentlyPlaying != null)
    {
      // Fade out
      float originalVolume = currentlyPlaying.volume;
      step = originalVolume / inOut;
      while (currentlyPlaying.volume > 0.0f)
      {
        currentlyPlaying.volume = Mathf.Clamp01(currentlyPlaying.volume - step * Time.deltaTime);
        yield return new WaitForFixedUpdate();
      }
      currentlyPlaying.Stop();
      currentlyPlaying.volume = originalVolume;
    }
    currentlyPlaying = track;
    float targetInVolume = track.volume;
    step = targetInVolume / inOut;
    track.volume = 0.0f;
    track.time = 0;
    track.loop = true;
    track.Play();
    while (track.volume < targetInVolume)
    {
      track.volume += step * Time.deltaTime;
      yield return new WaitForFixedUpdate();
    }
  }

  // Update is called once per frame
  void Update()
  {

  }
}
