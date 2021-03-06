﻿using System.Collections.Generic;
using UnityEngine;

class CopterCat : Enemy
{
	[SerializeField]
	GameObject bulletPrefab;
	[SerializeField]
	Sprite bulletModel;
	Animator animator;
	private void Awake()
	{
		animator = GetComponent<Animator>();
		InvokeRepeating("FireBullets", 0, 5);
	}

	private void Update()
	{

	}

	private void FireBullets()
	{
		if (isActive)
		{
			Vector3 playerPos = PlayerInfo.Instance.playerControls.gameObject.transform.position;
			Vector3 vecDiff = (playerPos - this.transform.position).normalized;

			GameObject g = Instantiate(bulletPrefab, this.transform.position, this.transform.rotation);
			g.transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(vecDiff.y, vecDiff.x) * Mathf.Rad2Deg);
			g.GetComponent<Bullet>().InitializeBullet(bulletModel, 3, false, 0.08f);

			g = Instantiate(bulletPrefab, this.transform.position, this.transform.parent.transform.rotation);
			g.transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(vecDiff.y, vecDiff.x) * Mathf.Rad2Deg - 5f);
			g.GetComponent<Bullet>().InitializeBullet(bulletModel, 3, false, 0.08f);

			g = Instantiate(bulletPrefab, this.transform.position, this.transform.parent.transform.rotation);
			g.transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(vecDiff.y, vecDiff.x) * Mathf.Rad2Deg + 5f);
			g.GetComponent<Bullet>().InitializeBullet(bulletModel, 3, false, 0.08f);
		}
	}

	public override void enemyHit(float damage)
	{
		animator.SetTrigger("EnemyHit");
		base.enemyHit(damage);
	}
}
