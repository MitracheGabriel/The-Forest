using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntranceLever : MonoBehaviour
{
    public float TheDistance = 999f;
    public GameObject TheLever;
    public AudioSource LeverSound;
    public GameObject Ledge;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        TheDistance = PlayerCasting.DistanceFromTarget;
    }
    void OnMouseOver()
    {
        if(TheDistance <=3 && Input.GetButton("Interact"))
        {
            GetComponent<BoxCollider>().enabled = false;
            TheLever.GetComponent<Animation>().Play("EntranceAnim");
            LeverSound.Play();
            Ledge.GetComponent<Animation>().Play("LedgeAnim");
        }
    }
}
