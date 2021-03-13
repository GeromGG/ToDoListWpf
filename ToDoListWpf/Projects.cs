namespace ToDoListWpf
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Projects
    {
        /// <summary>
        /// Имя проекта
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Список задач
        /// </summary>
        public List<ProjectTask> Tasks = new();
    }
}
