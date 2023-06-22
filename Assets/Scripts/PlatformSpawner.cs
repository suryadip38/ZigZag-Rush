using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject platform;
    public GameObject diamonds;
    public bool gameOver;
    Vector3 lastPos;
    float size;
    public GameObject spike;

    void Start()
    {
        lastPos=platform.transform.position;
        size=platform.transform.localScale.x;
        for(int i=0;i<=20;i++){
            SpawnPlatforms();
        }
        //InvokeRepeating("SpawnPlatforms",2f,0.2f);
    }
    public void StartSpawningPlatform()
    {
        InvokeRepeating("SpawnPlatforms",0.1f,0.2f);
    }
    // Update is called once per frame
    void Update()
    {
        if(GameManager.instance.gameOver==true)
        {
            CancelInvoke("SpawnPlatforms");
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("spike"))
        {
            GameManager.instance.GameOver(); // Call your game over function here
        }
    }
    void SpawnPlatforms()
    {
        
        int rand=Random.Range(0,6);
        if(rand<3)
        {
            SpawnX();
        }
        else if(rand>=3)
        {
            SpawnZ();
        }

        int spikeRand = Random.Range(0, 5);
        if (spikeRand == 0)
        {
            SpawnSpike();
        }

        void SpawnSpike()
        {
            Vector3 pos = lastPos;
            pos.y += 0.5f; // Adjust the enemy spawn height as needed
            pos.y += 0.5f; // Adjust the enemy spawn height as needed
            Instantiate(spike, pos, Quaternion.identity);
            int rand = Random.Range(0, 4);

            if (rand < 1)
            {
                Instantiate(spike, new Vector3(pos.x, pos.y + 1, pos.z), spike.transform.rotation);
            }
        }
    }
    void SpawnX()
    {
        Vector3 pos=lastPos;
        pos.x+=size;
        lastPos=pos;
        Instantiate(platform,pos,Quaternion.identity);
        int rand=Random.Range(0,4);

        if(rand<1)
        {
            Instantiate(diamonds,new Vector3(pos.x,pos.y+1,pos.z),diamonds.transform.rotation);
        }
    }
    void SpawnZ()
    {
        Vector3 pos=lastPos;
        pos.z+=size;
        lastPos=pos;
        Instantiate(platform,pos,Quaternion.identity);
        int rand=Random.Range(0,4);
        if(rand<1)
        {
            Instantiate(diamonds,new Vector3(pos.x,pos.y+1,pos.z),diamonds.transform.rotation);
        }
    }

}
