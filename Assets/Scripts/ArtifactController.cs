using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtifactController : MonoBehaviour
{
    public Transform player;

    [SerializeField] private GameObject menu;

    public void ShowMenu() 
    {
        menu.SetActive(true);
    }

    public void HideMenu() 
    {
        menu.SetActive(false);
    }

    private void Update()
    {
        if (menu.activeSelf)
        {
            menu.transform.LookAt(player);
        }
    }
}
