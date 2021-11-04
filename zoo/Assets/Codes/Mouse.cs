using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse : MonoBehaviour
{
	public GameObject Cursor;
	
	Vector3 LastPosition;
	
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		Vector3 CurrentPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		CurrentPosition.z = 0;
		
		Tile TileUnderMouse = GetTileCoord(CurrentPosition);
		if (TileUnderMouse != null){
			Cursor.SetActive(true);
			Vector3 cursorposition = new Vector3(TileUnderMouse.GetX, TileUnderMouse.GetY, 0);
			Cursor.transform.position = cursorposition;
		}
		else {
			Cursor.SetActive(false);
		}
        if(Input.GetMouseButton(1)){
			Vector3 diff = LastPosition - CurrentPosition;
			Camera.main.transform.Translate(diff);
		}
		LastPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		LastPosition.z = 0;
	}
	
	Tile GetTileCoord(Vector3 coord) {
		int x = Mathf.FloorToInt(coord.x);
		int y = Mathf.FloorToInt(coord.y);
		
		return GameWorld.instance.zoo.GetTile(x, y);
	}
}
