using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackScript : MonoBehaviour
{
    public int hitpoints = 10;
    public float ToTarget;
    public float range = 3.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Attack"))
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit) )
            {
                ToTarget = Mathf.Round(hit.distance * 100f) / 100f;
                if (ToTarget < range)
                {
                    hit.transform.SendMessage("DeductPoints", hitpoints, SendMessageOptions.DontRequireReceiver);
                }
            }
            else
            {
                ToTarget = 999f;
            }
        }
    }
}
