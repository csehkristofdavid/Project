using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Mouse : MonoBehaviour
{
	public GameObject cursor;
	
	bool destroy = false;
	bool putAnimal = false;
	bool buildHabit = false;
	Tile.TileType buildModeTile = Tile.TileType.ROUTE;
	string buildModeObjectType;
	
	Vector3 lastFramePosition;
	Vector3 currFramePosition;
	
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		currFramePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		currFramePosition.z = 0;
		
		Tile tileUnderMouse = World.Instance.GetTileWorldCoord(currFramePosition);
		if(tileUnderMouse != null){
			cursor.SetActive(true);
			Vector3 cursorPosition = new Vector3(tileUnderMouse.X, tileUnderMouse.Y, 0);
			cursor.transform.position = cursorPosition;
		}
		else {
			cursor.SetActive(false);
		}
		
		//bal egérgomb
		if(EventSystem.current.IsPointerOverGameObject()){
			return;
		}
		if(Input.GetMouseButton(0)){
			Tile t = World.Instance.Zoo.GetTile(Mathf.FloorToInt(currFramePosition.x), Mathf.FloorToInt(currFramePosition.y));
			if(t != null){
				if(World.Instance.IsEmpty(tileUnderMouse) && buildHabit == false && putAnimal == false){
					t.Type = buildModeTile;
				}
				else if(World.Instance.IsEmpty(tileUnderMouse) && buildHabit == true){
					if(World.Instance.Zoo.EnoughtSpace(t) == true){
						t.Type = buildModeTile;
					}
				}
				else if(putAnimal == true){
					if(World.Instance.IsGrassHabit(tileUnderMouse) == true){
						if(buildModeTile == Tile.TileType.RABBIT1 || buildModeTile == Tile.TileType.DEER1){
							t.Type = buildModeTile;
						}
						else Debug.LogError("Error at Mouse.putAnimal");
					}
					else if(World.Instance.IsDessertHabit(tileUnderMouse) == true){
						if(buildModeTile == Tile.TileType.MONGOOSE1 || buildModeTile == Tile.TileType.CAMEL1){
							t.Type = buildModeTile;
						}
						else Debug.LogError("Error at Mouse.putAnimal");
					}
				}
				else if(destroy == true){
					if(t.Type == Tile.TileType.GRASSHABIT1 || t.Type == Tile.TileType.DESSERTHABIT1) {
						World.Instance.Zoo.DestroyHabit(t);
						t.Type = buildModeTile;
					}
					else if(t.Type == Tile.TileType.ROUTE){
						t.Type = buildModeTile;
					}
					else if(t.Type == Tile.TileType.SHOP){
						t.Type = buildModeTile;
						World.Instance.ShopDestroyed();
					}
					else if(t.Type == Tile.TileType.RABBIT1){
						World.Instance.Zoo.DestroyHabit(t);
						t.Type = buildModeTile;
						World.Instance.RabbitDestroyed();
					}
					else if(t.Type == Tile.TileType.DEER1){
						World.Instance.Zoo.DestroyHabit(t);
						t.Type = buildModeTile;
						World.Instance.DeerDestroyed();
					}
					else if(t.Type == Tile.TileType.MONGOOSE1) {
						World.Instance.Zoo.DestroyHabit(t);
						t.Type = buildModeTile;
						World.Instance.MongooseDestroyed();
					}
					else if(t.Type == Tile.TileType.CAMEL1) {
						World.Instance.Zoo.DestroyHabit(t);
						t.Type = buildModeTile;
						World.Instance.CamelDestroyed();
					}
				}
			}
		}
		
		//kamera mozgatas lenyomott egérgombbal
        if(Input.GetMouseButton(1)){
			Vector3 diff = lastFramePosition - currFramePosition;
			Camera.main.transform.Translate(diff);
		}
		
		lastFramePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		lastFramePosition.z = 0;
		
		Camera.main.orthographicSize -= Input.GetAxis("Mouse ScrollWheel") * 2f;
		Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize, 3f, 10f);	
	}
	
	public void SetMode_BuildRoute(){
		destroy = false;
		putAnimal = false;
		buildHabit = false;
		buildModeTile = Tile.TileType.ROUTE;
	}
	
	public void SetMode_Destroy(){
		destroy = true;
		putAnimal = false;
		buildHabit = false;
		buildModeTile = Tile.TileType.EMPTY;
	}
	
	public void SetMode_BuildShop(){
		destroy = false;
		putAnimal = false;
		buildHabit = false;
		buildModeTile = Tile.TileType.SHOP;
	}
	
	public void SetMode_BuildGrassHabit(){
		destroy = false;
		putAnimal = false;
		buildHabit = true;
		buildModeTile = Tile.TileType.GRASSHABIT1;
	}
	
	public void SetMode_BuildDessertHabit(){
		destroy = false;
		putAnimal = false;
		buildHabit = true;
		buildModeTile = Tile.TileType.DESSERTHABIT1;
	}
	
	public void SetMode_PutRabbit(){
		destroy = false;
		putAnimal = true;
		buildHabit = false;
		buildModeTile = Tile.TileType.RABBIT1;
	}
	
	public void SetMode_PutDeer(){
		destroy = false;
		putAnimal = true;
		buildHabit = false;
		buildModeTile = Tile.TileType.DEER1;
	}
	
	public void SetMode_PutMongoose(){
		destroy = false;
		putAnimal = true;
		buildHabit = false;
		buildModeTile = Tile.TileType.MONGOOSE1;
	}
	
	public void SetMode_PutCamel(){
		destroy = false;
		putAnimal = true;
		buildHabit = false;
		buildModeTile = Tile.TileType.CAMEL1;
	}
	
	/*public void SetMode_BuildBuilding(string objectType){
		buildModeBuilding = true;
		buildModeObjectType = objectType;
	}*/
	
	
}
