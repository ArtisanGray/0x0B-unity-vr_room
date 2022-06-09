using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class TeleportationHandle : MonoBehaviour
{
    public InputActionAsset actionAsset;
    public XRRayInteractor rayInteractor;
    public TeleportationProvider provider;
    public InputAction _thumbstick;
    private InputAction _activate;
    private InputAction _cancel;
    private bool _isActive;
    public GameObject safe;

    // Start is called before the first frame update
    void Start()
    {
        rayInteractor.enabled = false;

        _activate = actionAsset.FindActionMap("XRI LeftHand Locomotion").FindAction("Teleport Mode Activate");
        _activate.Enable();
        _activate.performed += OnTeleportActivate;
        var cancel = actionAsset.FindActionMap("XRI LeftHand Locomotion").FindAction("Teleport Mode Cancel");
        cancel.Enable();
        cancel.performed += OnTeleportCancel;
        _thumbstick = actionAsset.FindActionMap("XRI LeftHand Locomotion").FindAction("Move");
        _thumbstick.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        if (!_isActive)
        {
            return;
        }
        if (_thumbstick.triggered)
        {
            return;
        }

        if (!rayInteractor.TryGetCurrent3DRaycastHit(out RaycastHit hit) || !safe.GetComponent<isHit>().safeTeleport)
        {
            rayInteractor.enabled = false;
            _isActive = false;
            
            return;
        }
        if (hit.collider.gameObject.layer == 6) //detects if raycast hit the right interaction layer.
        {
            TeleportRequest request = new TeleportRequest()
            {
                destinationPosition = hit.point,
                //destinationRotation
            };
            provider.QueueTeleportRequest(request);
            rayInteractor.enabled = false;
            _isActive = false;
        }
    }
    private void OnTeleportActivate(InputAction.CallbackContext context)
    {
        if (!_isActive)
        {
            rayInteractor.enabled = true;
            _isActive = true;
        }
    }
    private void OnTeleportCancel(InputAction.CallbackContext context)
    {
        if (_isActive && rayInteractor.enabled == true)
        {
            rayInteractor.enabled = false;
            _isActive = false;
        }
    }
}
