using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public interface IInteractable : IPointerUpHandler, IPointerMoveHandler, IPointerDownHandler
{
	public void OnPointerUp(PointerEventData eventData) { }
	public void OnPointerMove(PointerEventData eventData) { }

	public void OnPointerDown(PointerEventData eventData) { }
}
