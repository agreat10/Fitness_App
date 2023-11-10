using Fitness_App.BL.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Fitness_App.BL.Controller
{
    public abstract class  ControllerBase
    {
        protected IDataSaver saver = new SerrializeDataSaver();

        protected void Save<T>(List<T> item) where T:class
        {
            saver.Save(item);
        }

        protected List<T> Load<T>() where T : class
        {
            return saver.Load<T>();
        }
    }
}
