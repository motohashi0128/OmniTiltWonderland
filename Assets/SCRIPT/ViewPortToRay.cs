using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ViewPortToRay : MonoBehaviour
{

	public Camera targetCamera; // 映っているか判定するカメラへの参照

	[SerializeField]
	Transform targetObj; // 映っているか判定する対象への参照。inspectorで指定する

	public List<GameObject> aguyoshis = new List<GameObject>();


	// Use this for initialization
	void Start()
	{

	}

	void Update()
	{
		if (targetCamera.isActiveAndEnabled)
		{
			for (int i = 0; i < 12; i++)
			{
				for (int j = 0; j < 12; j++)
				{
					float posx = i / 12.0f;
					float posy = j / 12.0f;

					Ray ray = targetCamera.ViewportPointToRay(new Vector3(posx, posy, 0));
					RaycastHit hit;
					Debug.DrawRay(targetCamera.transform.position, ray.direction, Color.red);

					if (Physics.Raycast(ray, out hit, 20f))
					{

						for (int k = 0; k < aguyoshis.Count; k++)
                        {
							if(hit.transform.name == aguyoshis[k].transform.name)
                            {
								aguyoshis[k].GetComponent<camera_visible>()._visible = true;

							}
                        }

					}
				}
			}
		}

		
		

		
	}
	



}