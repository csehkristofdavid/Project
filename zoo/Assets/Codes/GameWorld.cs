using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameWorld : MonoBehaviour
{
	public static GameWorld instance { get; protected set; }
	
	public Sprite emptysprite;
	
	public Zoo zoo { get; protected set; }
	
    // Start is called before the first frame update
    void Start()
    {
		instance = this;
		
        zoo = new Zoo();
		
		for (int x = 0; x < zoo.Width; x++){
			for (int y = 0; y < zoo.Height; y++){
				Tile tile_data = zoo.GetTile(x, y);
				GameObject tile_gameobj = new GameObject();
				tile_gameobj.name = "Tile(" + x + ";" + y + ")";
				SpriteRenderer tile_sr = tile_gameobj.AddComponent<SpriteRenderer>();
				tile_gameobj.transform.position = new Vector3(tile_data.GetX, tile_data.GetY, 0);
				tile_gameobj.transform.SetParent(this.transform, true);
				//tile_gameobj.AddComponent<SpriteRenderer>();
				if(tile_data.Type == Tile.TileType.Empty){
					tile_sr.sprite = emptysprite;
				}
				tile_data.TileTypeChangedCallBack( (tile) => {TileTypeChanged(tile, tile_gameobj); });
			}
		}
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	void TileTypeChanged(Tile tile_data, GameObject tile_gameobj){
		if(tile_data.Type == Tile.TileType.Empty){
			tile_gameobj.GetComponent<SpriteRenderer>().sprite = emptysprite;
		}
		else if(tile_data.Type == Tile.TileType.Building){
			tile_gameobj.GetComponent<SpriteRenderer>().sprite = null;
		}
		else {
			Debug.LogError("TileTypeChanged - Unknown tile type!");
		}
	}
}
