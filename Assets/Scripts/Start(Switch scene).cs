using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Sceneswit : MonoBehaviour
{
    public int sceneid;
    public void GoToSampleScene(){
        SceneManager.LoadScene(sceneid);
    }
    public void GoToSampleScene(int scenid )
    {
        SceneManager.LoadScene(scenid);
    }
}



