using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _GameManager : MonoBehaviour
{
    public _Fantasmas[] fantasmaas;
    public _Pacman Pacman;
    public Transform pelotas;

    public int score { get; private set; }
    public int lives { get; private set; }

    private void Start()
    {
        NewGame();
    }

    private void Update()
    {
        if(this.lives <= 0 && Input.anyKeyDown)
        {
            NewGame();
        }
    }
    private void NewGame()
    {
        SetLives(3);
        SetScore(0);
        NuevaRonda();
        ReiniciarEstados();
    }

    private void NuevaRonda()
    {
        foreach(Transform pelotas in this.pelotas)
        {
            pelotas.gameObject.SetActive(true);
        }

        ReiniciarEstados();
        
    }

    private void ReiniciarEstados()
    {
        for (int i = 0; i < this.fantasmaas.Length; i++)
        {
            this.fantasmaas[i].gameObject.SetActive(true);
        }

        this.Pacman.gameObject.SetActive(true);
    }

    private void GameOver()
    {
        for (int i = 0; i < this.fantasmaas.Length; i++)
        {
            this.fantasmaas[i].gameObject.SetActive(false);
        }

        this.Pacman.gameObject.SetActive(false);
    }

    private void SetScore(int score)
    {
        this.score = score;
    }

    private void SetLives(int lives)
    {
        this.lives = lives;
    }

    public void ComiendoFantasmas(_Fantasmas fantasmas)
    {
        SetScore(this.score + fantasmas.points);
    }

    public void PacmanComiendo()
    {
        this.Pacman.gameObject.SetActive(false);

        SetLives(this.lives -1);
        if(this.lives > 0)
        {
            ReiniciarEstados();
        }
        else
        {
            GameOver();
        }
    }
}
