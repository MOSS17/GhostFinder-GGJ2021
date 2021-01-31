using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    private float timer = 0f;
    [SerializeField] float growTime = 2f, maxSize = 12f;
    [SerializeField] bool isMaxSize = false;
    // Start is called before the first frame update
    void Start()
    {
        if(!isMaxSize == false){
            StartCoroutine(Grow());
        }
    }
    
    private IEnumerator Grow(){
        Vector3 startScale = transform.localScale;
        Vector3 maxScale = new Vector3(maxSize, maxSize, maxSize);

        do{
            transform.localScale = Vector3.Lerp(startScale, maxScale, timer / growTime);
            timer += Time.deltaTime;
            yield return null;
        }
        while(timer < growTime);

        isMaxSize = true;
    }
}
