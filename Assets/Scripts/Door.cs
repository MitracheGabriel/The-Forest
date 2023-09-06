using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, InteractableItem
{
    public Animation animations;
    public AudioSource doorSound;
    public bool isOpen;
    public bool isMoving;

    void Start()
    {
        animations = GetComponent<Animation>();
    }
    public void Interact()
    {
        isMoving = true;

        if (isOpen)
        {
            StartCoroutine(ChangeStatus(false));
            doorSound.Play();
            animations.Play("DoorClose");
        }
        else
        {
            StartCoroutine(ChangeStatus(true));
            doorSound.Play();
            animations.Play("DoorOpen");
        }
    }
    IEnumerator ChangeStatus(bool status)
    {
        yield return new WaitForSeconds(.75f);
        isOpen = status;
        isMoving = false;
    }
}
