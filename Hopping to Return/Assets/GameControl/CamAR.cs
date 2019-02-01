using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CamAR : MonoBehaviour
{// Use this for initialization

  public Image fadeImage;
  public static CamAR instance = null;

  private void Awake()
  {
    // Singleton
    if (instance == null)
    {
      instance = this;
    }
    else
    {
      Destroy(this);
    }
    DontDestroyOnLoad(this);

  }

  void Start()
  {
    // Disable the fade image and make it transparent
    fadeImage.gameObject.SetActive(false);
    fadeImage.color = new Color(fadeImage.color.r, fadeImage.color.g, fadeImage.color.b, 0.0f);
    // set the desired aspect ratio (the values in this example are
    // hard-coded for 16:9, but you could make them into public
    // variables instead so you can set them at design time)
    float targetaspect = 11.70f / 8.3f;

    // determine the game window's current aspect ratio
    float windowaspect = (float)Screen.width / (float)Screen.height;

    // current viewport height should be scaled by this amount
    float scaleheight = windowaspect / targetaspect;

    // obtain camera component so we can modify its viewport
    Camera camera = GetComponent<Camera>();

    // if scaled height is less than current height, add letterbox
    if (scaleheight < 1.0f)
    {
      Rect rect = camera.rect;

      rect.width = 1.0f;
      rect.height = scaleheight;
      rect.x = 0;
      rect.y = (1.0f - scaleheight) / 2.0f;

      camera.rect = rect;
    }
    else // add pillarbox
    {
      float scalewidth = 1.0f / scaleheight;

      Rect rect = camera.rect;

      rect.width = scalewidth;
      rect.height = 1.0f;
      rect.x = (1.0f - scalewidth) / 2.0f;
      rect.y = 0;

      camera.rect = rect;
    }
  }

  public void FadeOut(float duration)
  {
    StartCoroutine(DoFadeOut(0.0f, 1.0f, duration));
  }

  public void FadeIn(float duration)
  {
    StartCoroutine(DoFadeIn(1.0f, 0.0f, duration));
  }

  IEnumerator DoFadeOut(float start, float end, float duration)
  {
    if (start < end)
    {
      fadeImage.gameObject.SetActive(true);
      float currentAlpha = start;
      float step = (start - end) / duration;
      while (currentAlpha < end)
      {
        currentAlpha = Mathf.Clamp(currentAlpha - step * Time.deltaTime, start, end);
        Color newColor = fadeImage.color;
        newColor.a = currentAlpha;
        fadeImage.color = newColor;
        yield return new WaitForEndOfFrame();
      }
    }
  }

  IEnumerator DoFadeIn(float start, float end, float duration)
  {
    Debug.Log("Fading IN");
    if (start > end)
    {
      fadeImage.gameObject.SetActive(true);
      float currentAlpha = start;
      float step = (start - end) / duration;
      while (currentAlpha > end)
      {
        currentAlpha = Mathf.Clamp(currentAlpha - step * Time.deltaTime, end, start);
        Color newColor = fadeImage.color;
        newColor.a = currentAlpha;
        fadeImage.color = newColor;
        yield return new WaitForEndOfFrame();
      }
      fadeImage.gameObject.SetActive(false);
    }
  }

}
