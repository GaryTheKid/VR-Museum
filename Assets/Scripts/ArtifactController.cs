using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtifactController : MonoBehaviour
{
    public Transform player;

    [SerializeField] private GameObject menu;
    private Color menuColor;

    public void ShowMenu()
    {
        StartCoroutine(ShowMenu_Coroutine());
    }

    public void HideMenu() 
    {
        StartCoroutine(HideMenu_Coroutine());
    }

    IEnumerator ShowMenu_Coroutine()
    {
        menu.SetActive(true);
        while (menuColor.a < 1)
        {
            menuColor = new Color(menuColor.r, menuColor.b, menuColor.g, menuColor.a + Time.deltaTime);
            menu.GetComponent<MeshRenderer>().material.color = menuColor;
            yield return new WaitForEndOfFrame();
        }
    }

    IEnumerator HideMenu_Coroutine()
    {
        while (menuColor.a >= 0)
        {
            menuColor = new Color(menuColor.r, menuColor.b, menuColor.g, menuColor.a - Time.deltaTime);
            menu.GetComponent<MeshRenderer>().material.color = menuColor;
            yield return new WaitForEndOfFrame();
        }
        menu.SetActive(false);
    }

    private void Start()
    {
        menuColor = menu.GetComponent<MeshRenderer>().material.color;
        print(menuColor);
    }

    private void Update()
    {
        if (menu.activeSelf)
        {
            menu.transform.LookAt(player);
            menu.transform.localEulerAngles = new Vector3(0f, menu.transform.localEulerAngles.y, 0f);
        }
    }
}
