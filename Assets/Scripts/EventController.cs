using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 8)
        {
            other.gameObject.GetComponent<ArtifactController>().player = gameObject.transform;
            other.gameObject.GetComponent<ArtifactController>().ShowMenu();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 8)
        {
            other.gameObject.GetComponent<ArtifactController>().player = gameObject.transform;
            other.gameObject.GetComponent<ArtifactController>().HideMenu();
        }
    }
}
