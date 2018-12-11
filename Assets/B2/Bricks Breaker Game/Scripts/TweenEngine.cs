using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TweenEngine : MonoBehaviour {
	public GameObject posHolder;
	public System.Enum enumerator;
	public enum fromDirection {
		fromTop,
		fromButtom,
		fromLeft,
		fromRight,
	};
	//show in inspector
	public fromDirection direction;
	public float endVal;
	public float tim =  0.75f;
	// Use this for initialization
	void Start () {
		if (direction == fromDirection.fromTop) {
			if (posHolder) {
				endVal = posHolder.transform.localPosition.y;
			}
			gameObject.transform.DOLocalMoveY (endVal, tim, true).SetEase (Ease.InOutBounce).OnComplete (_onComplete);
		}
		if (direction == fromDirection.fromButtom) {
			if (posHolder) {
				endVal = posHolder.transform.localPosition.y;
			}
			gameObject.transform.DOLocalMoveY (endVal, tim, true).SetEase (Ease.InOutBounce).OnComplete (_onComplete);
		}
		if (direction == fromDirection.fromLeft) {
			if (posHolder) {
				endVal = posHolder.transform.localPosition.x;
			}
			gameObject.transform.DOLocalMoveX(endVal, tim, true).SetEase (Ease.InOutBounce).OnComplete (_onComplete);
		}
		if (direction == fromDirection.fromRight) {
			if (posHolder) {
				endVal = posHolder.transform.localPosition.x;
			}
			gameObject.transform.DOLocalMoveX (endVal, tim, true).SetEase (Ease.InOutBounce).OnComplete (_onComplete);
		}
		//gameObject.transform.DOPunchPosition (new Vector3(0,-300f,0), 1f,10,1,true);
	}
	void _onComplete(){
		///Debug.Log ("---complete");
		//gameObject.transform.DOPunchPosition (new Vector3 (0, gameObject.transform.position.y), 0.5f,10,0,true);
	}

}
