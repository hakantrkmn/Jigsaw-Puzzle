using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class ItemBase : MonoBehaviour, IInteractable
{
	public abstract void PlaceItemOnPos();
	public void OnPointerUp(PointerEventData eventData) { }
	public void OnPointerMove(PointerEventData eventData) { }
	public void OnPointerDown(PointerEventData eventData) { }
}
