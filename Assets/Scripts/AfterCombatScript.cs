using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AfterCombatScript : MonoBehaviour
{
    public GameObject[] enemies;
    public GameObject[] objectsToActivate;
    public string[] lines;
    public GameObject SubtitleBox;
    public GameObject SubtitleText;
    public GameObject combatMusic;
    public bool isOver;
    public bool hasExecuted;

    public AudioSource source; 
    public float fadeTime = 1; 

    void Update()
    {
        if (!hasExecuted)
        {
            isOver = true;
            foreach (var enemy in enemies)
            {
                if (enemy != null)
                {
                    isOver = false;
                }
            }
            if (enemies.Length <= 0)
            {
                isOver = true;
            }
            if (isOver)
            {
                hasExecuted = true;
                source = combatMusic.GetComponent<AudioSource>();
                StartCoroutine(_FadeSound());

                StartCoroutine(SayLine());
                foreach (var obj in objectsToActivate)
                {
                    obj.SetActive(true);
                }
            }
        }
    }
    IEnumerator _FadeSound()
    {
        while (source.volume > 0.02f)
        {     
            source.volume -= .01f;
            yield return new WaitForSeconds(.05f);
        }
        source.volume = 0f;
        combatMusic.SetActive(false);
        yield return null;
    }
    IEnumerator SayLine()
    {
        SubtitleBox.SetActive(true);
        foreach(var line in lines)
        {
            SubtitleText.GetComponent<TextMeshProUGUI>().text = line;
            yield return new WaitForSeconds(5f);
        }
        SubtitleBox.SetActive(false);
        SubtitleText.GetComponent<TextMeshProUGUI>().text = "";
        gameObject.SetActive(false);

    }
}
