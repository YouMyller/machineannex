using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerKiller : MonoBehaviour {

    private bool timerOn = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PathPoint" || other.gameObject.tag == "Waiting")
        {
            Destroy(other.gameObject);
            GetComponent<TriggerKiller>().enabled = false;
        }
    }
}
