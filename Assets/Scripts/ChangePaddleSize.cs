using UnityEngine;
using System.Collections;
public class ChangePaddleSize : BasePowerUp
{
	//How much units should the paddle change when this powerup is picked up?
	//Can also be negative to shrink the paddle!
	public Vector3 SizeIncrease = Vector3.zero;
	public Vector3 MinPaddleSize = new Vector3(0.1F, 0.4F, 0.4F);
	public Vector3 MaxPaddleSize = new Vector3 (0.6f, 0.4f, 0.4f);
	//Notice how we override we the OnPickup method of the base class
	protected override void OnPickup()
	{
		//Call the default behaviour of the base class first
		base.OnPickup();
		//Then do the powerup specific behaviour, changing the size in this case
		Paddle p = FindObjectOfType(typeof(Paddle)) as Paddle;
		p.transform.localScale += SizeIncrease;
		//Limit the minimal size of the paddle
		Vector3 size = p.transform.localScale;
		if (size.x < MinPaddleSize.x || size.x > MaxPaddleSize.x) {
			size.x = MaxPaddleSize.x;
		}
		if (size.y < MinPaddleSize.y || size.y > MaxPaddleSize.y) {
			size.y = MaxPaddleSize.y;
		}
		if (size.z < MinPaddleSize.z || size.z > MaxPaddleSize.z) {
			size.z = MaxPaddleSize.z;
		}
		p.transform.localScale = size;
	}
}
