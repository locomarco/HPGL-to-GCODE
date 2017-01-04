using System.Collections.Generic;
using System.Windows;

namespace HPGL_to_GCODE
{
    public class HPGL
    {
        public List<Command> Commands { get; private set; }

        public HPGL()
        {
            Commands = new List<Command>();
        }

        public void AddCommand(Command command)
        {
            Commands.Add(command);
        }

        public static HPGL Parse(string hpglString)
        {
            string[] commandSplits = hpglString.Split(';');
            HPGL hpgl = new HPGL();

            foreach (string commandSplit in commandSplits)
            {
                Command command = new Command();

                if (commandSplit.StartsWith("PD"))
                    command.SetInstruction(Instruction.PD);
                else if (commandSplit.StartsWith("PU"))
                    command.SetInstruction(Instruction.PU);
                else
                    command.SetInstruction(Instruction.Undefined);

                string[] coordinateSplits = commandSplit.Substring(2).Split(',');

                if (command.Instruction != Instruction.Undefined)
                {
                    for (int i = 0; i < coordinateSplits.Length; i += 2)
                    {
                        command.AddCoordinate(new Point(double.Parse(coordinateSplits[i]), double.Parse(coordinateSplits[i + 1])));
                    }
                }

                hpgl.AddCommand(command);
            }

            return hpgl;
        }

        public enum Instruction
        {
            PU,
            PD,
            Undefined
        }

        public class Command
        {
            public Instruction Instruction { get; private set; }
            public List<Point> Coordinates { get; private set; }

            internal Command(Instruction instruction)
            {
                Instruction = instruction;
                Coordinates = new List<Point>();
            }

            internal Command()
            {
                Coordinates = new List<Point>();
            }

            internal void SetInstruction(Instruction instruction)
            {
                Instruction = instruction;
            }

            internal void AddCoordinate(Point p)
            {
                Coordinates.Add(p);
            }
        }
    }
}