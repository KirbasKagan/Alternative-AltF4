using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class characterController : MonoBehaviour
{
    public float speed = 1.0f;
    private Rigidbody2D r2d;
    private Animator _animator;
    private Vector3 charPos;
    [SerializeField] private GameObject _camera; //SerializeField' tagı daha oyun başlamadan önce editor üzerinden kullanacağımız objeyi göstericez.
    private SpriteRenderer _spriteRenderer;

    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();  
        r2d = GetComponent<Rigidbody2D>(); //caching r2d
        _animator = GetComponent<Animator>();  // caching anim
        //_camera = GetComponent<Camera>(); // Şeklinde de yapılabilirdi kamera SerializeField tagı olmadan.
        charPos = transform.position;
    }

    private void FixedUpdate() //Fizik hesaplamalarının yapıldığı fonksiyon. 50fps
    {
        //r2d.velocity = new Vector2(speed, 0f); //y ekseninde haraket etmeyecem yalnızca x ekseninde hızım kadar hareket edicem.
        //_camera.transform.position = new Vector3(charPos.x, charPos.y,charPos.z -1.0f); // Burada kullanmak performans kaybına sebeb oluyor.
    }

    void Update() //sn'de 220 defa çalışıyor.
    {
        charPos = new Vector3(charPos.x + (Input.GetAxis("Horizontal") * speed * Time.deltaTime), charPos.y);
        transform.position = charPos; //Hesapladığım pozisyon karakterime işlensin.
        
        if (Input.GetAxis("Horizontal") == 0.0f)
        {
            _animator.SetFloat("speed",0.0f);
        }
        else
        {
            _animator.SetFloat("speed",1.0f);  
        }

        if (Input.GetAxis("Horizontal") > 0.01f)
        {
            _spriteRenderer.flipX = false;
        }
        else if (Input.GetAxis("Horizontal") < -0.01f)
        {
            _spriteRenderer.flipX = true;
        }
    }

    private void LateUpdate() //Kamera kullanımı için en iyi fonksiyon.
    {
        _camera.transform.position = new Vector3(charPos.x, charPos.y,charPos.z -1.0f); //Kameranın karakterin neresinde olacağı söyleniyor.
        
    }
}
 