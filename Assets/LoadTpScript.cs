using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadTpScript : MonoBehaviour
{
    public Animator transition;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            GoToTheNextTp();
        
    }

    private void GoToTheNextTp()
    {
    }

}
