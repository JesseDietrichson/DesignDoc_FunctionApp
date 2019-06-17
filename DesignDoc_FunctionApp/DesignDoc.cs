using System;
using System.Collections.Generic;
using System.Text;

namespace DesignDoc_FunctionApp
{
    public class DesignDoc
    {
        public string Title { get; set; }
        public List<string> Roles { get; set; } = new List<string>();
        public string Level { get; set; }
        public List<string> Products { get; set; } = new List<string>();

        public List<string> Prerequisites { get; set; } = new List<string>();
        public string Summary { get; set; }
        public List<string> LearningObjectives { get; set; } = new List<string>();
        public List<Unit> Units { get; set; } = new List<Unit>();

        public List<string> GetUnitsForIndexYml()
        {
            return Units.ConvertAll<string>((u) => "<module uid>." + u.ToString());
        }
        public List<string> GetRolesForIndexYml()
        {
            return Roles.ConvertAll<string>((u) => NamingHelper.ReplaceSpacesWithHyphen(u));
        }

    }
}
