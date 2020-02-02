using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Player : MonoBehaviour
{
    private Rigidbody rb;
    public CheckPointSystem checkPointSystem;
    private CharacterController con;
    public GameObject weapon;
    private new Camera camera;
    public TextMeshProUGUI text;

    // Start is called before the first frame update
    void Start()
    {
        camera = Camera.main;
        rb = GetComponent<Rigidbody>();
        con = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        // If the player falls to his death, respawn them at the nearest checkpoint
        if (transform.position.y < -20)
            Die();

        if (weapon != null)
        {
            text.gameObject.SetActive(true);
            if (weapon.name == "Hammer")
                text.text = "Press right click to drop";

        }
    }

    // Respawn the player at the nearest checkpoint
    private void Die()
    {
        con.enabled = false;
        Vector3 checkPointTranform = checkPointSystem.GetRecetCheckPointTransform();
        rb.velocity = new Vector3(0, 0, 0);
        transform.position = new Vector3(checkPointTranform.x,checkPointTranform.y += 2f,checkPointTranform.z);
        con.enabled = true;
    }

    // Pick up a weapon
    public void PickUpWeapon(GameObject obj)
    {
        weapon = obj;
        obj.transform.parent = camera.transform;
    }
}
