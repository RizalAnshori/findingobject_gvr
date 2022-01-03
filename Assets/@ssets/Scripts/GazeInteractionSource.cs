using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class GazeInteractionSource : MonoBehaviour
{
    [SerializeField] private UnityEvent onFocusIntractable;
    [SerializeField] private UnityEvent onLoseFocus;
    [SerializeField] private UnityEvent onClick;
    [SerializeField] private float interactableDistance = 10;

    private GameObject gazedObj;
    private PointerEventData eventData;

    // Start is called before the first frame update
    void Start()
    {
        eventData = new PointerEventData(EventSystem.current);
    }

    // Update is called once per frame
    void Update()
    {
        UpdateInteraction();
    }

    private void UpdateInteraction()
    {
        if (Physics.Raycast(transform.position, transform.forward, out var hit, interactableDistance))
        {
            if (gazedObj != hit.transform.gameObject)
            {
                if (gazedObj)
                {
                    gazedObj.GetComponent<IPointerExitHandler>()?.OnPointerExit(eventData);

                    if (IsGazedObjectIntractable())
                        onLoseFocus?.Invoke();

                }
                gazedObj = hit.transform.gameObject;
                gazedObj.GetComponent<IPointerEnterHandler>()?.OnPointerEnter(eventData);

                if (IsGazedObjectIntractable())
                    onFocusIntractable?.Invoke();
            }
        }
        else if (gazedObj)
        {
            gazedObj.GetComponent<IPointerExitHandler>()?.OnPointerExit(eventData);
            gazedObj = null;
        }

        if (gazedObj != null && Google.XR.Cardboard.Api.IsTriggerPressed)
        {
            var clickHandler = gazedObj.GetComponentInParent<IPointerClickHandler>();

            if (clickHandler != null)
            {
                eventData.pointerPressRaycast = new RaycastResult { worldPosition = hit.point };
                clickHandler.OnPointerClick(eventData);
            }

            if (IsGazedObjectIntractable())
            {
                onClick?.Invoke();
            }
        }
    }

    private bool IsGazedObjectIntractable()
    {
        return gazedObj.GetComponent<IEventSystemHandler>() != null;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawLine(transform.position, new Vector3(transform.position.x, transform.position.y, transform.position.z + interactableDistance));
    }
}
