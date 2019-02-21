public class CalculateCommand : ICommand {
    private CalculatorButtons _operator;
        private int _operandA;
        private int _operandB;
        private Calculator _calculator;

    public CalculateCommand(Calculator calculator, CalculatorButtons @operator, int operandA, int operandB) {
           _calculator = calculator;
           _operator = @operator;
           _operandA = operandA;
           _operandB = operandB;
        }

        public void Execute() {
            _calculator.Operation(_operator, _operandA, _operandB);
        }

        public void UnExecute() {
            _calculator.Operation(Undo(_operator), _operandA, _operandB);
        }

    private CalculatorButtons Undo(CalculatorButtons @operator) {
            switch (@operator) {
            case CalculatorButtons.plus: 
                return CalculatorButtons.minus;
            case CalculatorButtons.minus: 
                return CalculatorButtons.plus;
            case CalculatorButtons.mul: 
                return CalculatorButtons.div;
            default:
                return  CalculatorButtons.mul;
            }
        }
}
