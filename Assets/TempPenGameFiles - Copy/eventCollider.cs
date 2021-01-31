using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eventCollider : MonoBehaviour
{
	private void OnCollisionEnter(Collision collision)
	{
		if(collision.gameObject.tag == "RisingTemp")
			FindObjectOfType<GameMaster>().TempRising = true;

		if(collision.gameObject.tag == "Gas")
			FindObjectOfType<GameMaster>().GasLeak = true;

		if (collision.gameObject.tag == "Boom")
			FindObjectOfType<GameMaster>().megumin = true;
	}
}
