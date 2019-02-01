using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextManager : MonoBehaviour
{
  public TextMeshProUGUI dialogText;
  public float textDurationSeconds = 2.0f;

  // Singleton
  public static TextManager instance = null;

  // State
  Coroutine currentDialog;

  void Awake()
  {
    if(instance == null)
    {
      instance = this;
      DontDestroyOnLoad(this);
    }
    else
    {
      Destroy(this);
    }
  }

  void Start()
  {
    ClearDialog();
  }

  // Update is called once per frame
  void Update()
  {
      
  }

  public void CharacterSpeak(string character, string text)
  {
    CharacterSpeak(character, text, textDurationSeconds);
  }

  public void CharacterSpeak(string character, string text, float duration)
  {
    string dialog = string.Format("{0}: {1}", character, text);
    currentDialog = StartCoroutine(ShowDialog(dialog, duration));
  }

  public IEnumerator ShowDialog(string text, float duration)
  {
    dialogText.gameObject.SetActive(true);
    dialogText.SetText(text);
    yield return new WaitForSeconds(duration);
    ClearDialog();
  }

  public void ClearDialog()
  {
    dialogText.gameObject.SetActive(false);
    dialogText.SetText("");
  }
}
