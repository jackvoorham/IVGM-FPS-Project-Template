using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bomb : MonoBehaviour
{
    public Component bomb_collider;
    bool in_trigger = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(in_trigger){
            if (Input.GetKeyDown(KeyCode.E))
            {
                script.has_bomb = true;
                Destroy(this.gameObject);
            }
        }
    }

    void OnTriggerEnter(Collider other){
        Debug.Log("Hello");
        in_trigger = true;
    }

    void OnTriggerExit(Collider other){
        in_trigger = false;
    }

    void OnGUI()
    {
        if (in_trigger && !script.has_bomb)
        {
            GUI.Box(new Rect((Screen.width-200)/2, (Screen.height-25)/2, 200, 25), "Press E to pick up bomb");
        } 
    }
}

