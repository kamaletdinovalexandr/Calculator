using System.Collections.Generic;
using UnityEditor;

public class Calculator {
    public int Result { get; private set; }

    public void Operation(Operations @operator, int operand) {
        switch (@operator) {
            case Operations.plus: Result += operand; break;
            case Operations.minus: Result -= operand; break;
            case Operations.multiply: Result *= operand; break;
            case Operations.divide: Result /= operand; break;
        }
    }
}
