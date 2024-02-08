using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecretCodeResolve : MonoBehaviour
{
    public List<CodeLineScript> Lines = new List<CodeLineScript>(); 
    private int lineNumber=0;

    public delegate void EventHandler(GameObject current);

    public static event EventHandler OnReset;

    public delegate void EventHandlerResolved();

    public static event EventHandlerResolved OnResolved;

    void Start()
    {
        // Step 5: Subscribe to the event in another script
        CodeLineScript.OnFinish += OnPuzzleLineResolve;
        //Crank.CrankEvent += OnCrankCranked;
        Lines[lineNumber].enabled = true;
        Debug.Log("isactivate");
    }

    private void OnCrankCranked()
    {
        Lines[lineNumber].enabled = true;
    }

    private void OnPuzzleLineResolve(bool correct)
    {
        if (correct)
        {
            Debug.Log("YouRs DId iT*");
            OnResolved();


        }
        else
        {
            if (lineNumber+1 == Lines.Count)
            {
                CodeLineScript.OnFinish -= OnPuzzleLineResolve;
                OnReset(gameObject);
            }
            else
            {
                int count = 0;
                foreach (Transform child in Lines[lineNumber].transform)
                {
                    Lines[lineNumber + 1].gameObject.transform.GetChild(count).GetComponent<PedestalStatus>().CorrectGem = child.gameObject.GetComponent<PedestalStatus>().CorrectGem;
                    count++;

                }
                lineNumber++;
                Debug.Log("THELINENUMBERIS" + lineNumber);
                Debug.Log("THELINECOUNTIS" + Lines.Count);
              
                Lines[lineNumber].enabled = true;

                
            }

            Debug.Log("incorrect code");

        }
    }



    void OnDestroy()
    {
        // Step 7: Unsubscribe when the subscriber is destroyed to prevent memory leaks
        CodeLineScript.OnFinish -= OnPuzzleLineResolve;
    }



}
