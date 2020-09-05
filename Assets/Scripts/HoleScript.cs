using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleScript : MonoBehaviour {

    public KeyCode holeKey;
    
    //boolean -> bool
    private bool filled;
    private bool interactable;

    private SpriteRenderer sr;
    
    // Start is called before the first frame update
    void Start()
    {
        //SpiteRenderer -? SpriteRenderer
        sr = GetComponent<SpriteRenderer>();
        sr.color = Color.black;
        filled = true;
        interactable = false;

        // Start at a random time
        float startTime = Random.Range(3.0f, 5.0f);
        InvokeRepeating("HoleControl", startTime, 1);
    }

    // Update is called once per frame
    void Update(){
        
        if(interactable){
            if (Input.GetKeyDown(holeKey)) {
                interactable = false;
                StopCoroutine("Open");
                //semicolon pls
                Score();
                Fill();
            }
        }
    }

    private void HoleControl() {
        // Am I a filled hole
        if (filled) {
        // If so, what should we do with you
            int doWeOpen = Random.Range(0, 10);
            // Am I spawning?
            if (doWeOpen < 2) {
                // Open that hole!
                //Open isn't a reference, use a string instead
                StartCoroutine("Open");
            }
        }
    }

    private IEnumerator Open() {
        //class vars are lowercase dingus
        sr.color = Color.white;
        filled = false;
        interactable = true;
        yield return new WaitForSeconds(2);
        // Are we still unfilled?
        if (!filled) {
            // Oh no! You took too long
            interactable = false;
            //The fact that this text gets underlined in red is hilarious
            //I love it
            sr.color = Color.red;
            AudioControl.S.PlayMiss();
            ScoreScript.S.DecreaseScore();
            yield return new WaitForSeconds(1);
            Fill();
        }

        yield return null;
    }

    private void Score() {
        //replaced lame sound with a better one
        //AudioControl.S.PlayFill();
        Instantiate(Resources.Load("Explosion"),transform.position,Quaternion.identity);
        ScoreScript.S.IncreaseScore();
    }

    private void Fill() {
        sr.color = Color.black;
        interactable = false;
        //Changed == operator to = assignment
        filled = true;
    }
} 
