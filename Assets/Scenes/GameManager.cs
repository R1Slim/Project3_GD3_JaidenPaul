using UnityEngine;
using System;
using Unity.VisualScripting;
using System.Drawing;
using UnityEngine.UIElements;


public class GameManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject point;
    public float radius = 12.5f;
    public bool ENMYON;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ENMYON = enemyPrefab.activeSelf;
        SpawnEnemy(100, point.transform.position);
        enemyPrefab.SetActive(false);
    
        
    }
    // Update is called once per frame
    void Update()
    {
       
    }
    public void SpawnEnemy(int amount, Vector2 point)
    { 
        ///https://www.youtube.com/watch?v=V68OVgywm2A
        ///float nextangle = 2 * Mathf.PI / amount; 
        ///this would be decreasing as the closer we get to 100 the smaller the number 
        ///meaning youd get a spiral
        ///not what im looking for
        ///unless you make it an angle starting from the center 
        
        ///my current interpretation of this code:
        ///as we approach 100 the number will get smaller and smaller.
        ///but since were adding this to whatever the angle all were doing is making a bigger
        ///and bigger angle for the objects to go in
        
        

        float angle = 0;
        //my logic
        float circle = (2 * radius) * Mathf.PI;
        //float nextangle = 360 / 100; first code 
        float nextangle = (2 * Mathf.PI) / 100;
        //i wonder if (2 * Mathf.PI )/ 100 works  - it does and smoothens out the cirlce
        //im thinking to open up the angle you'd have to divide 360 by 100 to evenly space them out 


        for (int i = 0; i < amount; i++)
        {
             
            float x = Mathf.Cos(angle);
            float y = Mathf.Sin(angle);
            //returns which direction its going 
            Vector2 direction = new Vector2(x, y);
            ///so we have which direction its supposed to spawn in now we have to take the
            ///point its at and add it to its direction times the radius
            var spawnpt = point + direction * radius;
            ///my interpretation of this code:
            ///when we look at a clock on a diameter of 1 than 3 is (1,0) 9 is (-1,0)
            ///cos tells us how far each can go
            ///okay next
            ///when we look at a clock on a diameter of 1 than 12 is (0,1) 6 is (0,-1)
            ///sin tells us how far each point can go 

            ///to get to where i need to all i gotta do is get its inital point
            ///and add it to where its gonna go and how far
            

            var enmy = Instantiate(enemyPrefab, spawnpt, Quaternion.identity);
            angle += nextangle;
            
        }
    }
}
//make SpawnEnemy find first disabled enemy reset its value to the prefab than enable it and move it to a posistion  

///sources:
///https://discussions.unity.com/t/how-to-instantiate-objects-in-a-circle-formation-around-a-point/226980/2
///https://www.youtube.com/watch?v=V68OVgywm2A
///