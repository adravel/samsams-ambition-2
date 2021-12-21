using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public PlayerMovement playerMovement;
    public GameObject questionMark;

    private Vector3 previousDirection = Vector3.zero;
    private int layerMask;
    private Transform interactable = null;

    private void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
    }

    void Start()
    {
        layerMask = LayerMask.GetMask("Interactable");
        questionMark.SetActive(false);
    }

    void FixedUpdate()
    {
        // Check whether the player is facing interactable object
        CheckInteraction();
    }

    private void Update()
    {
        // Interact with the interactable object
        if (interactable != null && Input.GetKeyDown(KeyCode.F))
            interactable.GetComponent<Interactable>().Interact();
    }

    private void CheckInteraction()
    {
        // Determine raycast direction
        Vector3 direction = new Vector2(playerMovement.change.x, playerMovement.change.y);
        if (direction == Vector3.zero)
            direction = previousDirection;
        else
            previousDirection = direction;

        // Raycasting
        // Debug.DrawRay(transform.position + direction * 0.25f, direction * 0.5f, Color.white);
        RaycastHit2D hit = Physics2D.Raycast(transform.position + direction * 0.25f, direction, 0.5f, layerMask);

        // Show question mark if raycast hit an object
        if (hit)
        {
            interactable = hit.transform;
            questionMark.SetActive(true);
            // Debug.Log("You found a collectable item!");
        }
        else
        {
            interactable = null;
            questionMark.SetActive(false);
            // Debug.Log("No collectable item found.");
        }
    }
}
