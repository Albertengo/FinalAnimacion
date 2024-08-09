using Jugador;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace interfaz
{
    public class Botones : MonoBehaviour
    {
        public GameObject CreditosPanel;
        public string NombreEscena;
        //lógica para los botones usados dentro del juego
        public void Restart()
        {
            SceneManager.LoadScene(NombreEscena);
            //Enemies.Kills = 0;
            //ControlJuego.CantidadEnemigos = 0;
            Time.timeScale = 1f;
        }
        public void Menu()
        {
            SceneManager.LoadScene("Menú");
        }
        public void PlayButton()
        {
            SceneManager.LoadScene("Nivel 1");
            //Enemies.Kills = 0;
            //ControlJuego.CantidadEnemigos = 0;
            Time.timeScale = 1f;
        }
        public void CreditsButton()
        {
            CreditosPanel.SetActive(true);
        }
        public void QuitGame()
        {
            Debug.Log("Saliste.");
            Application.Quit();
        }
    }
}
