using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgebraicExpressionsTranslation
{
    public class Transformation
    {
        public Stack stack;

        string infixString;
        char[] infixStringCharArray;
        int infixIndex = 0;
        const char infixStringEndSymbol = '\0';
        const char whiteSpace = ' ';

        string currentInfixString; // Для потактового режима вывода (отображение входной строки)

        string postfixString = string.Empty;
        const byte postfixCharArraySize = 200;
        char[] outputCharArray = new char[postfixCharArraySize];
        int postfixIndex = 0;

        string stackString = string.Empty;

        bool isTactMode = false; // Определяет работу метода в пошаговом режиме
        bool isTactAvailable = true; // Флаг доступности очередного такта в потактовом режиме
        bool isEnded = false; // Флаг окончания преобразований
        bool isTactButtonPressed = false;

        public Transformation(string inputString, bool isTactMode)
        {
            this.infixString = inputString + infixStringEndSymbol;
            this.isTactMode = isTactMode;
            this.stack = new Stack(Stack.StackType.TransformationStack);
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
                infixStringCharArray = infixString.ToCharArray();
                CreatePostfix(infixStringCharArray, isTactMode: false);
                postfixString = string.Join(null, outputCharArray);
            }
            else if (isTactMode)
            {
                infixStringCharArray = infixString.ToCharArray();

                while (true)
                {
                    if (isTactButtonPressed && !isEnded)
                    {
                        CreatePostfix(infixStringCharArray, isTactMode: true);
                        currentInfixString = string.Join(null, CreateCurrentInputString(infixStringCharArray, infixIndex));
                        postfixString = string.Join(null, outputCharArray);
                        stackString = string.Join(" ", stack.GetStack());
                        Console.WriteLine("Input string: " + currentInfixString + "\nOutput string: " + postfixString + "\nStack: " + stackString + "\nStackPointer: " + stack.GetStackPointerPos()+ "\n");

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
            return postfixString;
        }

        public string GetInputString() // Получение входной строки
        {
            return infixString;
        }
        public string GetCurrentInputString() // Получение текущей входной строки (которая изменяется при потактовом режиме воспроизведения)
        {
            return currentInfixString;
        }

        byte SymbNumInputStr(char? symbol) // возвращает индекс столбца таблицы решений на основе очередного символа входной строки
        {
            string englishAlphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            byte result = 0;

            if (symbol == infixStringEndSymbol)
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

        byte SymbNumInStack() // Возвращает индекс строки таблицы решений на основе символа находящегося на вершине стека
        {
            byte result = 0;
            char lastStackSymbol = stack.GetStackElement((stack.GetStackPointerPos() - 1));

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

        void CreatePostfix(char[] inputCharArray, bool isTactMode)
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
                byte columnIndex = SymbNumInputStr(inputCharArray[infixIndex]);

                byte decision = decisionTable[rowIndex, columnIndex];

                switch (decision)
                {
                    case 1:
                        stack.Push(inputCharArray[infixIndex]);
                        infixIndex++;
                        if (isTactMode)
                            isTactAvailable = false;
                        break;
                    case 2:
                        outputCharArray[postfixIndex] = stack.Pop();
                        postfixIndex++;
                        if (isTactMode)
                            isTactAvailable = false;
                        break;
                    case 3:
                        stack.DeleteLastStackItem(times: 1);
                        infixIndex++;
                        if (isTactMode)
                            isTactAvailable = false;
                        break;
                    case 4:
                        if (!stack.IsStackEmpty())
                        {
                            while (!stack.IsStackEmpty())
                            {
                                outputCharArray[postfixIndex] = stack.Pop();
                                postfixIndex++;
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
                        outputCharArray[postfixIndex] = inputCharArray[infixIndex];
                        postfixIndex++;
                        infixIndex++;
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
            while (infixIndex < inputCharArray.Length && isTactAvailable && !isEnded);
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
