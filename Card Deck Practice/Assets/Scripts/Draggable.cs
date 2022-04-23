using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;

public class Draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{

	public Transform parentToReturnTo = null;
	public Transform placeholderParent = null;

	GameObject placeholder = null;
	public GameObject queueZone;

	public static bool staticIntoPlay;
	public bool intoPlay = false;

	void Start()
	{
		queueZone = GameObject.Find("Dropzone");
	}

	public void OnBeginDrag(PointerEventData eventData)
	{
		Debug.Log("OnBeginDrag");

		placeholder = new GameObject();
		placeholder.transform.SetParent(this.transform.parent);
		LayoutElement le = placeholder.AddComponent<LayoutElement>();
		le.preferredWidth = this.GetComponent<LayoutElement>().preferredWidth;
		le.preferredHeight = this.GetComponent<LayoutElement>().preferredHeight;
		le.flexibleWidth = 0;
		le.flexibleHeight = 0;

		placeholder.transform.SetSiblingIndex(this.transform.GetSiblingIndex());

		parentToReturnTo = this.transform.parent;
		placeholderParent = parentToReturnTo;
		this.transform.SetParent(this.transform.parent.parent);

		GetComponent<CanvasGroup>().blocksRaycasts = false;

		//	gameObject.GetComponent<BezierArrows>().enabled = true;
	}

	public void OnDrag(PointerEventData eventData)
	{
		//Debug.Log ("OnDrag");

		intoPlay = staticIntoPlay;

		if (intoPlay == true)
		{
			this.transform.position = queueZone.transform.position;
			if (gameObject.GetComponent<BezierArrows>().enabled == false)
				gameObject.GetComponent<BezierArrows>().enabled = true;
		}
		else
		{
			this.transform.position = eventData.position;
			gameObject.GetComponent<BezierArrows>().test = true;
		}



		if (placeholder.transform.parent != placeholderParent)
			placeholder.transform.SetParent(placeholderParent);

		int newSiblingIndex = placeholderParent.childCount;

		for (int i = 0; i < placeholderParent.childCount; i++)
		{
			if (this.transform.position.x < placeholderParent.GetChild(i).position.x)
			{

				newSiblingIndex = i;

				if (placeholder.transform.GetSiblingIndex() < newSiblingIndex)
					newSiblingIndex--;

				break;
			}
		}

		placeholder.transform.SetSiblingIndex(newSiblingIndex);

	}

	public void OnEndDrag(PointerEventData eventData)
	{
		Debug.Log("OnEndDrag");

		//gameObject.GetComponent<BezierArrows>().enabled = true;
		//gameObject.GetComponent<BezierArrows>().enabled = false;

		this.transform.SetParent(parentToReturnTo);
		this.transform.SetSiblingIndex(placeholder.transform.GetSiblingIndex());
		//GetComponent<CanvasGroup>().blocksRaycasts = true;

		Destroy(placeholder);

	}

	public void DragIntoPlay()
	{
		staticIntoPlay = true;
	}

	public void DragOutOfPlay()
	{
		staticIntoPlay = false;
	}


}