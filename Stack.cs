using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgebraicExpressionsTranslation
{
    public class Stack
    {
        const byte stackSize = 15;
        const string whiteSpace = " ";
        char[] transformationStack; // был статик и пустой конструктор
        double[] calculationStack; // был статик и пустой конструктор
        byte stackPointer = 1;
        
        public enum StackType
        {
            TransformationStack,
            CalculationStack
        }
        public Stack(StackType stackType)
        {
            if (stackType == StackType.CalculationStack)
            {
                double[] calculationStack = new double[stackSize];
                this.calculationStack = calculationStack;
            }

            if (stackType == StackType.TransformationStack)
            {
                char[] transformationStack = new char[stackSize];
                this.transformationStack = transformationStack;
            }
        }

        public int GetStackPointerPos() // Получение позиции стекпоинтера
        {
            return stackPointer;
        }

        public char[] GetStack() // Возвращает стек
        {
            char[] temp = new char[stackSize];

            for (int i = 0; i < stackSize; i++)
            {
                temp[i] = transformationStack[i];
            }

            return temp;
        }

        public char GetStackElement(int index) // Получить элемент стека по индексу (используется в слое представления)
        {
            if (index >= 0)
                return transformationStack[index];
            else
                return Convert.ToChar(whiteSpace);
        }
        public double GetStackElement(int index, bool plug) // Получить элемент стека по индексу (заглушка дифференцирует перегрузки методов)
        {
            if (index >= 0)
                return calculationStack[index];
            else
                return 0;
        }

        public void DeleteLastStackItem(int times) // Удалить элемент на верхушке стека (сдвинуть указатель)
        {
            for (int i = 0; i < times; i++)
            {
                stackPointer--;
            }
        }

        public bool IsStackEmpty() // Возвращает true при пустом стеке, else false
        {
            return (stackPointer == 0) ? true : false;
        }

        public char Pop() // Извлечь элемент находящийся на верхушке стека (со сдвигом указателя (используется в модельном слое))
        {
            if (GetStackPointerPos() > 0)
            {
                stackPointer--;
                return transformationStack[stackPointer];
            }
            else
                return Convert.ToChar(whiteSpace);
        }
        
        public double Pop(bool plug) // Извлечь элемент находящийся на верхушке стека (со сдвигом указателя (заглушка не используется))
        {
            if (GetStackPointerPos() > 0)
            {
                stackPointer--;
                return calculationStack[stackPointer];
            }
            else
                return 0;
        }

        public void Push(char symbol) // Внести на вершину стека значение (со сдвигом указателя (используется в модельном слое))
        {
            if (stackPointer == stackSize)
            {
                System.Windows.Forms.MessageBox.Show("Переполнение стека");
                return;
            }
            transformationStack[stackPointer] = symbol;
            stackPointer++;
        }

        public void Push(double value) // Внести на вершину стека значение (перегрузка для вычисления постфикса)
        {
            if (stackPointer == stackSize)
            {
                System.Windows.Forms.MessageBox.Show("Переполнение стека");
                return;
            }
            calculationStack[stackPointer] = value;
            stackPointer++;
        }
    }
}
