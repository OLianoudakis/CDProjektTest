using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FireGun : MonoBehaviour
{
    [SerializeField]
    private GameObject m_bullet;
    [SerializeField]
    private GameObject m_bulletCap;
    [SerializeField]
    private float m_loadedAmmo;
    [SerializeField]
    private float m_magAmmo;
    [SerializeField]
    private float m_bulletForce;
    [SerializeField]
    private float m_fireRate = 0.33f;
    [SerializeField]
    private int m_bulletDamage;
    [SerializeField]
    private CanvasGroup m_reloadUI;

    [SerializeField]
    private Text m_ammoUI;
    [SerializeField]
    private Text m_magAmmoUI;

    private InputController m_inputController;
    private Animator m_animator;
    private Transform m_bulletTransform;
    private Transform m_bulletCapTransform;

    private float m_timeStamp = 0.0f;

    public void PickUpAmmo()
    {
        m_magAmmo += 12;
        UpdateUI();
    }

    private void UpdateUI()
    {
        m_ammoUI.text = m_loadedAmmo.ToString();
        m_magAmmoUI.text = m_magAmmo.ToString();
    }

    private void Shoot()
    {
        if (Time.time >= m_timeStamp && m_inputController.FireButtonDown && m_loadedAmmo > 0)
        {
            Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0.0f));
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                GameObject bulletCapInstance;
                bulletCapInstance = Instantiate(m_bulletCap, m_bulletCapTransform.transform.position, m_bulletCapTransform.rotation);
                (bulletCapInstance.GetComponent(typeof(Rigidbody)) as Rigidbody).AddForce(m_bulletCapTransform.right * 1000);

                Vector3 collisionPoint = hit.point;
                Vector3 bulletVector = collisionPoint - m_bulletTransform.position;
                GameObject bulletInstance = Instantiate(m_bullet, m_bulletTransform);
                bulletInstance.transform.parent = null;
                (bulletInstance.GetComponent(typeof(Rigidbody)) as Rigidbody).velocity = (bulletVector * m_bulletForce);

                m_timeStamp = Time.time + m_fireRate;
                m_loadedAmmo = m_loadedAmmo - 1;
                UpdateUI();
            }
        }

        if (m_loadedAmmo <= 0 && m_magAmmo > 0)
        {
            m_reloadUI.alpha = 1.0f;
        }
        else
        {
            m_reloadUI.alpha = 0.0f;
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            if (m_loadedAmmo < 12 && m_magAmmo > 0)
            {
                if (m_magAmmo > 12.0f - m_loadedAmmo)
                {
                    m_magAmmo -= (12.0f - m_loadedAmmo);
                    m_loadedAmmo = 12;
                }
                else
                {
                    m_loadedAmmo += m_magAmmo;
                    m_magAmmo = 0.0f;
                }               
            }
            UpdateUI();
        }
    }

    private void Awake()
    {
        m_inputController = transform.parent.parent.GetComponent(typeof(InputController)) as InputController;
        m_animator = transform.parent.parent.Find("Main Camera").Find("WeaponSlot").Find("Gun").GetComponent(typeof(Animator)) as Animator;
        m_bulletTransform = transform.parent.parent.Find("Main Camera").Find("WeaponSlot").Find("Gun").Find("BulletPoint");
        m_bulletCapTransform = transform.parent.parent.Find("Main Camera").Find("WeaponSlot").Find("Gun").Find("BulletCap");

        (m_bullet.GetComponent(typeof(BulletStats)) as BulletStats).BulletDamage = m_bulletDamage;
        UpdateUI();
    }

    private void Update()
    {
        Shoot();
    }
}