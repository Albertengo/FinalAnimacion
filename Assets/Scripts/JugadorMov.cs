using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Jugador
{
    public class JugadorMov : MonoBehaviour
    {
        #region Variables
        //movimiento
        public float velocidad;

        //animaciones
        public Animator animator;
        Vector2 Playermov;
        #endregion

        #region funciones basicas
        void Update()
        {
            movimiento();
        }
        #endregion

        #region code
        void movimiento()
        {
            float movimientohorizontal = Input.GetAxis("Horizontal") * velocidad * Time.deltaTime;
            float movimientovertical = Input.GetAxis("Vertical") * velocidad * Time.deltaTime;
            transform.Translate(movimientohorizontal, movimientovertical, 0);

            //animacion
            Playermov = new Vector2(movimientohorizontal, movimientovertical).normalized; //.normalized para normalizar el num del vector
            if (Playermov.x != 0)
            {
                animator.SetFloat("X", Playermov.x);
                animator.SetFloat("Y", Playermov.y);
            }

            animator.SetFloat("Speed", Playermov.sqrMagnitude);
        }
        private void OnTriggerEnter2D(Collider2D collision) //para boostear la velocidad del pj
        {
            if (collision.gameObject.CompareTag("Interactuable"))
            {
                Debug.Log("Objeto Interactuable, aprete E para interactuar");
                //collision.gameObject.SetActive(false);
            }
            if (collision.gameObject.CompareTag("Dialogo"))
            {
                Debug.Log("Dialogo disponible, aprete E para interactuar");
                //collision.gameObject.SetActive(false);
            }
            if (collision.gameObject.CompareTag("Enemy"))
            {
                Debug.Log("GAMEOVER");
            }
            #endregion
        }
    }
}
