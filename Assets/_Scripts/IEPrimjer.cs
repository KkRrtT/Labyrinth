using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class IEPrimjer : MonoBehaviour
{
    [SerializeField] GameObject[] objects;
    [SerializeField] int timer = 3;
    [SerializeField] float hp = 100f;



    private void Start()
    {
        StartCoroutine(Timer());
    }



    private IEnumerator Timer()
    {
        float timer = 0;
        float sekunde = 0;
        int minute = default;
        for(int i = 0; i <= 60 * 60; i++)
        {            
            minute = (int)timer / 60;
            if (sekunde == 60) sekunde = 0;
            string vrijeme = $"Vrijeme je: {minute} : {sekunde}";
            print(vrijeme);
            print(string.Format("{0:00} : {1:00}", minute, sekunde));
            print(minute);
            yield return new WaitForSeconds(1);
            sekunde++;
            timer++;

        }
    }


    private IEnumerator SpawnerTimed(GameObject[] a, int time)
    {
        while (true)
        {
            yield return new WaitForSeconds(time);
            Spawner(a);     
        }
    }
    private void Spawner(GameObject[] a)
    {
        int rng = Random.Range(0, a.Length);
        int x = Random.Range(0, 10);
        int y = Random.Range(0, 20);
        int z = Random.Range(-15, 15);

        Instantiate(a[rng], new Vector3(x, y, z), Quaternion.identity);
    }


    private IEnumerator Fail(int time)
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            print("Luzer");
        }
    }
    
    public void HPMetoda()
    {
        StartCoroutine(HP(default, default));
    }
    private IEnumerator HP(int x, bool b)
    {
        while (b)
        {
            yield return new WaitForSeconds(1);
            switch (x)
            {
                case 0:
                    {
                        print("Dodavanje");
                        hp += 5; break;
                    }
                case 1: 
                    {
                        print("Oduzimanje");
                        hp -= (hp/100) * 5; break;
                    }                
            }
        }
        while (!b)
        {
            yield return null;
            print("U triggeru");
            hp += 5 * Time.deltaTime;
        }
    }
}
