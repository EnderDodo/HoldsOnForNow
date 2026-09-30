using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class MouseController : MonoBehaviour
{
    [SerializeField] GameObject tileToMoveTo;
    Camera m_Camera;

    void Awake()
    {
        //subscribe to the event of clicking on a mouse (execute the OnClick method)

        m_Camera = Camera.main;
    }
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePosition = Input.mousePosition;
            Ray ray = m_Camera.ScreenPointToRay(mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                //if (hit.collider.Get)
            }
        }
    }

    void OnClick()
    {
        //trace a ray from a Camera to a Pointer

        //if it's not a Tile, don't do anything

        //make found Tile into the TileToMoveTo

        //move to the center of the TileToMoveTo

        //tile is no longer the TileToMoveTo
    }
}
