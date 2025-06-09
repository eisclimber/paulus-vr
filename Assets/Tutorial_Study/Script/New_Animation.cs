using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class New_Animation : MonoBehaviour
{
    [SerializeField]
    Animator animator;
    private int maxstate = 5;

    private int state;
    private List<Vector3> position = new List<Vector3>();

    [SerializeField]
    TMP_Text textcomponent;

    [SerializeField]
    GameObject grab;
    [SerializeField]
    GameObject click;
    [SerializeField]
    GameObject throw_;



    //time buffer to avoid double button click
    float delay = 0.1f;
    float tilldelayup = 0;

    //button counter
    int buttoncounter = 0;


    // Start is called before the first frame update
    void Start()
    {
        state = 0;
        position.Add(new Vector3(0.261999995f, 1, -4.651f)); 
        position.Add(new Vector3(0.261999995f, 1, -1.15999997f));
        position.Add(new Vector3(1f, 0.721000016f, 2.47900009f));
        position.Add(new Vector3(1f, 0.721000016f, 2.47900009f));
        position.Add(new Vector3(0.8f, 0.930000007f, 3.8f));
        position.Add(new Vector3(0.8f, 1.2f, 3.8f));


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void change_animation_position()
    {
        if (state == maxstate)
        {
            transform.position = position[0];
            textcomponent.gameObject.SetActive(true);
            click.SetActive(false);
            grab.SetActive(false);
            throw_.SetActive(false);
            gameObject.SetActive(false);
        }
        else if (state == 1 || state == 2)
        {
            state = state + 1;
            animator.SetInteger("State", state);
            transform.position = position[state];
            click.SetActive(true);
        }
        else if (state == 3)
        {
            click.SetActive(false);
            state = state + 1;
            animator.SetInteger("State", state);
            transform.position = position[state];
            grab.SetActive(true);
        }
        else if( state == 4)
        {
            click.SetActive(false);
            grab.SetActive(false);
            state = state + 1;
            animator.SetInteger("State", state);
            transform.position = position[state];
            throw_.SetActive(true);
        }
        else 
        {
            click.SetActive(false);
            grab.SetActive(false);
            throw_.SetActive(false);
            state = state + 1;
            animator.SetInteger("State", state);
            transform.position = position[state];
        }
    }

    public void change_animation_position_buttons()
    {
        if (Time.time >= tilldelayup && buttoncounter < 2)
        {
            
            state = state + 1;
            animator.SetInteger("State", state);
            transform.position = position[state];
            tilldelayup = Time.time + delay;
            if(buttoncounter > 0)
            {
                click.SetActive(false);
                grab.SetActive(true);
            }
            buttoncounter += 1;

        }
    }
}
