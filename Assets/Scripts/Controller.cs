using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class Controller : MonoBehaviour {

    #region EditorLinks
    [SerializeField] private Text Display;
    [SerializeField] private Button Button0;
    [SerializeField] private Button Button1;
    [SerializeField] private Button Button2;
    [SerializeField] private Button Button3;
    [SerializeField] private Button Button4;
    [SerializeField] private Button Button5;
    [SerializeField] private Button Button6;
    [SerializeField] private Button Button7;
    [SerializeField] private Button Button8;
    [SerializeField] private Button Button9;
    [SerializeField] private Button ButtonPlus;
    [SerializeField] private Button ButtonMinus;
    [SerializeField] private Button ButtonMultiply;
    [SerializeField] private Button ButtonDivide;
    [SerializeField] private Button ButtonEquals;
    [SerializeField] private Button ButtonUndo;
    #endregion

    CalculateSequence CalculateSequence;
    private int _operand;
    private int Operand {
        get { return _operand;}
        set {
            _operand = value;
            Debug.Log("Operand is : " + _operand);
        }
    }
    
    private int _tmpOperand;
    private Operations _operator;

    enum InputStates { operandA, operandB }
    
    InputStates _currentState;

    private void Awake() {
        CalculateSequence = new CalculateSequence();
        _operator = Operations.none;
    }

    private void Start() {        
        Button0.onClick.AddListener(delegate { OnDigitClicked(0); } );
        Button1.onClick.AddListener(delegate { OnDigitClicked(1); } );
        Button2.onClick.AddListener(delegate { OnDigitClicked(2); } );
        Button3.onClick.AddListener(delegate { OnDigitClicked(3); } );
        Button4.onClick.AddListener(delegate { OnDigitClicked(4); } );
        Button5.onClick.AddListener(delegate { OnDigitClicked(5); } );
        Button6.onClick.AddListener(delegate { OnDigitClicked(6); } );
        Button7.onClick.AddListener(delegate { OnDigitClicked(7); } );
        Button8.onClick.AddListener(delegate { OnDigitClicked(8); } );
        Button9.onClick.AddListener(delegate { OnDigitClicked(9); } );
        ButtonPlus.onClick.AddListener(delegate { OnOperationClicked(Operations.plus); } );
        ButtonMinus.onClick.AddListener(delegate { OnOperationClicked(Operations.minus); } );
        ButtonMultiply.onClick.AddListener(delegate { OnOperationClicked(Operations.multiply); } );
        ButtonDivide.onClick.AddListener(delegate { OnOperationClicked(Operations.divide); } );
        ButtonEquals.onClick.AddListener(OnEqualsClicked);
        ButtonUndo.onClick.AddListener(OnUndoClicked);

        UpdateDisplay(_tmpOperand);
        _currentState = InputStates.operandA;
    }

    private void OnDigitClicked(int number) {
        _tmpOperand = (_tmpOperand * 10) + number;
        UpdateDisplay(_tmpOperand);
    }

    private void OnOperationClicked(Operations @operator) {
        _operator = @operator;
        CalculateSequence.Compute(_operator, _tmpOperand);
        _tmpOperand = 0;
    }

    private void OnEqualsClicked() {
        CalculateSequence.Compute(_operator, _tmpOperand);
        UpdateDisplay(CalculateSequence.GetTotal());
        _tmpOperand = 0;
    }

    private void OnUndoClicked() {
        CalculateSequence.Undo();
        UpdateDisplay(CalculateSequence.GetTotal());
        _tmpOperand = 0;
    }

    private void UpdateDisplay(int number) {
        Display.text = number.ToString();
    }
}
