using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*

Ambie!

I love you.

I hope you're having a good day :)

<3

I hope this can make you smile, even just a wee bit.

You da bestest. Don't go forgetting it like you forget how to spell Phoebreeze.

Or when you forget to DON'T LAUGH.

^_^

- A

*/

public class AutomaticTileGenerator : MonoBehaviour
{
	public enum TileAdjacency
	{
		N,
		B, T, L, R
	}

	public enum TileConnectionState
	{
		N,
		B, T, L, R,
		BT, BL, BR, TL, TR, LR,
		BTL, BTR, BLR, TLR,
		BTLR
	}

	public TileConnectionState m_State;

	[Header("Tile Search Layer")]
	public LayerMask m_TileSearchLayerMask;

	[Header("Grid")]
	public Vector2 m_GridOffset;

	[Header("Tile Base")]
	public Sprite[] m_TileBaseNConnectVariants;

	public Sprite[] m_TileBaseBConnectVariants;
	public Sprite[] m_TileBaseTConnectVariants;
	public Sprite[] m_TileBaseSConnectVariants;

	public Sprite[] m_TileBaseBTConnectVariants;
	public Sprite[] m_TileBaseBSConnectVariants;
	public Sprite[] m_TileBaseTSConnectVariants;
	public Sprite[] m_TileBaseSSConnectVariants;

	public Sprite[] m_TileBaseBTSConnectVariants;
	public Sprite[] m_TileBaseBSSConnectVariants;
	public Sprite[] m_TileBaseTSSConnectVariants;

	public Sprite[] m_TileBaseBTSSConnectVariants;

	[Header("Tile Flooring")]
	public Sprite[] m_TileFloorVariants;

	[Header("Tile Connectors")]
	public Sprite[] m_TileBTConnectorVariants;
	public Sprite[] m_TileSSConnectorVariants;

	[Header("Tile Corner Connectors")]
	public Sprite m_TileCornerConnector;

	[Header("Tile Centers")]
	public Sprite[] m_TileCenterVariants;

	// Use this for initialization
	void Start() 
	{
		IdentifyState();
		BuildTileBase();
		BuildTileCenter();
		BuildTileFloor();
		BuildTileConnectors();
		GetComponent<SpriteRenderer>().enabled = false;
	}
	
	// Update is called once per frame
	void Update()
	{
		
	}

	private Vector2 RMultiply(Vector2 _a, Vector2 _b)
	{
		return new Vector2(_a.x * _b.x, _a.y * _b.y);	
	}

	private Vector3 V3(Vector2 _a)
	{
		return new Vector3(_a.x, _a.y, 0.0f);
	}

	private void BuildTileFloor()
	{
		if (!m_State.ToString().Contains("T"))
		{
			GameObject tileFloor = new GameObject("Tile Floor");
			tileFloor.transform.parent = transform;
			tileFloor.transform.localPosition = new Vector3(0.0f, 0.0f, -0.5f);
			tileFloor.transform.localRotation = Quaternion.identity;
			tileFloor.transform.localScale = Vector3.one;

			tileFloor.AddComponent<SpriteRenderer>();

			tileFloor.GetComponent<SpriteRenderer>().sprite = GetRandomSprite(m_TileFloorVariants);
		}
	}

	private void BuildTileConnectors()
	{
		if (m_State.ToString().Contains("B"))
		{
			BuildTileSideConnector(TileAdjacency.B);
			if (m_State.ToString().Contains("L"))
			{
				BuildTileCornerConnector(TileAdjacency.B);
			}
		}
		if (m_State.ToString().Contains("T"))
		{
			BuildTileSideConnector(TileAdjacency.T);
			if (m_State.ToString().Contains("R"))
			{
				BuildTileCornerConnector(TileAdjacency.T);
			}
		}
		if (m_State.ToString().Contains("L"))
		{
			BuildTileSideConnector(TileAdjacency.L);
			if (m_State.ToString().Contains("T"))
			{
				BuildTileCornerConnector(TileAdjacency.L);
			}
		}
		if (m_State.ToString().Contains("R"))
		{
			BuildTileSideConnector(TileAdjacency.R);
			if (m_State.ToString().Contains("B"))
			{
				BuildTileCornerConnector(TileAdjacency.R);
			}
		}
	}

