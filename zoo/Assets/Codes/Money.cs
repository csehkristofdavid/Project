using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Money : MonoBehaviour
{
	static Money _instance;
	public static Money Instance { get; set;}
	public int money;
	public int moneyPerSecond;
	public Text moneyDisplay;
	
    // Start is called before the first frame update
    void Start()
    {
        //money = 0;
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
        //if(Input.GetMouseButton(0)) {
		//	money += 1;
		//}
		updateMoneyTimer -= Time.deltaTime;
		
		if(updateMoneyTimer < 0){
			//moneyupdate
			
			money += MoneyPerSecond();
			updateMoneyTimer = 1f;
			Debug.Log("money was updated");
		}
		
		moneyDisplay.text = "$" + money;
    }
	
	public int GetMoneyPerSecond(int x){
		return x;
	}
}
