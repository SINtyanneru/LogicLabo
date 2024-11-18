using System;
using UnityEngine;

public class Manager : MonoBehaviour {
	[SerializeField]
	public GameObject Cursor;
	public GameObject BUTTON;

	void Start() {
		
	}

	void Update() {
		Vector3 MOUSE_POS = Camera.main.ScreenToWorldPoint(Input.mousePosition);

		//座標をいい感じにする
		MOUSE_POS.x = 0.5f + (float)Math.Floor(MOUSE_POS.x);
		MOUSE_POS.y = 0.5f + (float)Math.Floor(MOUSE_POS.y);
		MOUSE_POS.z = 0;

		//座標がマイナスなら死ぬ
		if (MOUSE_POS.x >= 0 && MOUSE_POS.y >= 0) {
			//カーソル
			Cursor.transform.position = MOUSE_POS;

			if (Input.GetMouseButtonDown(0)) {
				GameObject INSTANCE = Instantiate(BUTTON);
				INSTANCE.transform.position = MOUSE_POS;
			}
		}

		CameraMove();
		CameraZoom();
	}

	private void CameraMove() {
		//カメラ移動
		if (Input.GetMouseButton(2)) {
			Camera.main.transform.position = new Vector3(
				Camera.main.transform.position.x + (Input.mousePositionDelta.x * -1) / 10,
				Camera.main.transform.position.y + (Input.mousePositionDelta.y * -1) / 10,
				-10
			);
		}

		//移動中はカーソルを非表示に
		if (Input.GetMouseButtonDown(2)) {
			Cursor.gameObject.SetActive(false);
		}

		//移動完了後にカーソルを表示
		if (Input.GetMouseButtonUp(2)) {
			Cursor.gameObject.SetActive(true);
		}
	}

	private void CameraZoom() {
		float SCROLL = Input.mouseScrollDelta.y * Time.deltaTime * 10;

		if (SCROLL != 0) {
			Camera.main.orthographicSize += SCROLL * -1;
		}
	}
}
