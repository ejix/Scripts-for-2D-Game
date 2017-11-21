using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoxCounter : MonoBehaviour {
    int numberOfPickups;
    public Text counterView;
    void Start() {
        ResetCounter();
    }

    public void IncrementCounter()
    {
        numberOfPickups++;
        counterView.text = numberOfPickups.ToString();
    }
    public void ResetCounter()
    {
        numberOfPickups = 0;
        counterView.text = numberOfPickups.ToString();
    }
}
