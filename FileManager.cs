using System;
using System.IO;
using System.Text;
using System.Collections.Generic;

namespace on_graph
{
    public class FileManager
    {
        public Boolean IsFileProcessing, IsConsoleInput;
        public string OutputFileName, InputFileName;

        public int numberOfCrosses, numberOfRoads;
        public List<int> firstPoint, lastPoint, passTime;
        public int startPoint, finishPoint;

        public FileManager(Boolean NeedToFileProcessing = false, Boolean NeedToConsoleInput = true) //organizes file IO process, read input file and fill the graph by edges
	    {
            IsFileProcessing = NeedToFileProcessing;
            IsConsoleInput = NeedToConsoleInput;

            if (!IsFileProcessing)
                Console.WriteLine("FileManager has created without file processing.");
            else
            {
                if (!IsConsoleInput)
                    SetInputFileNamePath(Program.__FILEPATH__);
                else 
                {
                    Console.WriteLine("Enter full input file path, please!");
                    InputFileName = Console.ReadLine();

                    while (!File.Exists(InputFileName) && InputFileName != "exit")
                    {
                        Console.WriteLine("Enter correct full input file path, please! (\"exit\" to quit)");
                        InputFileName = Console.ReadLine();
                    }

                    if (InputFileName == "exit")
                        Environment.Exit(1);
                }                   

                FileStream file = new FileStream(InputFileName, FileMode.Open, FileAccess.Read);
                StreamReader filereader = new StreamReader(file);

                String buff = null;
                buff = filereader.ReadLine();

                String[] numbersInBuff = buff.Split(' ');
                numberOfCrosses = Int32.Parse(numbersInBuff[0]);
                numberOfRoads = Int32.Parse(numbersInBuff[1]);

                buff = null;
                numbersInBuff = null;

                firstPoint = new List<int>();
                lastPoint = new List<int>();
                passTime = new List<int>();

                for (int i = 0; i < numberOfRoads; ++i)
                {
                    buff = filereader.ReadLine();

                    numbersInBuff = buff.Split(' ');
                    firstPoint.Add(Int32.Parse(numbersInBuff[0]));
                    lastPoint.Add(Int32.Parse(numbersInBuff[1]));
                    passTime.Add(Int32.Parse(numbersInBuff[2]));

                    buff = null;
                    numbersInBuff = null;
                }

                buff = filereader.ReadLine();
                numbersInBuff = buff.Split(' ');
                startPoint = Int32.Parse(numbersInBuff[0]);
                finishPoint = Int32.Parse(numbersInBuff[1]);

                filereader.Close();
                file.Close();

                if (!IsConsoleInput)
                    OutputFileName = Program.__FILEPATH__ + Program.__OUTPUT_FILENAME__;
                else
                {
                    Console.WriteLine("Enter full output file path, please!");
                    OutputFileName = Console.ReadLine();
                }
            }
	    }

        public void SetInputFileNamePath(String FileNamePath) //concatinates the filename path and filename in file-on activity mode
        {
            if (!IsFileProcessing)
                Console.WriteLine("Reading attempt detected. FileManager has created without file processing.");
            else if (IsConsoleInput)
                Console.WriteLine("Console input is on. Don't use this method, operate with console.");
            else
                InputFileName = FileNamePath + "\\input.txt";
        }

        public void FileRecorder(int Solved, int Infinity) //writes result solved by Bellman–Ford algorithm in file
        {
            if (!IsFileProcessing)
                Console.WriteLine("Record attempt detected. FileManager has created without file processing!");
            else
            {
                String buff = null;
                if (Solved <= 0)
                    buff = "Infinitely small";
                else if (Solved == Infinity)
                    buff = "Infinitely big";
                else
                    buff = Solved.ToString();
                File.WriteAllText(OutputFileName, buff);
            }
        }

        public void ShowInConsole(Edge AnyEdge, String FirstMessage = "") //prints the Edge element with FirstMessage in head in file-off activity mode
        {
            String buff = FirstMessage;
            buff += AnyEdge.ToString();
            Console.WriteLine(buff);
        }
    }
}
