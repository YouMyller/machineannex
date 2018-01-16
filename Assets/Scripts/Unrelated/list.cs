using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class list : MonoBehaviour {

    public class Item
    {
        public string name;
        public int amount;
    }

    List<int> highscore = new List<int>();
    Dictionary<string, Item> inventory = new Dictionary<string, Item>();
    string redPotion = "Red Potion";

	// Use this for initialization
	void Start ()
    {
        highscore.Add(100);
        highscore.Add(170);
        highscore.Add(23);
        for (int i = 0; i < highscore.Count; i++)
        {
            Debug.Log(highscore[i]);
        }
        highscore.Sort();

        Item redPotionItem = new Item();
        redPotionItem.name = redPotion;
        redPotionItem.amount = 1;

        inventory.Add(redPotion, redPotionItem);

        if (inventory[redPotion].amount > 0)
        {
            Item i = inventory[redPotion];
            i.amount--;
        }

        Debug.Log(inventory[redPotion].amount);



        foreach(KeyValuePair<string, Item> kvp in inventory)
        {
            if (kvp.Key == redPotion)
            {
                kvp.Value.amount--;
            }
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
