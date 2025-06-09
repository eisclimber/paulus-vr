using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Video;

public class Video_text_update : MonoBehaviour
{
    private int state;
    private int maxstate = 6;
    private List<string> tasks = new List<string>();
    private List<Vector3> position = new List<Vector3>();
    [SerializeField]
    TMP_Text textcomponent;
    [SerializeField]
    private GameObject vid_obj;

    [SerializeField]
    private VideoPlayer vid;
    [SerializeField]
    private VideoClip teleportclip;
    [SerializeField]
    private VideoClip buttonclip;
    [SerializeField]
    private VideoClip grabclip;
    [SerializeField]
    private VideoClip turn_throwclip;
    [SerializeField]
    private Sprite img;



    //time buffer to avoid double button click
    float delay = 0.1f;
    float tilldelayup = 0;

    //button counter
    int buttoncounter = 0;

    // Start is called before the first frame update
    void Start()
    {

        tasks.Add("Teleport yourself onto the grey box");
        position.Add(new Vector3(0, 1.50999999f, 0));
        tasks.Add("Do it once again");
        position.Add(new Vector3(0, 1.50999999f, 4));
        tasks.Add("Press the info button on the display");
        position.Add(new Vector3(0, 1.50999999f, 5.9f));
        tasks.Add("Press the button again.");
        position.Add(new Vector3(0, 1.50999999f, 5.9f));
        tasks.Add("Grab the object");
        position.Add(new Vector3(0, 1.50999999f, 5.9f));
        tasks.Add("Examine the object and throw it away");
        position.Add(new Vector3(0, 1.50999999f, 5.9f));
        tasks.Add("Thanks for participating in this Tutorial!");
        position.Add(new Vector3(0, 1.50999999f, 5.9f));







        state = 0;

        string[] tasks_arr = tasks.ToArray();
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
            vid_obj.gameObject.SetActive(false);
        }
        //second teleport
        else if(state == 1)
        {
            state = state + 1;
            gameObject.transform.position = position[state];
            textcomponent.text = tasks[state];
            vid.clip = buttonclip;

        }
        //button click 2,3
        else if(state == 2 || state == 3)
        {
            state = state + 1;
            gameObject.transform.position = position[state];
            textcomponent.text = tasks[state];
            vid.clip = buttonclip;
        }
        //grab done
        else if(state == 4)
        {
            state = state + 1;
            gameObject.transform.position = position[state];
            textcomponent.text = tasks[state];
            vid.clip = turn_throwclip;
        }
        else if (state == 5)
        {
            state = state + 1;
            gameObject.transform.position = position[state];
            textcomponent.text = tasks[state];
            textcomponent.alignment = TextAlignmentOptions.Center;
            vid_obj.gameObject.SetActive(false);
        }
        else
        {
            state = state + 1;
            gameObject.transform.position = position[state];
            textcomponent.text = tasks[state];
        }
    }

    public void changeState_button()
    {
        if (Time.time >= tilldelayup && buttoncounter < 2)
        {
            buttoncounter += 1;
            state = state + 1;
            gameObject.transform.position = position[state];
            textcomponent.text = tasks[state];
            tilldelayup = Time.time + delay;
            if(buttoncounter == 2)
            {
                vid.clip = grabclip;
            }
        }
    }
}
