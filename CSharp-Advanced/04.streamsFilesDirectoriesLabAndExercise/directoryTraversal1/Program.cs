﻿using System;
using DirectoryTraversal;

namespace directoryTraversal1//directoryTraversal
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputFolderPath = Console.ReadLine();
            DirectoryTraversal.TraverseDirectory(inputFolderPath);
            DirectoryTraversal.WriteReportToDesktop(DirectoryTraversal.TraverseDirectory(inputFolderPath));
        }
    }
}
