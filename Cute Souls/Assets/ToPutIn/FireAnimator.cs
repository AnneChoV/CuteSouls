using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireAnimator : MonoBehaviour
{
	public SpriteRenderer m_FireRenderer;
	public SpriteRenderer[] m_GlowRenderers;

	public Sprite[] m_FireVariants;
	public Sprite[] m_GlowVariants;

	private float m_SwapTimer;
	public float m_SwapDelay;

	// Use this for initialization
	void Start()
	{
		
	}

	private Sprite GetRandomSprite(Sprite[] _spriteArray)
	{
		return _spriteArray[Random.Range(0, _spriteArray.Length)];
	}

	// Update is called once per frame
	void Update() 
	{
		if (m_SwapTimer + m_SwapDelay < Time.time)
		{
			m_FireRenderer.sprite = GetRandomSprite(m_FireVariants);
			for (int i = 0; i < m_GlowRenderers.Length; i++)
			{
				m_GlowRenderers[i].sprite = GetRandomSprite(m_GlowVariants);
			}
			m_SwapTimer = Time.time;
		}
	}
}
