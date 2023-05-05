using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] private GameObject arrowPrefab;
    [SerializeField] private Transform shotPoint;
    [SerializeField] private GameObject vcamNotAiming;
    [SerializeField] private Transform camRoot;

    private bool isReadyToShoot = false;
    private bool isStretching = false;
    public bool IsReadyToShoot { get { return isReadyToShoot; } }
    public bool IsStretching { get { return isStretching; } }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        vcamNotAiming.SetActive(!Input.GetMouseButton(0));

        if (Input.GetMouseButtonDown(0))
        {
            if(isReadyToShoot == false)
            {
                StartCoroutine(StretchTheBowstring());
            }
        }

        if(Input.GetMouseButtonUp(0) && isReadyToShoot)
        {
            GameObject arrow = Instantiate(arrowPrefab, shotPoint.position, Quaternion.Euler(camRoot.localEulerAngles.x + 90, transform.localEulerAngles.y, shotPoint.rotation.z));

            isReadyToShoot = false;
        }
    }

    private IEnumerator StretchTheBowstring()
    {
        isStretching = true;
        yield return new WaitForSeconds(1.5f);
        isStretching = false;
        isReadyToShoot = true;
    }
}
