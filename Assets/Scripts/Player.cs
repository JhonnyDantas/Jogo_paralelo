using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float velocidade = 0.0f ;
    public float entradaHorizontal ;
    public float entradaVertical ;

    public GameObject Laser ;

    public float tempoDeDisparo = 0.3f ;

    public float podeDisparar = 0.0f ;

    public bool possoDarDisparoTriplo = false ;
    public GameObject disparoDuplo ;


    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start de "+this.name);
        velocidade = 8.0f ;
        transform.position = new Vector3(0,0,0);
    }

    // Update is called once per frame
    void Update()
    {
        //----
        
        Movimento();

        //------

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0) ){

            if ( Time.time > podeDisparar ){
                if (possoDarDisparoTriplo == true ){
                
                Instantiate(disparoDuplo, transform.position + new Vector3(0,0.5f,0),Quaternion.identity);
               
                } else {

                 Instantiate(Laser, transform.position + new Vector3(0.72f,0.5f,0),Quaternion.identity);

                }
                
                podeDisparar = Time.time + tempoDeDisparo ;
           
            }
   
        }

   }

    private void Movimento(){

        entradaHorizontal = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right*Time.deltaTime*velocidade*entradaHorizontal);

        if ( transform.position.x  > 4.07f) {
            transform.position = new Vector3(-4.07f,transform.position.y,0);
        }

        if ( transform.position.x  < -4.07f  ) {
            transform.position = new Vector3(4.07f,transform.position.y,0);
        
        } 
        
        entradaVertical = Input.GetAxis("Vertical");
        transform.Translate(Vector3.up*Time.deltaTime*velocidade*entradaVertical);

        if ( transform.position.y  > 1.45f ) {
            transform.position = new Vector3(transform.position.x,1.45f,0);
        }

        if ( transform.position.y  < -1.58f  ) {
            transform.position = new Vector3(transform.position.x,-1.58f,0);
        
        }
   }






}
