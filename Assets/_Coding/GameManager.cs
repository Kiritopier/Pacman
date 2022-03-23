using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    public Fantasmas[] fantasmas;
    public Pacman Pacman;
    public Transform pelota;

    public int MultiplicadorFantasma { get; private set; } = 1;
    public int score { get; private set; }
    public int lives { get; private set; }

    private void Start()
    {
        NewGame();
    }

    private void Update()
    {
        if (this.lives <= 0 && Input.anyKey)
        {
            NewGame();
        }
    }
    private void NewGame()
    {
        SetLives(3);
        SetScore(0);
        NuevaRonda();
        
    }

    private void NuevaRonda()
    {
        foreach (Transform pelotas in pelota)
        {
            pelotas.gameObject.SetActive(true);
        }

        ReiniciarEstados();

    }

    private void ReiniciarEstados()
    {
        
        for (int i = 0; i < this.fantasmas.Length; i++)
        {
            fantasmas[i].gameObject.SetActive(true);
        }

        
    }

    private void GameOver()
    {
        for (int i = 0; i < this.fantasmas.Length; i++)
        {
            fantasmas[i].gameObject.SetActive(false);
        }

        Pacman.gameObject.SetActive(false);
    }

    private void SetScore(int score)
    {
        this.score = score;
    }

    private void SetLives(int lives)
    {
        this.lives = lives;
    }

    public void ComiendoFantasmas(Fantasmas fantasmas)
    {
        int points = fantasmas.points * MultiplicadorFantasma;
        SetScore(this.score + points); 
        MultiplicadorFantasma++;
    }

    public void PacmanComiendo()
    {
        Pacman.gameObject.SetActive(false);

        SetLives(this.lives - 1);
        if (this.lives > 0)
        {
            Invoke(nameof(ReiniciarEstados), 3.0f);
        }
        else
        {
            GameOver();
        }
    }

    public void ComerPelotas(Pelota pelota)
    {
        pelota.gameObject.SetActive(false);
        SetScore(score + pelota.points);

        if(!QuedanPelotas())
        {
            Pacman.gameObject.SetActive(false);
            Invoke(nameof(NuevaRonda), 3.0f);
        }
    }

    public void ComerPelotaPoder(Pelota_Poder pelota)
    {
        ComerPelotaPoder(pelota);
        CancelInvoke();
        Invoke(nameof(MultiplicadorFantasma), pelota.Duracion);
    }

   

    private bool QuedanPelotas()
    {
        foreach (Transform pelota in this.pelota)
        {
            if(pelota.gameObject.activeSelf)
            {
                return true;
            }
        }
        return false;
    }

    private void ReseteoMultiplicadorFantasmas()
    {
        MultiplicadorFantasma = 1;
    }

}
