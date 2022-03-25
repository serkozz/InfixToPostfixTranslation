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
        byte stackPointer = 1;

        bool isTactMode = false;
        bool isUsingDecisionTable;
        public static bool tactAvailableFlag = true;

        public AlgorithmV2(string inputString, bool isUsingDecisionTable, bool isTactMode)
        {
            if (inputString != null)
            {
                this.inputString = inputString;
                this.inputString += stringEndSymbol;
                this.isUsingDecisionTable = isUsingDecisionTable;
                this.isTactMode = isTactMode;
            }
            else
            {
                this.inputString = "H+E+L+L";
                this.inputString += stringEndSymbol;
                this.isUsingDecisionTable = isUsingDecisionTable;
                this.isTactMode = isTactMode;
            }
        }

        public void General() // Общий метод (main своего рода )
        {
            inputStringCharArray = inputString.ToCharArray();

            if (!isUsingDecisionTable)
            {
                CreatePostfix(inputStringCharArray);
                outputString = string.Join(null, outputCharArray);
            }

            if (isUsingDecisionTable)
            {
                CreatePostfixV2(inputStringCharArray);
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

        void DeleteLastStackItem() // Удалить элемент на верхушке стека (сдвинуть указатель)
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
                input == '*' || /*input == 'a' || 
                input == 'b' || input == 'c' ||
                input == 'd' ||*/ input == '(' ||
                input == ')' || input == '\0') ? false : true;
        }

        char Pop() // Извлечь элемент находящийся на верхушке стека
        {
            if (GetStackPointerPos() > 0) // Было >=
            {
                stackPointer--; // Возможно дело в инкременте и декременте (надо ++поинтер а не поинтер++ например). Изначально тут было поинтер++
                return stack[stackPointer];
            }
            else
                return whiteSpace;
        }

        void Push(char symbol) // Внести на вершину стека значение
        {
            if (stackPointer == stackSize)
                return;
            //stackPointer++;
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

        public byte SymbNumInputStr(char? symbol) // работает, проверено
        {
            string englishAlphabet = "ABCDFFGHIJKLMNOPQRSTUVWXYZ";
            byte result = 0;

            if (symbol == stringEndSymbol)
                return result = 0;
            else
            {
                switch (symbol)
                {
                    case '+':
                        result = 1;
                        break;
                    case '-':
                        result = 2;
                        break;
                    case '*':
                        result = 3;
                        break;
                    case '/':
                        result = 4;
                        break;
                    case '^':
                        result = 5;
                        break;
                    case '(':
                        result = 6;
                        break;
                    case ')':
                        result = 7;
                        break;
                    case 'a': // sin
                        result = 8;
                        break;
                    case 'b': // cos
                        result = 8;
                        break;
                    case 'c': // sqrt
                        result = 8;
                        break;
                    case 'd': // ln
                        result = 8;
                        break;
                }

                if (englishAlphabet.Contains(Convert.ToString(symbol)))
                    result = 9;
            }
            return result;
        }

        public byte SymbNumInStack() // Также работает, но надо устранить проблему с позицией стекпоинтера
        {
            byte result = 0;
            char lastStackSymbol = GetStackElement(stackPointer);

            if (lastStackSymbol != whiteSpace)
            {
                switch (lastStackSymbol)
                {
                    case '+':
                        result = 1;
                        break;
                    case '-':
                        result = 2;
                        break;
                    case '*':
                        result = 3;
                        break;
                    case '/':
                        result = 4;
                        break;
                    case '^':
                        result = 5;
                        break;
                    case '(':
                        result = 6;
                        break;
                    case 'a': // sin
                        result = 7;
                        break;
                    case 'b': // cos
                        result = 7;
                        break;
                    case 'c': // sqrt
                        result = 7;
                        break;
                    case 'd': // ln
                        result = 7;
                        break;
                }
            }
            else
                result = 0;
            return result;
        }

        void CreatePostfixV2(char[] inputCharArray)
        {

            byte[,] decisionTable = new byte[,]
                { {4, 1, 1, 1, 1, 1, 1, 5, 1, 6},
                  {2, 2, 2, 1, 1, 1, 1, 2, 1, 6},
                  {2, 2, 2, 1, 1, 1, 1, 2, 1, 6},
                  {2, 2, 2, 2, 2, 1, 1, 2, 1, 6},
                  {2, 2, 2, 2, 2, 1, 1, 2, 1, 6},
                  {2, 2, 2, 2, 2, 2, 1, 2, 1, 6},
                  {5, 1, 1, 1, 1, 1, 1, 3, 1, 6},
                  {2, 2, 2, 2, 2, 2, 1, 7, 7, 6} };

            /*            1 – поместить символ из входной строки в стек;
                        2 – извлечь символ из стека и отправить его в выходную строку;
                        3 – удалить символ ")" из входной строки и символ "(" из стека;
                        4 – успешное окончание преобразования;
                        5 – ошибка скобочной структуры;
                        6 – переслать символ из входной строки в выходную строку;
                        7 – ошибка: после функции отсутствует "(".*/


            int i = 0; // Индекс очередного символа входной строки
            int j = 0; // Индекс очередного символа выходной строки

            while (i < inputCharArray.Length)
            {
                byte rowIndex = SymbNumInStack();
                byte columnIndex = SymbNumInputStr(inputCharArray[i]);

                byte decision = decisionTable[rowIndex, columnIndex];

                switch (decision)
                {
                    case 1:
                        Push(inputCharArray[i]);
                        i++;
                        break;
                    case 2:
                        outputCharArray[j] = Pop();
                        j++;
                        break;
                    case 3: // Удаление скобки из стека производится путем смещения указателя на его вершину ко дну
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
                        Console.WriteLine("Успешно завершено!");
                        return;
                    case 5:
                        Console.WriteLine("Ошибка скобочной структуры");
                        return;
                    case 6:
                        outputCharArray[j] = inputCharArray[i];
                        j++;
                        i++;
                        break;
                    case 7:
                        Console.WriteLine("После функции отсутствует открывающая скобка");
                        return;
                }
            }
        }
    }
}