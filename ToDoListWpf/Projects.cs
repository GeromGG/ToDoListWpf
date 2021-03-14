

namespace ToDoListWpf
{
    using System.Collections.Generic;
    public class Projects
    {
        /// <summary>
        /// Список проектов
        /// </summary>
        public List<Project> ListProjects = new();

        /// <summary>
        /// Добавление нового проекта в список
        /// </summary>
        /// <param name="name">Имя проекта</param>
        public int AddProject(string name)
        {
            var project = new Project(name);
            ListProjects.Add(project);
            var lastIndex = ListProjects.IndexOf(project);
            return lastIndex;
        }

        /// <summary>
        /// Удаления проекта из списка
        /// </summary>
        /// <param name="project">проект который нужно удалить</param>
        /// <returns></returns>
        public bool DeleteProject(Project project)
        {
            return ListProjects.Remove(project);
        }
    }
}
