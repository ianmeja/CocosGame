using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CmdAttack : ICommand
{
    private IGun _gun;

    public CmdAttack(IGun gun)
    {
        _gun = gun;
    }
    public void Do()
    {
        EventsManager.instance.AvatarChange(Enums.AvatarFace.ActionFace);
        _gun.Shoot();
    } 
}