using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Enums;

public class Character : Actor
{
    [SerializeField] private List<Gun> _guns;
    [SerializeField] private Gun _currentGun;

    [SerializeField] private CharacterStats _characterStats;
    private CmdAttack _cmdAttack;
    private CmdReload _cmdReload;
    
    #region KEY_BINDINGS
    [SerializeField] private KeyCode _moveForward = KeyCode.W;
    [SerializeField] private KeyCode _moveBack = KeyCode.S;
    [SerializeField] private KeyCode _moveLeft = KeyCode.A;
    [SerializeField] private KeyCode _moveRight = KeyCode.D;
    

    [SerializeField] private KeyCode _attack = KeyCode.Mouse0;
    [SerializeField] private KeyCode _reload = KeyCode.R;

    [SerializeField] private KeyCode _GunSlot1 = KeyCode.Alpha1;
    [SerializeField] private KeyCode _GunSlot2 = KeyCode.Alpha2;
    [SerializeField] private KeyCode _GunSlot3 = KeyCode.Alpha3;


    #endregion

    #region UNITY_EVENTS
    void Start()
    {
        base.stats = _characterStats;
        base.Start();
        SwitchGuns(0);

        InitMovementCommands();
    }

    void Update()
    {
        //Shoot Bullet
        if(Input.GetKeyDown(_attack)) EventQueueManager.instance.AddCommand(_cmdAttack);
        if(Input.GetKeyDown(_reload)) EventQueueManager.instance.AddCommand(_cmdReload);

        //Equip Bullet
        if(Input.GetKeyDown(_GunSlot1)) SwitchGuns(Weapon.Pistol);
        if(Input.GetKeyDown(_GunSlot2)) SwitchGuns(Weapon.Machinegun);
        if(Input.GetKeyDown(_GunSlot3)) SwitchGuns(Weapon.Shotgun);

        //GameOver conditions
        if(Input.GetKeyDown(KeyCode.Return)) EventsManager.instance.EventGameOver(true);
        if(Input.GetKeyDown(KeyCode.Backspace)) TakeDamage(7);
    }

    private void FixedUpdate() {
        if(Input.GetKey(_moveForward)) EventQueueManager.instance.AddCommand(_cmdMoveForward);
        if(Input.GetKey(_moveBack)) EventQueueManager.instance.AddCommand(_cmdMoveBack);
        if(Input.GetKey(_moveLeft))  EventQueueManager.instance.AddCommand(_cmdTurnLeft);
        if(Input.GetKey(_moveRight))  EventQueueManager.instance.AddCommand(_cmdTurnRight);
    }
    #endregion

    #region MOVEMENT_COMMAND
    private CmdMovement _cmdMoveForward;
    private CmdMovement _cmdMoveBack;
    private CmdRotateActor _cmdTurnLeft;
    private CmdRotateActor _cmdTurnRight;

    private void InitMovementCommands()
    {
        _cmdMoveForward = new CmdMovement(transform,Vector3.forward,_characterStats.MovementSpeed);
        _cmdMoveBack = new CmdMovement(transform,-Vector3.forward,_characterStats.MovementSpeed);
        _cmdTurnLeft = new CmdRotateActor(transform,-Vector3.up,_characterStats.RotationSpeed);
        _cmdTurnRight = new CmdRotateActor(transform,Vector3.up,_characterStats.RotationSpeed);
    }
    #endregion

    private void SwitchGuns(Weapon index){
        foreach(Gun gun in _guns){
            gun.gameObject.SetActive(false);
        }
        _guns[(int)index].gameObject.SetActive(true);
        _currentGun = _guns[(int)index];

        _cmdAttack = new CmdAttack(_currentGun);
        _cmdReload = new CmdReload(_currentGun);

        EventQueueManager.instance.AddCommand(_cmdReload);
        EventsManager.instance.WeaponChange(index);
    }
}