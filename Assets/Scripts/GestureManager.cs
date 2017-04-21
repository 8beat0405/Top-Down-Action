using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GestureManager : MonoBehaviour {

	private float _startPos = 0;
	private float _endPos = 0;

	private int _dragCnt = 0;

	[SerializeField]
	private Image _egg = null;

	[SerializeField]
	private Image _mirum = null;

	[SerializeField]
	private Text _text = null;


	void Start () {

	}

	/// <summary>
	/// ドラッグ開始ポジション取得処理
	/// </summary>
	/// <param name="eventData">Event data.</param>
	public void OnBeginDrag(PointerEventData eventData)
	{
		_startPos = eventData.position.y;
		_text.text = "Drag done";
	}

	/// <summary>
	/// ドラッグ終了時取得処理
	/// </summary>
	/// <param name="eventData">Event data.</param>
	public void OnEndDrag(PointerEventData eventData)
	{
		_endPos = eventData.position.y;

		if(Mathf.Abs(_startPos - _endPos) > 10)
		{
			_dragCnt ++;
		}

		if(_dragCnt >= 5)
		{
			_text.text = "卵が孵りそうです。。。";

			// 卵オブジェクトを削除
			//Destroy(_egg.gameObject);
		}
	}

	/// <summary>
	/// オーバーライドしないとIDragHandlerを実装しているためエラーが出る
	/// </summary>
	/// <param name="eventData">Event data.</param>
	public void OnDrag(PointerEventData eventData){}
}
