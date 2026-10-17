using UnityEngine;
using UnityEngine.InputSystem;

public class MouseController : MonoBehaviour
{
    [SerializeField] GameObject tileToMoveTo;
    [SerializeField] GameObject tileToFold;
    [SerializeField] float movementSpeed;
    [SerializeField] float movementRange;
    [SerializeField] float rotationSpeed;
    private Vector3 targetCoords;

    private Camera m_Camera;
    private Transform _transform;
    private PlayerInputActions playerInputActions;


    void Awake()
    {
        //subscribe to the event of clicking on a mouse (execute the OnClick method)

        m_Camera = Camera.main;

        _transform = transform;

        playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Enable();
        playerInputActions.Player.Move.performed += Move;
        playerInputActions.Player.SelectTile.performed += SelectTile;
    }

    private void Move(InputAction.CallbackContext context)
    {
        var tapPos = context.ReadValue<Vector2>();
        Debug.Log(tapPos);
        Debug.Log(m_Camera.transform.position);
        Ray ray = m_Camera.ScreenPointToRay(tapPos);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            if (hit.transform != null)
                if ((hit.transform.position - _transform.position).magnitude < movementRange)
                {
                    targetCoords = hit.transform.position;
                    tileToMoveTo = hit.transform.gameObject;
                    //_transform.rotation = Quaternion.Slerp(_transform.rotation, hit.transform.rotation, rotationSpeed); //still doesnt work lol
                }
        }
    }
    private void SelectTile(InputAction.CallbackContext context)
    {
        var tapPos = context.ReadValue<Vector2>();
        Debug.Log(tapPos);
        Debug.Log(m_Camera.transform.position);
        Ray ray = m_Camera.ScreenPointToRay(tapPos);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            if (hit.transform != null)
            {
                tileToFold = hit.transform.gameObject;
                playerInputActions.Folding.Enable();
            }

        }


    }

    void Update()
    {

        if (targetCoords - _transform.position != Vector3.zero) //remake movement so an if operator wasn't called on Update.
        {
            _transform.Translate(targetCoords - _transform.position);
        }
    }

    private void OnDisable()
    {
        playerInputActions.Player.Disable();
    }

}
