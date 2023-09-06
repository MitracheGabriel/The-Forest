using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaveDoorOpen : MonoBehaviour
{
    public GameObject DoorSwing;
    public AudioSource KeySound;
    public AudioSource CreakSound;
    public GameObject TheKey;
    public GameObject ThisObject;
    
    void OnMouseOver()
    {
        StartCoroutine(DoorOpen());
    } 
    IEnumerator DoorOpen()
    {
        if (Input.GetButton("Interact"))
        {
            ThisObject.GetComponent<BoxCollider>().enabled = false;
            TheKey.SetActive(false);
            KeySound.Play();
            yield return new WaitForSeconds(1);
            CreakSound.Play();
            DoorSwing.GetComponent<Animator>().enabled = true;
            yield return new WaitForSeconds(1);
            DoorSwing.GetComponent<Animator>().enabled = false;
        }
    }
}
