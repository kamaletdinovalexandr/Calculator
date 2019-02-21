using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Controller : MonoBehaviour {

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

    CalculateSequence CalculateSequence;
    private int _operandA;
    private int _operandB;
    private int _tmpOperand;
    private bool _showUserInput;
    private CalculatorButtons _operator;

    enum InputStates { operandA, operandB, calculate }
    InputStates _currentState;

    private void Awake() {
        CalculateSequence = new CalculateSequence();
        _showUserInput = true;
        _operator = CalculatorButtons.none;
    }

    private void Start() {        
        Button0.onClick.AddListener(delegate { OnDigidClicked(0); } );
        Button1.onClick.AddListener(delegate { OnDigidClicked(1); } );
        Button2.onClick.AddListener(delegate { OnDigidClicked(2); } );
        Button3.onClick.AddListener(delegate { OnDigidClicked(3); } );
        Button4.onClick.AddListener(delegate { OnDigidClicked(4); } );
        Button5.onClick.AddListener(delegate { OnDigidClicked(5); } );
        Button6.onClick.AddListener(delegate { OnDigidClicked(6); } );
        Button7.onClick.AddListener(delegate { OnDigidClicked(7); } );
        Button8.onClick.AddListener(delegate { OnDigidClicked(8); } );
        Button9.onClick.AddListener(delegate { OnDigidClicked(9); } );
        ButtonPlus.onClick.AddListener(delegate { OnOperationCliked(CalculatorButtons.plus); } );
        ButtonMinus.onClick.AddListener(delegate { OnOperationCliked(CalculatorButtons.minus); } );
        ButtonMultiply.onClick.AddListener(delegate { OnOperationCliked(CalculatorButtons.mul); } );
        ButtonDivide.onClick.AddListener(delegate { OnOperationCliked(CalculatorButtons.div); } );
        ButtonEquals.onClick.AddListener(delegate { OnEqualsClicked(); } );
        ButtonUndo.onClick.AddListener(delegate { OnUndoClicked(); } );

        UpdateDisplay();
        _currentState = InputStates.operandA;
    }

    private void OnDigidClicked(int number) {
        _tmpOperand = (_tmpOperand * 10) + number;
        _showUserInput = true;
        UpdateDisplay();
    }

    private void OnOperationCliked(CalculatorButtons @operator) {
        _operator = @operator;

        if (_currentState == InputStates.operandA) {
            _operandA = _tmpOperand;
            _tmpOperand = 0;
            _currentState = InputStates.operandB;
            return;
        }
           
        if (_currentState == InputStates.operandB) {
            _operandB = _tmpOperand;
            _tmpOperand = 0;
            _currentState = InputStates.calculate;
        } 
    }

    private void OnEqualsClicked() {
        if (_operator == CalculatorButtons.none || _currentState != InputStates.calculate)
            return;

        CalculateSequence.Compute(_operator, _operandA, _operandB);
        _operandB = 0;
        _showUserInput = false;
        _operator = CalculatorButtons.none;
        UpdateDisplay();
    }

    private void OnUndoClicked() {
        CalculateSequence.Undo();
        _showUserInput = false;
        UpdateDisplay();
    }

    private void UpdateDisplay() {
        Display.text = (_showUserInput ? _tmpOperand : CalculateSequence.GetTotal()).ToString();
    }
}
