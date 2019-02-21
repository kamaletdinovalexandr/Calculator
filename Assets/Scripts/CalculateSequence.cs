using System.Collections.Generic;

public class CalculateSequence {

    private Calculator _calculator = new Calculator();
    private List<ICommand> _commands = new List<ICommand>();
    private int _commandIndex = 0;

    public void Undo() {
        if (_commandIndex > 0) {
            ICommand command = _commands[--_commandIndex];
            command.UnExecute();
        }
    }

    public void Compute(Operations @operator, int operand) {
        ICommand command = new CalculateCommand(_calculator, @operator, operand);
        command.Execute();
        _commands.Add(command);
        _commandIndex++;
    }

    public int GetTotal() {
        return _calculator.Result;
    }
}
