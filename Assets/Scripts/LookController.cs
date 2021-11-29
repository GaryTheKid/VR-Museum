using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LookController : MonoBehaviour
{
    private EventController EC;

    [SerializeField] private float mouseSensitivity = 100f;
    [SerializeField] private Transform playerBody;
    [SerializeField] private Image crosshair;
    private float xRotation = 0f;
    private GameObject currHitObj;

    private void Awake()
    {
        EC = GameObject.Find("Player").GetComponent<EventController>();
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);

        // press "E" to pick up the item
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (currHitObj != null && currHitObj.CompareTag("Teleport"))
            {
                print("To the artifact story!");
                SceneManager.LoadScene(1);
            }    
        }

        // press esc to back to the museum scene
        if (Input.GetKeyDown(KeyCode.Escape) && SceneManager.GetActiveScene().buildIndex != 0)
        {
            SceneManager.LoadScene(0);
        }
    }

    // raycast
    private void FixedUpdate()
    {
        // layer (8): Artifact
        int layer = 8;
        RaycastHit hit;   

        // does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 3.5f))
        {
            if (hit.collider.gameObject != null && hit.collider.gameObject.layer == layer)
            {
                currHitObj = hit.collider.gameObject;
            }
            else
            {
                currHitObj = null;
            }
        }
    }
}