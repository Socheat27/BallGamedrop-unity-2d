using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Road : MonoBehaviour
{
    private void OnMouseDown()
    {
        MoveBall moveBallScript = FindObjectOfType<MoveBall>();
        if (gameObject.CompareTag("Road1"))
        {
            
            if (moveBallScript != null)
            {
                moveBallScript.MoveToObjectPosition(0);
            }
        }
        else if (gameObject.CompareTag("Road2"))
        {

            if (moveBallScript != null)
            {
                moveBallScript.MoveToObjectPosition(1);
            }
        }
        else if (gameObject.CompareTag("Road3"))
        {

            if (moveBallScript != null)
            {
                moveBallScript.MoveToObjectPosition(2);
            }
        }
    }

}
