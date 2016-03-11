using System;

namespace com.github.dergash.h3msorter
{
    public interface IConsoleCommand
    {
        void Exec();
        void Exec(String Key, String[] Args);
    }
}