	private void BuildTileSideConnector(TileAdjacency _type)
	{
		GameObject tileConnector = new GameObject("Tile Connector");
		tileConnector.transform.parent = transform;
		tileConnector.transform.localPosition = new Vector3(0.0f, 0.0f, -0.5f);
		tileConnector.transform.localRotation = Quaternion.identity;
		tileConnector.transform.localScale = Vector3.one;

		tileConnector.AddComponent<SpriteRenderer>();

		bool requiresFlipX = false;
		bool requiresFlipY = false;
		switch (_type)
		{
			case TileAdjacency.B:
			{
				tileConnector.GetComponent<SpriteRenderer>().sprite = GetRandomSprite(m_TileBTConnectorVariants);
			} break;
			case TileAdjacency.T:
			{
				tileConnector.GetComponent<SpriteRenderer>().sprite = GetRandomSprite(m_TileBTConnectorVariants);
				requiresFlipY = true;
			} break;
			case TileAdjacency.L:
			{
				tileConnector.GetComponent<SpriteRenderer>().sprite = GetRandomSprite(m_TileSSConnectorVariants);
				requiresFlipX = true;
			} break;
			case TileAdjacency.R:
			{
				tileConnector.GetComponent<SpriteRenderer>().sprite = GetRandomSprite(m_TileSSConnectorVariants);
			} break;
			default: { } break;
		}
		tileConnector.GetComponent<SpriteRenderer>().flipX = requiresFlipX;
		tileConnector.GetComponent<SpriteRenderer>().flipY = requiresFlipY;
	}

	private void BuildTileCornerConnector(TileAdjacency _type)
	{
		GameObject tileConnector = new GameObject("Tile Corner Connector");
		tileConnector.transform.parent = transform;
		tileConnector.transform.localPosition = new Vector3(0.0f, 0.0f, -0.5f);
		tileConnector.transform.localRotation = Quaternion.identity;
		tileConnector.transform.localScale = Vector3.one;

		tileConnector.AddComponent<SpriteRenderer>();
		tileConnector.GetComponent<SpriteRenderer>().sprite = m_TileCornerConnector;

		bool requiresFlipX = false;
		bool requiresFlipY = false;
		switch (_type)
		{
			case TileAdjacency.B:
			{
				requiresFlipX = true;
			} break;
			case TileAdjacency.T:
			{
				requiresFlipY = true;
			} break;
			case TileAdjacency.L:
			{
				requiresFlipX = true;
				requiresFlipY = true;
			} break;
			default: { } break;
		}
		tileConnector.GetComponent<SpriteRenderer>().flipX = requiresFlipX;
		tileConnector.GetComponent<SpriteRenderer>().flipY = requiresFlipY;
	}

	private void BuildTileCenter()
	{
		GameObject tileCenter = new GameObject("Tile Center");
		tileCenter.transform.parent = transform;
		tileCenter.transform.localPosition = new Vector3(0.0f, -0.025f, -0.5f);
		tileCenter.transform.localRotation = Quaternion.Euler(new Vector3(0.0f, 0.0f, 90.0f * Random.Range(0, 4)));
		tileCenter.transform.localScale = Vector3.one * 0.95f;

		tileCenter.AddComponent<SpriteRenderer>();

		tileCenter.GetComponent<SpriteRenderer>().sprite = GetRandomSprite(m_TileCenterVariants);
	}

