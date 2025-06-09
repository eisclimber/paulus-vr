using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_Wall : MonoBehaviour
{
 private int state;
    private int maxstate = 5;
    //private List<string> tasks = new List<string>();
    private List<Vector3> position = new List<Vector3>();
    //[SerializeField]
    //TMP_Text textcomponent;

    //time buffer to avoid double button click
    float delay = 0.1f;
    float tilldelayup = 0;

    //button counter
    int buttoncounter = 0;

    // Start is called before the first frame update
    void Start()
    {
        
        //tasks.Add("Teleport yourself onto the grey box. \n\nTo teleport onto the grey box, follow these steps:\n\n 1.Push and hold the thumbstick forward to initiate teleportation. \n2.A blue string will appear, forming a parabolic arc. \n3.Aim this arc towards the grey box. \n4.Release the thumbstick once you have aimed accurately.");
        position.Add(new Vector3(0, 1.50999999f, 0));
        //tasks.Add("Do it once again");
        position.Add(new Vector3(0, 1.50999999f, 4));
        //tasks.Add("Press the info button on the display case by moving the controller close enough to it.");
        position.Add(new Vector3(0, 1.50999999f, 5.9f));
        //tasks.Add("Close the info panel by pressing the button again.");
        position.Add(new Vector3(0, 1.50999999f, 5.9f));
        //tasks.Add("Grab the object by pressing and holding the 'Axis1D.PrimaryHandTrigger' button located on the back of the controller.");
        position.Add(new Vector3(0, 1.50999999f, 5.9f));
        position.Add(new Vector3(0, 1.50999999f, 5.9f));




        state = 0;

        //string[] tasks_arr = tasks.ToArray();
        Vector3[] position_arr = position.ToArray();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void changeState()
    {
        if (state == maxstate)
        {
            state = 0;
        }
        else
        {
            state = state + 1;
        }
        gameObject.transform.position = position[state];
        //textcomponent.text = tasks[state];

    }

    public void changeState_buttons()
    {
        if(Time.time >= tilldelayup && buttoncounter < 2)
        {
            buttoncounter += 1;
            state = state + 1;
            gameObject.transform.position = position[state];
            tilldelayup = Time.time + delay;
        }

    }
}
