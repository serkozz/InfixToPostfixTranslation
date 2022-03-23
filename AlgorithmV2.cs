using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgebraicExpressionsTranslation
{
    class AlgorithmV2
    {
        string inputString;
        char[] inputStringCharArray;
        const char stringEndSymbol = '\0';
        const char whiteSpace = ' ';

        string outputString = String.Empty;
        const byte outputCharArraySize = 200;
        char[] outputCharArray = new char[200];

        const byte stackSize = 80;
        char[] stack = new char[stackSize];
        byte stackPointer = 0;

        bool isTactMode = false;
        public static bool tactAvailableFlag = true;

        public AlgorithmV2(string inputString, bool isTactMode)
        {
            if (inputString != null)
            {
                this.inputString = inputString;
                this.inputString += stringEndSymbol;
                this.isTactMode = isTactMode;
            }
            else
            {
                this.inputString = "H+E+L+L";
                this.inputString += stringEndSymbol;
                this.isTactMode = isTactMode;
            }
        }

        public void General() // Общий метод (main своего рода )
        {
            inputStringCharArray = inputString.ToCharArray();
            if (!isTactMode)
            {
                CreatePostfix(inputStringCharArray);
                outputString = string.Join(null, outputCharArray);
            }

            if (isTactMode)
            {
                CreatePostfixTact(inputStringCharArray);
                outputString = string.Join(null, outputCharArray);
            }
        }

        public string GetOutputString() // Получение выходной строки
        {
            return outputString;
        }

        public string GetInputString() // Получение входной строки
        {
            return inputString;
        }

        int GetStackPointerPos() // Получение позиции стекпоинтера
        {
            return stackPointer;
        }

        char GetStackElement(int index) // Получить элемент стека по индексу
        {
            return stack[index];
        }

        void DeleteLastStackItem() // Удалить элемент на верхушке стека
        {
            stackPointer--;
        }

        bool IsStackEmpty() // Возвращает true при пустом стеке, else false
        {
            return (stackPointer == 0) ? true : false;
        }

        bool isOperation(char input) // Определеяет, является ли очередной символ символом операции (Возвращает false если true !!!!!! Это важно!!!!)
        {
            return (input == '+' || input == '-' ||
                input == '/' || input == '^' ||
                input == '*' || input == '(' ||
                input == ')' || input == '\0') ? false : true;
        }

        char Pop() // Извлечь элемент находящийся на верхушке стека
        {
            if (stackPointer >= 0)
            {
                stackPointer--;
                return stack[stackPointer];
            }
            else
                return whiteSpace;
        }

        void Push(char symbol) // Внести на вершину стека значение
        {
            if (stackPointer == stackSize)
                return;
            stack[stackPointer] = symbol;
            stackPointer++;
        }

        void CreatePostfix(char[] inputCharArray)
        {
            int i = 0; // Индекс очередного символа входной строки
            int j = 0; // Индекс очередного символа выходной строки

            while (i < inputCharArray.Length)
            {
                if (isOperation(inputCharArray[i])) // Если входной символ не операция (isOperation(char) == false if char == operationSymbol (+, -, *, /, ...)) а переменная, то вставляем его в выходную строку
                {
                    outputCharArray[j] = inputCharArray[i];
                    j++;
                    i++;
                }
                else
                {
                    if (IsStackEmpty()) // Если стек пустой, то пихнуть в стек символ входной строки
                    {
                        Push(inputCharArray[i]);
                        i++;
                    }
                    else // Если стек не пустой, то в зависимости от его верхушки и входного символа производим операции
                    {
                        switch (GetDecisionTableValue(inputCharArray[i], GetStackElement((GetStackPointerPos() - 1))))
                        {
                            case 0:
                                Console.WriteLine("Непредусмотренная ситуация!!!");
                                return;
                            case 1:
                                Push(inputCharArray[i]);
                                i++;
                                break;
                            case 2:
                                outputCharArray[j] = Pop();
                                j++;
                                break;
                            case 3:
                                DeleteLastStackItem();
                                i++;
                                break;
                            case 4:
                                if (!IsStackEmpty())
                                {
                                    while (!IsStackEmpty())
                                    {
                                        outputCharArray[j] = Pop();
                                        j++;
                                    }
                                }
                                break;
                            case 5:
                                Console.WriteLine("Некорректно составлено выражение!!!");
                                return;
                        }
                    }
                }
            }
        }

        void CreatePostfixTact(char[] inputCharArray)
        {
            int i = 0; // Индекс очередного символа входной строки
            int j = 0; // Индекс очередного символа выходной строки

            while (tactAvailableFlag)
            {
                while (i < inputCharArray.Length)
                {
                    if (isOperation(inputCharArray[i])) // Если входной символ не операция (isOperation(char) == false if char == operationSymbol (+, -, *, /, ...)) а переменная, то вставляем его в выходную строку
                    {
                        outputCharArray[j] = inputCharArray[i];
                        j++;
                        i++;
                        tactAvailableFlag = false;
                    }
                    else
                    {
                        if (IsStackEmpty()) // Если стек пустой, то пихнуть в стек символ входной строки
                        {
                            Push(inputCharArray[i]);
                            i++;
                            tactAvailableFlag = false;
                        }
                        else // Если стек не пустой, то в зависимости от его верхушки и входного символа производим операции
                        {
                            switch (GetDecisionTableValue(inputCharArray[i], GetStackElement((GetStackPointerPos() - 1))))
                            {
                                case 0:
                                    Console.WriteLine("Непредусмотренная ситуация!!!");
                                    tactAvailableFlag = false;
                                    return;
                                case 1:
                                    Push(inputCharArray[i]);
                                    i++;
                                    tactAvailableFlag = false;
                                    break;
                                case 2:
                                    outputCharArray[j] = Pop();
                                    j++;
                                    tactAvailableFlag = false;
                                    break;
                                case 3:
                                    DeleteLastStackItem();
                                    i++;
                                    tactAvailableFlag = false;
                                    break;
                                case 4:
                                    if (!IsStackEmpty())
                                    {
                                        while (!IsStackEmpty())
                                        {
                                            outputCharArray[j] = Pop();
                                            j++;
                                            tactAvailableFlag = false;
                                            break;
                                        }
                                    }
                                    break;
                                case 5:
                                    Console.WriteLine("Некорректно составлено выражение!!!");
                                    tactAvailableFlag = false;
                                    return;
                            }
                        }
                    }
                }
            }
        }

        int GetDecisionTableValue(char inputChar, char stackTopItem) // Переделать return, сделать читабельнее
        {

            if (inputChar == '\0' && stackTopItem == '\0') // Пустой стек и пустая строка = завершение алгоритма
                return 4;
            else if ((inputChar == '\0' && stackTopItem == '(') && (inputChar == ')' && stackTopItem == '\0')) // Некорректно составлено выражение (отсутствует скобка)
                return 5;
            else if (inputChar == ')' && stackTopItem == '(') // удаление скобки из стека (законченное выражение в скобках)
                return 3;
            else if ((inputChar == '\0' && stackTopItem == '+' || inputChar == '\0' && stackTopItem == '-' || inputChar == '\0' && stackTopItem == '*' || inputChar == '\0' && stackTopItem == '/' || inputChar == '\0' && stackTopItem == '^' ||
                inputChar == '+' && stackTopItem == '+' || inputChar == '+' && stackTopItem == '-' || inputChar == '+' && stackTopItem == '*' || inputChar == '+' && stackTopItem == '/' || inputChar == '+' && stackTopItem == '^' ||
                inputChar == '-' && stackTopItem == '+' || inputChar == '-' && stackTopItem == '-' || inputChar == '-' && stackTopItem == '*' || inputChar == '-' && stackTopItem == '/' || inputChar == '-' && stackTopItem == '^' ||
                inputChar == '*' && stackTopItem == '*' || inputChar == '*' && stackTopItem == '/' || inputChar == '*' && stackTopItem == '^' ||
                inputChar == '/' && stackTopItem == '*' || inputChar == '/' && stackTopItem == '/' || inputChar == '/' && stackTopItem == '^' ||
                inputChar == '^' && stackTopItem == '^' ||
                inputChar == ')' && stackTopItem == '+' || inputChar == ')' && stackTopItem == '-' || inputChar == ')' && stackTopItem == '*' || inputChar == ')' && stackTopItem == '/' || inputChar == ')' && stackTopItem == '^'))
                // Если во входной строке символ с приоритетом меньше или равным приоритету символа на вершине стека, то извлекаем символ из стека в выходную строку
                return 2;
            else if ((inputChar == '+' && stackTopItem == '\0' ||
                inputChar == '-' && stackTopItem == '\0' ||
                inputChar == '*' && stackTopItem == '\0' || inputChar == '*' && stackTopItem == '+' || inputChar == '*' && stackTopItem == '-' ||
                inputChar == '/' && stackTopItem == '\0' || inputChar == '/' && stackTopItem == '+' || inputChar == '/' && stackTopItem == '-' ||
                inputChar == '^' && stackTopItem == '\0' || inputChar == '^' && stackTopItem == '+' || inputChar == '^' && stackTopItem == '-' || inputChar == '^' && stackTopItem == '*' || inputChar == '^' && stackTopItem == '/' ||
                inputChar == '(' && stackTopItem == '\0' || inputChar == '(' && stackTopItem == '+' || inputChar == '(' && stackTopItem == '-' || inputChar == '(' && stackTopItem == '*' || inputChar == '(' && stackTopItem == '/' || inputChar == '(' && stackTopItem == '^' || inputChar == '(' && stackTopItem == ')' ||
                stackTopItem == '(' && inputChar == '+' || stackTopItem == '(' && inputChar == '-' || stackTopItem == '(' && inputChar == '*' || stackTopItem == '(' && inputChar == '/' || stackTopItem == '(' && inputChar == '^' || stackTopItem == '(' && inputChar == '(' ||
                inputChar == 'a' && stackTopItem == 'a' || inputChar == 'a' && stackTopItem == 'b' || inputChar == 'a' && stackTopItem == 'c' || inputChar == 'a' && stackTopItem == 'd' ||
                inputChar == 'b' && stackTopItem == 'b' || inputChar == 'b' && stackTopItem == 'b' || inputChar == 'b' && stackTopItem == 'c' || inputChar == 'b' && stackTopItem == 'd' ||
                inputChar == 'c' && stackTopItem == 'a' || inputChar == 'c' && stackTopItem == 'b' || inputChar == 'c' && stackTopItem == 'c' || inputChar == 'c' && stackTopItem == 'd' ||
                inputChar == 'd' && stackTopItem == 'a' || inputChar == 'd' && stackTopItem == 'b' || inputChar == 'd' && stackTopItem == 'c' || inputChar == 'd' && stackTopItem == 'd'))
                // Если во входной строке символ с приоритетом большим чем приоритет символа на верхушке стека, то добавляем символ входной строки в стек
                return 1;
            else // В другом случае ошибка составления выражения 
                return 0;
        }
    }
}
