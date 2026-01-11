using UnityEngine;
using System;
using System.Collections;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class Player : MonoBehaviour, IDahable
{
    public event Action<float> seActualizaMovimiento; //notificacion, evento.
    //entre las flechas indico si el invoke puede pasar cosas
    
    private float maxHealth;
    private float currentHealth;
    private bool isPauseMenuUp;

    [SerializeField] private GameObject gameOverMenu;
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private TMPro.TMP_Text healthText;

    private void Awake()
    {
        Time.timeScale = 1;
    }

    private void Start()
    {
        transform.position = GameManager.instance.SavedPosition;
        transform.eulerAngles = GameManager.instance.SavedRotation;
        //Debug.Break(); //cuando el codigo pasa para el motor
        Debug.Log(GameManager.instance.SavedHealth);
        currentHealth = GameManager.instance.SavedHealth; 
        healthText.text = currentHealth.ToString();
        
        pauseMenu.SetActive(false);
        isPauseMenuUp = false;
    }

    private void Update()
    {
        if (currentHealth <= 0) //MUERTE
        {
            Time.timeScale = 0;
            gameOverMenu.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.P)) //MENU DE PAUSA
        {
            Debug.Log("Key is pressed");
            if (!isPauseMenuUp)
            {
                Time.timeScale = 0;
                pauseMenu.SetActive(true);
                StartCoroutine(TimerMenuPause());
            }
            if (isPauseMenuUp)
            {
                Time.timeScale = 1;
                pauseMenu.SetActive(false);
                isPauseMenuUp = false;
            }
        }
    }

    IEnumerator TimerMenuPause()
    {
        yield return new WaitForSecondsRealtime(0.2f);
        isPauseMenuUp = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<LevelPortal>(out LevelPortal portal))
        {
            GameManager.instance.SavedHealth = currentHealth;
            Debug.Log("Health entered");
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            if (other.gameObject.TryGetComponent<Damage>(out Damage damage))
            {
                float enemydamage = damage.damage;
                TakeDamage(other.gameObject, enemydamage);
            }
        }
    }

    public void ActualizaMovimiento(float hInput)
    {
        seActualizaMovimiento?.Invoke(hInput); // "?" null safety, si tienes suscriptores ps lo lanza si no no explota
    }

    public void TakeDamage(GameObject o, float damage) //EL JUGADOR RECIBE DAÑO
    {
        if (o != null)
        {
            if (o.TryGetComponent<Bat>(out Bat bat))
            {
                currentHealth -= damage;
                healthText.text = currentHealth.ToString();
                
            }
            if (o.TryGetComponent<Slime>(out Slime slime))
            {
                currentHealth -= damage;
                healthText.text = currentHealth.ToString();
            }
        }
    }
}
