using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Lesson4.Models;

namespace Lesson4.Interfaces
{
    public interface ICommon: IService, IReposytory
    {
        public void Print();
    }
}
