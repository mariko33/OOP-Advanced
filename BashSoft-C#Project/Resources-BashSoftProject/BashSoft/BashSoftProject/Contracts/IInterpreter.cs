using System;

namespace BashSoftProject.Contracts
{
    public interface IInterpreter
    {
        void InterpretCommand(string command);
    }
}