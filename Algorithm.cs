using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgebraicExpressionsTranslation
{
    class Algorithm
    {
        string inputString;
        char[] inputStringCharArray;
        int inputIndex = 0;
        const char stringEndSymbol = '\0';
        const char whiteSpace = ' ';

        string currentInputString; // Для потактового режима вывода (отображение входной строки)

        string outputString = string.Empty;
        const byte outputCharArraySize = 200;
        char[] outputCharArray = new char[200];
        int outputIndex = 0;

        const byte stackSize = 15;
        char[] stack = new char[stackSize];
        string stackString = string.Empty;
        byte stackPointer = 1;

        bool isTactMode = false; // Определяет работу метода в пошаговом режиме
        bool isTactAvailable = true; // Флаг доступности очередного такта в потактовом режиме
        bool isEnded = false; // Флаг окончания преобразований
        bool isTactButtonPressed = false;

        public Algorithm(string inputString, bool isTactMode)
        {
            this.inputString = inputString + stringEndSymbol;
            this.isTactMode = isTactMode;
        }
        
        public void SetTactButtonPressed() // Метод, вызываемый извне для модификации переменной отвечающей за потактовое продвижение алгоритма
        {
            isTactButtonPressed = true;
        }

        public bool GetTactMode() // Используется для отображения стека (если true, то стек отображается)
        {
            return isTactMode;
        }

        public bool GetEndFlag() // Используется для получения признака завершения алгоритма
        {
            return isEnded;
        }

        public void ReleaseTactButtonPressed() // Метод, вызываемый извне для модификации переменной отвечающей за потактовое продвижение алгоритма
        {
            isTactButtonPressed = false;
        }

        public void General() // Общий метод (main своего рода )
        {
            if (!isTactMode)
            {
                inputStringCharArray = inputString.ToCharArray();
                CreatePostfixV2(inputStringCharArray, isTactMode: false);
                outputString = string.Join(null, outputCharArray);
            }
            else if (isTactMode)
            {
                inputStringCharArray = inputString.ToCharArray();

                while (true)
                {
                    if (isTactButtonPressed && !isEnded)
                    {
                        CreatePostfixV2(inputStringCharArray, isTactMode: true);
                        currentInputString = string.Join(null, CreateCurrentInputString(inputStringCharArray, inputIndex));
                        outputString = string.Join(null, outputCharArray);
                        stackString = string.Join(" ", stack); // Тут было ' '
                        Console.WriteLine("Input string: " + currentInputString + "\nOutput string: " + outputString + "\nStack: " + stackString + "\nStackPointer: " + stackPointer + "\n");

                        ReleaseTactButtonPressed();
                    }
                    if (isEnded)
                    {
                        Console.WriteLine("\nУспешно завершено! Нажмите Escape для выхода...");
                        System.Windows.Forms.MessageBox.Show("Алгоритм успешно выполнен!");
                        break;
                    }
                    if (!isTactButtonPressed)
                        break;
                }
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
        public string GetCurrentInputString() // Получение текущей входной строки (которая изменяется при потактовом режиме воспроизведения)
        {
            return currentInputString;
        }

        public int GetStackPointerPos() // Получение позиции стекпоинтера
        {
            return stackPointer;
        }

        public char GetStackElement(int index) // Получить элемент стека по индексу
        {
            if (index >= 0)
                return stack[index];
            else
                return whiteSpace;
        }

        public void DeleteLastStackItem() // Удалить элемент на верхушке стека (сдвинуть указатель)
        {
            stackPointer--;
        }

        bool IsStackEmpty() // Возвращает true при пустом стеке, else false
        {
            return (stackPointer == 0) ? true : false;
        }

        char Pop() // Извлечь элемент находящийся на верхушке стека
        {
            if (GetStackPointerPos() > 0)
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
            {
                System.Windows.Forms.MessageBox.Show("Переполнение стека");
                return;
            }
            stack[stackPointer] = symbol;
            stackPointer++;
        }

        public byte SymbNumInputStr(char? symbol) // возвращает индекс столбца таблицы решений на основе очередного символа входной строки
        {
            string englishAlphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
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

        public byte SymbNumInStack() // Возвращает индекс строки таблицы решений на основе символа находящегося на вершине стека
        {
            byte result = 0;
            char lastStackSymbol = GetStackElement(GetStackPointerPos() - 1);

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

        void CreatePostfixV2(char[] inputCharArray, bool isTactMode)
        {

            byte[,] decisionTable = new byte[,]
                { {4, 1, 1, 1, 1, 1, 1, 5, 1, 6},
                  {2, 2, 2, 1, 1, 1, 1, 2, 1, 6},
                  {2, 2, 2, 1, 1, 1, 1, 2, 1, 6},
                  {2, 2, 2, 2, 2, 1, 1, 2, 1, 6},
                  {2, 2, 2, 2, 2, 1, 1, 2, 1, 6},
                  {2, 2, 2, 2, 2, 2, 1, 2, 1, 6},
                  {5, 1, 1, 1, 1, 1, 1, 3, 1, 6},
                  {2, 2, 2, 2, 2, 2, 1, 2, 7, 6} };

            /*            1 – поместить символ из входной строки в стек;
                        2 – извлечь символ из стека и отправить его в выходную строку;
                        3 – удалить символ ")" из входной строки и символ "(" из стека;
                        4 – успешное окончание преобразования;
                        5 – ошибка скобочной структуры;
                        6 – переслать символ из входной строки в выходную строку;
                        7 – ошибка: после функции отсутствует "(".
            */

            do
            {
                byte rowIndex = SymbNumInStack();
                byte columnIndex = SymbNumInputStr(inputCharArray[inputIndex]);

                byte decision = decisionTable[rowIndex, columnIndex];

                switch (decision)
                {
                    case 1:
                        Push(inputCharArray[inputIndex]);
                        inputIndex++;
                        if (isTactMode)
                            isTactAvailable = false;
                        break;
                    case 2:
                        outputCharArray[outputIndex] = Pop();
                        outputIndex++;
                        if (isTactMode)
                            isTactAvailable = false;
                        break;
                    case 3:
                        DeleteLastStackItem();
                        inputIndex++;
                        if (isTactMode)
                            isTactAvailable = false;
                        break;
                    case 4:
                        if (!IsStackEmpty())
                        {
                            while (!IsStackEmpty())
                            {
                                outputCharArray[outputIndex] = Pop();
                                outputIndex++;
                            }
                        }
                        if (isTactMode)
                            isTactAvailable = false;
                        isEnded = true;
                        return;
                    case 5:
                        Console.WriteLine("Ошибка скобочной структуры\n");
                        if (isTactMode)
                            isTactAvailable = false;
                        return;
                    case 6:
                        outputCharArray[outputIndex] = inputCharArray[inputIndex];
                        outputIndex++;
                        inputIndex++;
                        if (isTactMode)
                            isTactAvailable = false;
                        break;
                    case 7:
                        Console.WriteLine("После функции отсутствует открывающая скобка\n");
                        if (isTactMode)
                            isTactAvailable = false;
                        return;
                }
            }
            while (inputIndex < inputCharArray.Length && isTactAvailable && !isEnded);
        }

        char[] CreateCurrentInputString(char[] inputStringCharArray, int inputIndex) // Посимвольное отображение изменяющейся в потактовом режиме входной строки
        {
            List<char> currentInputString = new List<char>();
            currentInputString.Clear();

            for (int i = inputStringCharArray.Length - 1; i > inputIndex - 1; i--)
            {
                currentInputString.Add(inputStringCharArray[i]);
            }
            currentInputString.Reverse();
            return currentInputString.ToArray();
        }    
    }
}
