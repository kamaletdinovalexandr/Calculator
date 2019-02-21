using UnityEditor.PackageManager.Requests;
using UnityEngine;

public class CalculateCommand : ICommand {
    private Operations _operator;
        private int _operand;
        private Calculator _calculator;

    public CalculateCommand(Calculator calculator, Operations @operator, int operand) {
           _calculator = calculator;
           _operator = @operator;
           _operand = operand;
    }

        public void Execute() {
            _calculator.Operation(_operator, _operand);
            Debug.Log("Request operation: " + _operator + " operand: " + _operand);
        }

        public void UnExecute() {
            _calculator.Operation(Undo(_operator), _operand);
            Debug.Log("Undo request operation: " + Undo(_operator) + " operand: " + _operand);
        }

    private Operations Undo(Operations @operator) {
            switch (@operator) {
            case Operations.plus: 
                return Operations.minus;
            case Operations.minus: 
                return Operations.plus;
            case Operations.multiply: 
                return Operations.divide;
            default:
                return  Operations.multiply;
            }
        }
}
