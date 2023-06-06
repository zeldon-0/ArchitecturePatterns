using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchitecturePatterns.Part10.Interpreter;
public abstract class Expression
{
    public abstract int Interpret();
}

public class Number : Expression
{
    private int value;

    public Number(int value)
    {
        this.value = value;
    }

    public override int Interpret()
    {
        return value;
    }
}

public class Addition : Expression
{
    private Expression leftOperand;
    private Expression rightOperand;

    public Addition(Expression leftOperand, Expression rightOperand)
    {
        this.leftOperand = leftOperand;
        this.rightOperand = rightOperand;
    }

    public override int Interpret()
    {
        return leftOperand.Interpret() + rightOperand.Interpret();
    }
}

public class Subtraction : Expression
{
    private Expression leftOperand;
    private Expression rightOperand;

    public Subtraction(Expression leftOperand, Expression rightOperand)
    {
        this.leftOperand = leftOperand;
        this.rightOperand = rightOperand;
    }

    public override int Interpret()
    {
        return leftOperand.Interpret() - rightOperand.Interpret();
    }
}