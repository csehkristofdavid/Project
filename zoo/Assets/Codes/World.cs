using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class World : MonoBehaviour
{
	static World _instance;
	public static World Instance { get; protected set;}
	
	public Sprite routeSprite;
	public Sprite shopSprite;
	public Sprite habitGrassSprite1;
	public Sprite habitGrassSprite2;
	public Sprite habitGrassSprite3;
	public Sprite habitGrassSprite4;
	public Sprite habitGrassSprite5;
	public Sprite habitGrassSprite6;
	public Sprite habitGrassSprite7;
	public Sprite habitGrassSprite8;
	public Sprite habitGrassSprite9;
	public Sprite habitDessertSprite1;
	public Sprite habitDessertSprite2;
	public Sprite habitDessertSprite3;
	public Sprite habitDessertSprite4;
	public Sprite habitDessertSprite5;
	public Sprite habitDessertSprite6;
	public Sprite habitDessertSprite7;
	public Sprite habitDessertSprite8;
	public Sprite habitDessertSprite9;
	public Sprite rabbitSprite1;
	public Sprite rabbitSprite2;
	public Sprite rabbitSprite3;
	public Sprite rabbitSprite4;
	public Sprite rabbitSprite5;
	public Sprite rabbitSprite6;
	public Sprite rabbitSprite7;
	public Sprite rabbitSprite8;
	public Sprite rabbitSprite9;
	public Sprite deerSprite1;
	public Sprite deerSprite2;
	public Sprite deerSprite3;
	public Sprite deerSprite4;
	public Sprite deerSprite5;
	public Sprite deerSprite6;
	public Sprite deerSprite7;
	public Sprite deerSprite8;
	public Sprite deerSprite9;
	public Sprite mongooseSprite1;
	public Sprite mongooseSprite2;
	public Sprite mongooseSprite3;
	public Sprite mongooseSprite4;
	public Sprite mongooseSprite5;
	public Sprite mongooseSprite6;
	public Sprite mongooseSprite7;
	public Sprite mongooseSprite8;
	public Sprite mongooseSprite9;
	public Sprite camelSprite1;
	public Sprite camelSprite2;
	public Sprite camelSprite3;
	public Sprite camelSprite4;
	public Sprite camelSprite5;
	public Sprite camelSprite6;
	public Sprite camelSprite7;
	public Sprite camelSprite8;
	public Sprite camelSprite9;
	
	public int money;
	public int moneyPerSecond;
	public Text moneyDisplay;
	
	public Zoo Zoo {get; protected set;}
	
    // Start is called before the first frame update
    void Start()
    {
		if(Instance != null){
			Debug.LogError("There are two world");
		}
		
		Instance = this;
		//üres világ létrehozása
		Zoo = new Zoo();
		money = 10000;
		//GameObject készítése minden egyes tile-nak, hogy 
		//láthatóak legyenek
		for(int x = 0; x < Zoo.Width; x++){
			for(int y = 0; y < Zoo.Height; y++){
				Tile tile_data = Zoo.GetTile(x, y);
				
				GameObject tile_go = new GameObject();
				tile_go.name = "Tile(" +x+ ";" +y+ ")";
				tile_go.transform.position = new Vector3(tile_data.X, tile_data.Y, 0);
				//spirte hozzaadása de nem módosít semmi, mivel minden üres
				tile_go.AddComponent<SpriteRenderer>();
				tile_go.transform.SetParent(this.transform, true); 
				
				tile_data.RegisterTileTypeChangedCallback( (tile) => {TileTypeChanged(tile, tile_go);});
				
			}
		}
		
		//Zoo.RandomizeTiles();
    }
	
	float updateMoneyTimer = 1f;
	
	public int MoneyPerSecond(){
		int m = 0;
		m =+ moneyPerSecond;
		return m;
	}
	
    // Update is called once per frame
    void Update()
    {
		updateMoneyTimer -= Time.deltaTime;
		
		if(updateMoneyTimer < 0){
			//moneyupdate
			
			money += MoneyPerSecond();
			updateMoneyTimer = 1f;
			//Debug.Log("money was updated");
		}
		
		moneyDisplay.text = "$" + money;
    }
	
	void TileTypeChanged(Tile tile_data, GameObject tile_go) {
		if(tile_data.Type == Tile.TileType.ROUTE) {
			if(money >= 10){
				money -= 10;
				tile_go.GetComponent<SpriteRenderer>().sprite = routeSprite;
			}
		}
		else if(tile_data.Type == Tile.TileType.EMPTY){
			tile_go.GetComponent<SpriteRenderer>().sprite = null;
		}
		else if(tile_data.Type == Tile.TileType.SHOP){
			if(money >= 100){
				money -= 100;
				tile_go.GetComponent<SpriteRenderer>().sprite = shopSprite;
				moneyPerSecond += 1;
			}
		}
		//grassland
		else if(tile_data.Type == Tile.TileType.GRASSHABIT1){
			if(money >= 300) {
				money -= 300;
				tile_go.GetComponent<SpriteRenderer>().sprite = habitGrassSprite1;
				Zoo.GrasslandHabitBuild(tile_data);
			}
		}
		else if(tile_data.Type == Tile.TileType.GRASSHABIT2){
			tile_go.GetComponent<SpriteRenderer>().sprite = habitGrassSprite2;
		}
		else if(tile_data.Type == Tile.TileType.GRASSHABIT3){
			tile_go.GetComponent<SpriteRenderer>().sprite = habitGrassSprite3;
		}
		else if(tile_data.Type == Tile.TileType.GRASSHABIT4){
			tile_go.GetComponent<SpriteRenderer>().sprite = habitGrassSprite4;
		}
		else if(tile_data.Type == Tile.TileType.GRASSHABIT5){
			tile_go.GetComponent<SpriteRenderer>().sprite = habitGrassSprite5;
		}
		else if(tile_data.Type == Tile.TileType.GRASSHABIT6){
			tile_go.GetComponent<SpriteRenderer>().sprite = habitGrassSprite6;
		}
		else if(tile_data.Type == Tile.TileType.GRASSHABIT7){
			tile_go.GetComponent<SpriteRenderer>().sprite = habitGrassSprite7;
		}
		else if(tile_data.Type == Tile.TileType.GRASSHABIT8){
			tile_go.GetComponent<SpriteRenderer>().sprite = habitGrassSprite8;
		}
		else if(tile_data.Type == Tile.TileType.GRASSHABIT9){
			tile_go.GetComponent<SpriteRenderer>().sprite = habitGrassSprite9;
		}
		//dessert
		else if(tile_data.Type == Tile.TileType.DESSERTHABIT1){
			if( money >= 800){
				money -= 800;
				tile_go.GetComponent<SpriteRenderer>().sprite = habitDessertSprite1;
				Zoo.DessertHabitBuild(tile_data);
			}
		}
		else if(tile_data.Type == Tile.TileType.DESSERTHABIT2){
			tile_go.GetComponent<SpriteRenderer>().sprite = habitDessertSprite2;
		}
		else if(tile_data.Type == Tile.TileType.DESSERTHABIT3){
			tile_go.GetComponent<SpriteRenderer>().sprite = habitDessertSprite3;
		}
		else if(tile_data.Type == Tile.TileType.DESSERTHABIT4){
			tile_go.GetComponent<SpriteRenderer>().sprite = habitDessertSprite4;
		}
		else if(tile_data.Type == Tile.TileType.DESSERTHABIT5){
			tile_go.GetComponent<SpriteRenderer>().sprite = habitDessertSprite5;
		}
		else if(tile_data.Type == Tile.TileType.DESSERTHABIT6){
			tile_go.GetComponent<SpriteRenderer>().sprite = habitDessertSprite6;
		}
		else if(tile_data.Type == Tile.TileType.DESSERTHABIT7){
			tile_go.GetComponent<SpriteRenderer>().sprite = habitDessertSprite7;
		}
		else if(tile_data.Type == Tile.TileType.DESSERTHABIT8){
			tile_go.GetComponent<SpriteRenderer>().sprite = habitDessertSprite8;
		}
		else if(tile_data.Type == Tile.TileType.DESSERTHABIT9){
			tile_go.GetComponent<SpriteRenderer>().sprite = habitDessertSprite9;
		}
		//rabbit
		else if(tile_data.Type == Tile.TileType.RABBIT1){
			if(money >= 500){
				money -= 500;
				tile_go.GetComponent<SpriteRenderer>().sprite = rabbitSprite1;
				Zoo.PutRabbit(tile_data);
				moneyPerSecond += 5;
			}
		}
		else if(tile_data.Type == Tile.TileType.RABBIT2){
			tile_go.GetComponent<SpriteRenderer>().sprite = rabbitSprite2;
		}
		else if(tile_data.Type == Tile.TileType.RABBIT3){
			tile_go.GetComponent<SpriteRenderer>().sprite = rabbitSprite3;
		}
		else if(tile_data.Type == Tile.TileType.RABBIT4){
			tile_go.GetComponent<SpriteRenderer>().sprite = rabbitSprite4;
		}
		else if(tile_data.Type == Tile.TileType.RABBIT5){
			tile_go.GetComponent<SpriteRenderer>().sprite = rabbitSprite5;
		}
		else if(tile_data.Type == Tile.TileType.RABBIT6){
			tile_go.GetComponent<SpriteRenderer>().sprite = rabbitSprite6;
		}
		else if(tile_data.Type == Tile.TileType.RABBIT7){
			tile_go.GetComponent<SpriteRenderer>().sprite = rabbitSprite7;
		}
		else if(tile_data.Type == Tile.TileType.RABBIT8){
			tile_go.GetComponent<SpriteRenderer>().sprite = rabbitSprite8;
		}
		else if(tile_data.Type == Tile.TileType.RABBIT9){
			tile_go.GetComponent<SpriteRenderer>().sprite = rabbitSprite9;
		}
		//deer
		else if(tile_data.Type == Tile.TileType.DEER1){
			if( money >= 800){
				money -= 800;
				tile_go.GetComponent<SpriteRenderer>().sprite = deerSprite1;
				Zoo.PutDeer(tile_data);
				moneyPerSecond += 9;
			}
		}
		else if(tile_data.Type == Tile.TileType.DEER2){
			tile_go.GetComponent<SpriteRenderer>().sprite = deerSprite2;
		}
		else if(tile_data.Type == Tile.TileType.DEER3){
			tile_go.GetComponent<SpriteRenderer>().sprite = deerSprite3;
		}
		else if(tile_data.Type == Tile.TileType.DEER4){
			tile_go.GetComponent<SpriteRenderer>().sprite = deerSprite4;
		}
		else if(tile_data.Type == Tile.TileType.DEER5){
			tile_go.GetComponent<SpriteRenderer>().sprite = deerSprite5;
		}
		else if(tile_data.Type == Tile.TileType.DEER6){
			tile_go.GetComponent<SpriteRenderer>().sprite = deerSprite6;
		}
		else if(tile_data.Type == Tile.TileType.DEER7){
			tile_go.GetComponent<SpriteRenderer>().sprite = deerSprite7;
		}
		else if(tile_data.Type == Tile.TileType.DEER8){
			tile_go.GetComponent<SpriteRenderer>().sprite = deerSprite8;
		}
		else if(tile_data.Type == Tile.TileType.DEER9){
			tile_go.GetComponent<SpriteRenderer>().sprite = deerSprite9;
		}
		//mongoose
		else if(tile_data.Type == Tile.TileType.MONGOOSE1){
			if( money >= 1000){
				money -= 1000;
				tile_go.GetComponent<SpriteRenderer>().sprite = mongooseSprite1;
				Zoo.PutMongoose(tile_data);
				moneyPerSecond += 15;
			}
		}
		else if(tile_data.Type == Tile.TileType.MONGOOSE2){
			tile_go.GetComponent<SpriteRenderer>().sprite = mongooseSprite2;
		}
		else if(tile_data.Type == Tile.TileType.MONGOOSE3){
			tile_go.GetComponent<SpriteRenderer>().sprite = mongooseSprite3;
		}
		else if(tile_data.Type == Tile.TileType.MONGOOSE4){
			tile_go.GetComponent<SpriteRenderer>().sprite = mongooseSprite4;
		}
		else if(tile_data.Type == Tile.TileType.MONGOOSE5){
			tile_go.GetComponent<SpriteRenderer>().sprite = mongooseSprite5;
		}
		else if(tile_data.Type == Tile.TileType.MONGOOSE6){
			tile_go.GetComponent<SpriteRenderer>().sprite = mongooseSprite6;
		}
		else if(tile_data.Type == Tile.TileType.MONGOOSE7){
			tile_go.GetComponent<SpriteRenderer>().sprite = mongooseSprite7;
		}
		else if(tile_data.Type == Tile.TileType.MONGOOSE8){
			tile_go.GetComponent<SpriteRenderer>().sprite = mongooseSprite8;
		}
		else if(tile_data.Type == Tile.TileType.MONGOOSE9){
			tile_go.GetComponent<SpriteRenderer>().sprite = mongooseSprite9;
		}
		//camel 
		else if(tile_data.Type == Tile.TileType.CAMEL1){
			if(money >= 2000){
				money -= 2000;
				tile_go.GetComponent<SpriteRenderer>().sprite = camelSprite1;
				Zoo.PutCamel(tile_data);
				moneyPerSecond += 22;
			}
		}
		else if(tile_data.Type == Tile.TileType.CAMEL2){
			tile_go.GetComponent<SpriteRenderer>().sprite = camelSprite2;
		}
		else if(tile_data.Type == Tile.TileType.CAMEL3){
			tile_go.GetComponent<SpriteRenderer>().sprite = camelSprite3;
		}
		else if(tile_data.Type == Tile.TileType.CAMEL4){
			tile_go.GetComponent<SpriteRenderer>().sprite = camelSprite4;
		}
		else if(tile_data.Type == Tile.TileType.CAMEL5){
			tile_go.GetComponent<SpriteRenderer>().sprite = camelSprite5;
		}
		else if(tile_data.Type == Tile.TileType.CAMEL6){
			tile_go.GetComponent<SpriteRenderer>().sprite = camelSprite6;
		}
		else if(tile_data.Type == Tile.TileType.CAMEL7){
			tile_go.GetComponent<SpriteRenderer>().sprite = camelSprite7;
		}
		else if(tile_data.Type == Tile.TileType.CAMEL8){
			tile_go.GetComponent<SpriteRenderer>().sprite = camelSprite8;
		}
		else if(tile_data.Type == Tile.TileType.CAMEL9){
			tile_go.GetComponent<SpriteRenderer>().sprite = camelSprite9;
		}
		//hiba
		else {
			Debug.LogError("Unknown tile type");
		}
		
	}
	
	public Tile GetTileWorldCoord(Vector3 coord) {
		int x = Mathf.FloorToInt(coord.x);
		int y = Mathf.FloorToInt(coord.y);
		
		return World.Instance.Zoo.GetTile(x,y);
	}
	
	public bool IsEmpty (Tile tile_data) {
		if(tile_data.Type == Tile.TileType.EMPTY){
			return true;
		}
		else { 
			return false;
		}
	}
	
	public bool IsGrassHabit (Tile tile_data) {
		if(tile_data.Type == Tile.TileType.GRASSHABIT1){
			return true;
		}
		else { 
			return false;
		}
	}
	
	public bool IsDessertHabit (Tile tile_data) {
		if(tile_data.Type == Tile.TileType.DESSERTHABIT1){
			return true;
		}
		else { 
			return false;
		}
	}
	
	public void ShopDestroyed() {
		moneyPerSecond -= 1;
	}
	
	public void RabbitDestroyed() {
		moneyPerSecond -= 5;
	}
	
	public void DeerDestroyed() {
		moneyPerSecond -= 9;
	}
	
	public void MongooseDestroyed() {
		moneyPerSecond -= 15;
	}
	
	public void CamelDestroyed() {
		moneyPerSecond -= 22;
	}
}
