﻿namespace NBAStatistics.Reports.Contracts
{
    public interface IReport<T> where T : class
    {
        void Generate(string fileName, string savePath);
    }
}
