using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Modify : MonoBehaviour {

	private GameObject cameraGO;
	private int range = 10;

	/* Debug */
	public GameObject laserPrefab;
	/* Fin Debug */

	void Start(){
		cameraGO = GameObject.FindGameObjectWithTag("MainCamera");
	}

	void Update(){
		if(Input.GetMouseButtonDown(0)){
			//Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			Ray ray = new Ray(cameraGO.transform.position, cameraGO.transform.forward);
			RaycastHit hit;

			if (Physics.Raycast (ray, out hit)) {
				/* Debug */
				DrawLine(ray.origin, hit.point);
				/* Fin Debug */
	
				Edit.SetBlock(hit, new Air());
			}
		}
		if(Input.GetMouseButtonDown(1)){
			string content = System.IO.File.ReadAllText("D:\\Unity\\Minecraft\\Simple-Minecraft\\Logs\\Edit.log");
			System.IO.File.WriteAllText("D:\\Unity\\Minecraft\\Simple-Minecraft\\Logs\\Edit.log", content + System.Environment.NewLine + "-------------------------" );

			Ray ray = new Ray(cameraGO.transform.position, cameraGO.transform.forward);
			RaycastHit hit;

			if (Physics.Raycast (ray, out hit)) {
				/* Debug */
				DrawLine(ray.origin, hit.point);
				/* Fin Debug */

				Edit.AddBlock(hit, new Block());
			}
		}
	}

	/* Debug */
	void DrawLine(Vector3 targetPosition, Vector3 endPosition) {
		GameObject laser = Instantiate(laserPrefab, Vector3.zero, Quaternion.identity) as GameObject;
		LineRenderer laserLineRenderer = laser.GetComponent<LineRenderer>();
		laserLineRenderer.SetPosition(0, targetPosition);
		laserLineRenderer.SetPosition(1, endPosition);
		laserLineRenderer.enabled = true;
	}
	/* Fin Debug */
}