	private void BuildTileBase()
	{
		GameObject tileBase = new GameObject("Tile Base");
		tileBase.transform.parent = transform;
		tileBase.transform.localPosition = Vector3.zero;
		tileBase.transform.localRotation = Quaternion.identity;
		tileBase.transform.localScale = Vector3.one;

		tileBase.AddComponent<SpriteRenderer>();

		bool requiresFlip = false;
		switch (m_State)
		{
			case TileConnectionState.N:
			{
				tileBase.GetComponent<SpriteRenderer>().sprite = GetRandomSprite(m_TileBaseNConnectVariants);
			} break;
			case TileConnectionState.B:
			{
				tileBase.GetComponent<SpriteRenderer>().sprite = GetRandomSprite(m_TileBaseBConnectVariants);
			} break;
			case TileConnectionState.T:
			{
				tileBase.GetComponent<SpriteRenderer>().sprite = GetRandomSprite(m_TileBaseTConnectVariants);
			} break;
			case TileConnectionState.L:
			{
				tileBase.GetComponent<SpriteRenderer>().sprite = GetRandomSprite(m_TileBaseSConnectVariants);
				requiresFlip = true;
			} break;
			case TileConnectionState.R:
			{
				tileBase.GetComponent<SpriteRenderer>().sprite = GetRandomSprite(m_TileBaseSConnectVariants);
			} break;
			case TileConnectionState.BT:
			{
				tileBase.GetComponent<SpriteRenderer>().sprite = GetRandomSprite(m_TileBaseBTConnectVariants);
			} break;
			case TileConnectionState.BL:
			{
				tileBase.GetComponent<SpriteRenderer>().sprite = GetRandomSprite(m_TileBaseBSConnectVariants);
				requiresFlip = true;
			} break;
			case TileConnectionState.BR:
			{
				tileBase.GetComponent<SpriteRenderer>().sprite = GetRandomSprite(m_TileBaseBSConnectVariants);
			} break;
			case TileConnectionState.TL:
			{
				tileBase.GetComponent<SpriteRenderer>().sprite = GetRandomSprite(m_TileBaseTSConnectVariants);
				requiresFlip = true;
			} break;
			case TileConnectionState.TR:
			{
				tileBase.GetComponent<SpriteRenderer>().sprite = GetRandomSprite(m_TileBaseTSConnectVariants);
			} break;
			case TileConnectionState.LR:
			{
				tileBase.GetComponent<SpriteRenderer>().sprite = GetRandomSprite(m_TileBaseSSConnectVariants);
			} break;
			case TileConnectionState.BTL:
			{
				tileBase.GetComponent<SpriteRenderer>().sprite = GetRandomSprite(m_TileBaseBTSConnectVariants);
				requiresFlip = true;
			} break;
			case TileConnectionState.BTR:
			{
				tileBase.GetComponent<SpriteRenderer>().sprite = GetRandomSprite(m_TileBaseBTSConnectVariants);
			} break;
			case TileConnectionState.BLR:
			{
				tileBase.GetComponent<SpriteRenderer>().sprite = GetRandomSprite(m_TileBaseBSSConnectVariants);
			} break;
			case TileConnectionState.TLR:
			{
				tileBase.GetComponent<SpriteRenderer>().sprite = GetRandomSprite(m_TileBaseTSSConnectVariants);
			} break;
			case TileConnectionState.BTLR:
			{
				tileBase.GetComponent<SpriteRenderer>().sprite = GetRandomSprite(m_TileBaseBTSSConnectVariants);
			} break;
			default: {} break;
		}
		tileBase.GetComponent<SpriteRenderer>().flipX = requiresFlip;
	}

	private TileConnectionState IdentifyState()
	{
		bool bot, top, left, right;
		bot = Physics2D.OverlapPoint(transform.position + V3(RMultiply(m_GridOffset, Vector2.down)), m_TileSearchLayerMask);
		top = Physics2D.OverlapPoint(transform.position + V3(RMultiply(m_GridOffset, Vector2.up)), m_TileSearchLayerMask);
		left = Physics2D.OverlapPoint(transform.position + V3(RMultiply(m_GridOffset, Vector2.left)), m_TileSearchLayerMask);
		right = Physics2D.OverlapPoint(transform.position + V3(RMultiply(m_GridOffset, Vector2.right)), m_TileSearchLayerMask);

		TileConnectionState state = TileConnectionState.N;
		string enumString = "";
		enumString += bot ? "B" : "";
		enumString += top ? "T" : "";
		enumString += left ? "L" : "";
		enumString += right ? "R" : "";
		if (enumString == "")
		{
			enumString = "N";
		}
		state = (TileConnectionState)System.Enum.Parse(typeof(TileConnectionState), enumString, true);
		m_State = state;
		return state;
	}

	private Sprite GetRandomSprite(Sprite[] _spriteArray)
	{
		return _spriteArray[Random.Range(0, _spriteArray.Length)];
	}
}
