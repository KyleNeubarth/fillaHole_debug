using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour
{
    void Start() {
	    //This is unecessary, you have a cemera in both scenes
	    //DontDestroyOnLoad(this);
	    Screen.SetResolution(300,400,false);
    }
}
