using MatrixApi.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixPhone.DataModel
{
    class ProjectDataSource
    {
        private static Project project = new Project();


        public static Project GetProject(int ProjectId) {
            return project;
        }
    }
}
