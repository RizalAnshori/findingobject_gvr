using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

public class NavigationController : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private NavMeshAgent playerNavMeshAgent;

    public void OnPointerClick(PointerEventData eventData)
    {
        playerNavMeshAgent.SetDestination(eventData.pointerPressRaycast.worldPosition);
    }
}
