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
        static char[] stack = new char[stackSize];
        byte stackPointer = 1;

        public int GetStackPointerPos() // Получение позиции стекпоинтера
        {
            return stackPointer;
        }

        public char[] GetStack() // Возвращает стек
        {
            char[] temp = new char[stackSize];

            for (int i = 0; i < stackSize; i++)
            {
                temp[i] = stack[i];
            }

            return temp;
        }

        public char GetStackElement(int index) // Получить элемент стека по индексу (используется в слое представления)
        {
            if (index >= 0)
                return stack[index];
            else
                return Convert.ToChar(whiteSpace);
        }

        public void DeleteLastStackItem() // Удалить элемент на верхушке стека (сдвинуть указатель)
        {
            stackPointer--;
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
                return stack[stackPointer];
            }
            else
                return Convert.ToChar(whiteSpace);
        }

        public void Push(char symbol) // Внести на вершину стека значение (со сдвигом указателя (используется в модельном слое))
        {
            if (stackPointer == stackSize)
            {
                System.Windows.Forms.MessageBox.Show("Переполнение стека");
                return;
            }
            stack[stackPointer] = symbol;
            stackPointer++;
        }
    }
}
