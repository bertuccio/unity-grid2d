﻿using UnityEngine;
using System.Collections;

public class Fighter
{
	public int max_hp;
	public int hp;
	public int defense;
	public int power;

	public Fighter (int hp, int defense, int power)
	{
		this.max_hp = hp;
		this.hp = hp;
		this.defense = defense;
		this.power = power;
	}

	public string attack(Entity self, Entity target)
	{
		//a simple formula for attack damage
		int damage = self.fighterComponent.power - target.fighterComponent.defense;
			
		string info = "";
		if (damage > 0)
		{
			info = self.name + " attacks " + target.name + " for " + damage + " hit points.\n";
			info = target.fighterComponent.takeDamage(target, damage) + info;
		}
		else
		{
			info = self.name + " attacks " + target.name + " but it has no effect.\n";
		}

		return info;
	}

	public string takeDamage(Entity self, int damage)
	{
		if (damage > 0)
		{
			hp -= damage;
			self.GetComponent<Animator>().SetTrigger("takeDamage");
			self.gameObject.GetComponentInChildren<HealthBarScale>().setScalePercent((float)hp/(float)max_hp);
			//if (self.ai != null)
				self.gameObject.GetComponentInChildren<DamagePopupSpawner>().spawnDamagePopup(damage);
			if (hp <= 0)
			{
				self.GetComponent<Animator>().SetTrigger("die");
				self.blocks = false;
				self.ai = null;
				self.GetComponent<SpriteRenderer>().sortingOrder -= 1;
				return self.name + " has been defeated.\n";
			}
		}
		return "";
	}
}
