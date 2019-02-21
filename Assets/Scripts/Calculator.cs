public class Calculator {

    public int Result { get; private set; }

    public void Operation(CalculatorButtons @operator, int operandA, int operandB) {
        switch (@operator) {
            case CalculatorButtons.plus: Result = operandA + operandB; break;
            case CalculatorButtons.minus: Result = operandA - operandB; break;
            case CalculatorButtons.mul: Result = operandA *  operandB; break;
            case CalculatorButtons.div: Result = operandA / operandB; break;
        }
    }
}
