using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventQueueManager : MonoBehaviour
{
    #region SINGLETON
    static public EventQueueManager instance;

    private void Awake() 
    {
        if (instance !=null) Destroy(gameObject);
        instance = this;    
    }
    #endregion

    private Queue<ICommand> EventQueue => _eventQueue;
    private Queue<ICommand> _eventQueue = new Queue<ICommand>();

    [SerializeField] private bool _isCharacterStuned;
    [SerializeField] private bool _isCharacterInmune;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.P)) _isCharacterStuned = !_isCharacterStuned;

        while (_eventQueue.Count > 0){

            ICommand command = _eventQueue.Dequeue();
            if(command is CmdMovement && _isCharacterStuned) continue;
            if(command is CmdApplyDamage && _isCharacterInmune) continue;
            command.Do();
        }
    }
    public void AddCommand(ICommand command) => _eventQueue.Enqueue(command);

}

