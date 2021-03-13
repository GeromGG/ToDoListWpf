namespace ToDoListWpf
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    public class ProjectTask
    {
        ProjectTask()
        {

        }

        ProjectTask(int indexNumber, string description, bool performed = false)
        {
            IndexNumber = indexNumber;
            Description = description;
            Performed = performed;
        }

        /// <summary>
        /// порядковый номер, важность
        /// </summary>
        public int IndexNumber { get; set; }

        /// <summary>
        /// описание задачи
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// флаг выполнения
        /// </summary>
        public bool Performed { get; set; }
    }
}