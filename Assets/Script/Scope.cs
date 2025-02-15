using System.Collections;
using TMPro.Examples;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.InputSystem;

public class Scope : MonoBehaviour
{

    [Header("Cursor Settings")]
    public bool lockCursor = true;
    public bool hideCursor = true;
    public LookAround lookAround;

    [Header("Scope Settings")]
    public float transitionSpeed = 5f;
    public GameObject scopeOverlay;
    public GameObject weaponCamera;
    public float timeToOverlay;
    public float scopFov = 15f;
    public float minFov = 10f;
    public float maxFov = 40f;

    private bool isScoped = false;
    private Animator anim;
    private InputSystem_Actions input;

    private void Awake()
    {
        input = new InputSystem_Actions();
        input.Enable();
    }
    void Start()
    {
        ConfigureCursor();
        anim = GetComponent<Animator>();
        lookAround.SetFieldOfView(lookAround.GetNormalFov());
    }

    void Update()
    {
        lookAround.PlayerLook(lookAround.mainCamera);

        input.Player.Scope.performed += gtx => ToggleScope();
        if (isScoped)
        {
            HandleZoom();
        }

    }

    void ToggleScope()
    {
        isScoped = !isScoped;
        anim.SetBool("Scoped", isScoped);

        if (isScoped)
        {
            Cursor.lockState = CursorLockMode.Locked;
            StartCoroutine(OnScoped());
        }
        else
        {
            OnUnScoped();
        }
    }

    void ConfigureCursor()
    {
        if (lockCursor)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
        }

        Cursor.visible = !hideCursor;
    }

    void OnUnScoped()
    {
        scopeOverlay.SetActive(false);
        weaponCamera.SetActive(true);
        lookAround.SetFieldOfView(lookAround.GetNormalFov());
    }

    IEnumerator OnScoped()
    {
        yield return new WaitForSeconds(timeToOverlay);
        scopeOverlay.SetActive(true);
        weaponCamera.SetActive(false);
        lookAround.SetFieldOfView(scopFov);
    }

    void HandleZoom()
    {
        float scrollInput = Input.GetAxis("Mouse ScrollWheel");
        if (scrollInput != 0f)
        {
            // Mengubah FOV
            float newFov = lookAround.mainCamera.fieldOfView - scrollInput * 10f;
            newFov = Mathf.Clamp(newFov, minFov, maxFov);
            lookAround.SetFieldOfView(newFov);
        }
    }
    void OnDisable()
    {
        input.Disable();
    }
}