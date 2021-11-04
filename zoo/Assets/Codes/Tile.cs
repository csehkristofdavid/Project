using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Tile{
    
	public enum TileType { Empty, Building };
	
	TileType type = TileType.Empty;
	
	Action<Tile> TTC_callback;
	
	public TileType Type {
		get {
			return type;
		}
		set {
			TileType oldtype = type;
			type = value;
			if(TTC_callback != null && oldtype != type){
				TTC_callback(this);
			}
		}
	}
	
	Zoo zoo;
	int x;
	public int GetX {
		get {
			return x;
		}
	}
	int y;
	public int GetY {
		get {
			return y;
		}
	}
	
	public Tile( Zoo zoo, int x, int y){
		this.zoo = zoo;
		this.x = x;
		this.y = y;
	}
	
	public void TileTypeChangedCallBack(Action<Tile> act){
		TTC_callback = act;
	}
}
