using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItanoCircusDemo : MonoBehaviour
{
    public BaseBullet m_bullet;
    public Transform m_emitterContainer;

    private List<Transform> m_emitters = new List<Transform>();

    private void Start()
    {
        m_bullet.gameObject.SetActive(false);
        m_emitters.AddRange(m_emitterContainer.GetComponentsInChildren<Transform>());
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            for (int i = 0; i < m_emitters.Count; i++)
            {
                var e = m_emitters[i];

                GameObject go = Instantiate(m_bullet.gameObject);
                go.SetActive(true);

                go.transform.position = e.position;
                go.transform.rotation = e.rotation;
            }
        }
    }
}
