using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    public class Quit : MonoBehaviour { 
        public void QuitButton()
        {
            Debug.Log("Game is exiting...");
            Application.Quit();
        }
    }    



