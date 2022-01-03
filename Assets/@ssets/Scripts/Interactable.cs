using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Interactable : MonoBehaviour
{
    protected EventTrigger eventTrigger;

    protected virtual void Start()
    {
        AddBasicListener();
    }

    private void AddBasicListener()
    {
        var pointerClickEntry = new EventTrigger.Entry();
        pointerClickEntry.eventID = EventTriggerType.PointerClick;
        pointerClickEntry.callback.AddListener(data => { OnClick(); });

        var pointerEnterEntry = new EventTrigger.Entry();
        pointerEnterEntry.eventID = EventTriggerType.PointerEnter;
        pointerEnterEntry.callback.AddListener(data => { OnEnter(); });

        var pointerExitEntry = new EventTrigger.Entry();
        pointerExitEntry.eventID = EventTriggerType.PointerExit;
        pointerExitEntry.callback.AddListener(data => { OnExit(); });

        eventTrigger.triggers.Add(pointerClickEntry);
        eventTrigger.triggers.Add(pointerEnterEntry);
        eventTrigger.triggers.Add(pointerExitEntry);
    }

    public virtual void OnClick()
    {

    }

    public virtual void OnEnter()
    {

    }

    public virtual void OnExit()
    {

    }

    public void SetScale(float targetScale = 1)
    {
        this.transform.localScale = new Vector3(targetScale, targetScale, targetScale);
    }
}
