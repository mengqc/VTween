using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VTween;

public class Move : MonoBehaviour {

	public Transform target;
	public AnimationCurve moveCurve;

	// Use this for initialization
	void Start () {
		new VTimeLine()
			.AddTween(gameObject, 2)
			.AddProp(new PositionModifier(target.transform.position, false, Vector3.up), Ease.Linear)
			.AddProp(new PositionModifier(target.transform.position, false, Vector3.right), Ease.Curve(moveCurve))
			.ListenComplete(OnTweenComplete)
			.TimeLine()
			.AddTween(gameObject, 1.5f)
			.AddProp(new ColorModifier(Color.red), EaseBack.EaseIn)
			.TimeLine()
			.ListenComplete(OnTimeLineComplete)
			.Start(gameObject);
	}

	private void OnTweenComplete() {
		Debug.Log("OnTweenComplete");
	}

	private void OnTimeLineComplete() {
		Debug.Log("OnTimeLineComplete");
	}

	// Update is called once per frame
	void Update () {
		
	}
}
