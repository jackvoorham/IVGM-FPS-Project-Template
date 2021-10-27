using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script : MonoBehaviour
{     
    float speed = 3f;
    bool in_collider = false;
    public GameObject explosion_effect;
    public GameObject left_door;
    public GameObject right_door;
    public static bool has_bomb = false;
    bool planted = false;
    float timer_length = 1f;

    public Collider trigger_zone;
    public Collider door_collider;
    public float countdown = 3f;

    bool done = false;

    // Start is called before the first frame update
    void Start()
    {
    }


    // Update is called once per frame
    void Update()
    {
        if(!done){
            if(in_collider){
                if(has_bomb && !planted){
                    if (Input.GetKeyDown(KeyCode.E)){

                        planted = true;

                    }
                }
            }
        
            if(planted){
                countdown -= Time.deltaTime;
            }

            if(planted && countdown <= 0f){
                Instantiate(explosion_effect, transform.position, transform.rotation);
                done = true;
            }
        }
        else{
            has_bomb = false;
            Destroy(this.gameObject);        }
        }


    void OnTriggerEnter(Collider other)
    {
        in_collider = true;
    }

    void OnTriggerExit(Collider other) {
        in_collider = false;
    }

    void OnGUI()
    {
        if (in_collider && !planted)
        {

            if (has_bomb)
            {
                GUI.Box(new Rect((Screen.width-200)/2, (Screen.height-25)/2, 200, 25), "Press E to plant the bomb");
            }
        }
        if(planted && !done){
            GUI.Box(new Rect((Screen.width-200)/2, (Screen.height-25)/2, 200, 25), "Bomb timer: " + countdown.ToString());
        }
        
    }
}
