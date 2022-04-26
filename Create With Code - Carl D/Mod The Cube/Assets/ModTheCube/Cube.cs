using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public MeshRenderer Renderer;
    public float moveSpeed = 0.1f;
    public int rotateSpeed = 2;

    //public float growSpeed = 0.1f;

    void Start()
    {
        transform.position = new Vector3(3, 4, 1);
        transform.localScale = Vector3.one * 1.3f;

        Material material = Renderer.material;

        material.color = new Color(0.5f, 1.0f, 0.3f, 0.4f);
    }

    void Update()
    {
        transform.Rotate(2.0f * Time.deltaTime * rotateSpeed, 0.0f, 0.0f);
        transform.Rotate(0.0f, 2.0f * Time.deltaTime * rotateSpeed, 0.0f);
        transform.Rotate(0.0f, 0.0f, 2.0f * Time.deltaTime * rotateSpeed);
        //transform.Translate(Vector3.back * moveSpeed * Time.deltaTime);
        //transform.localScale = Vector3.one * growSpeed;
        //growSpeed +=0.1f;
        /*public float redRange = Random.Range(0.0f, 1.0f);
        public float greenRange = Random.Range(0.0f, 1.0f);
        public float blueRange = Random.Range(0.0f, 1.0f);
        public float transRange = Random.Range(0.0f, 1.0f);*/
        Material material = Renderer.material;
        material.color = new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f));
    }
}
