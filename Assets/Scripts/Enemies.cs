using Jugador;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BotsEnemigos
{
    public class Enemies : MonoBehaviour
    {
        #region variables
        [Header("ESPECIFICACIONES ENEMIGO")]
        [SerializeField] private string NombreEnemigo;
        [SerializeField] private float velocidad;
        //[SerializeField] private float SaludMax;
        //public float saludEn; //Salud Enemigo
        [SerializeField] private float RangoAtaque; //rango en que los enemigos detecten al jugador
        public Animator animator;


        [Header("INTERACCION")]
        public Transform objetivo;
        #endregion

        #region funciones basicas
        void Start()
        {
            //saludEn = SaludMax;
            objetivo = GameObject.FindGameObjectWithTag("Player").transform;
        }

        void Update()
        {
            Movimiento();
        }
        #endregion

        #region code
        private void Movimiento()
        {
            if (Vector2.Distance(transform.position, objetivo.position) < RangoAtaque) //mientras jugador esté dentro de rango, perseguir
            {
                transform.position = Vector2.MoveTowards(transform.position, objetivo.position, velocidad * Time.deltaTime);
                Debug.Log("Persiguiendo");
            }
            //animacion
            Vector2 position = transform.position;
            if (position.x != 0)
            {
                animator.SetFloat("X", position.x);
                animator.SetFloat("Y", position.y);
            }
            animator.SetFloat("Speed", position.sqrMagnitude);
        }
        //public void recibirDaño()
        //{
        //    saludEn = saludEn - 5;
        //    if (saludEn <= 0)
        //    {
        //        Destroy(gameObject);
        //        //Debug.Log("Enemigos eliminados: " + Kills);
        //    }
        //}
        //private void OnTriggerEnter2D(Collider2D collision) //para cuando es atacado por el jugador
        //{
        //    if (collision.gameObject.CompareTag("Bala"))
        //    {
        //        recibirDaño();
        //    }
        //}

        #endregion
    }
}

