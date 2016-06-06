using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Hosting;

namespace Kaftar.RuntimePolicyInjection.Core
{
    public static class FileSystemPathResolver
    {
        public static string Resolve(string path)
        {
            if (HostingEnvironment.IsHosted)
            {
                if (!Path.IsPathRooted(path))
                {
                    return HostingEnvironment.MapPath("~/bin/"+path);
                }
                else {
                    return path;
                }
            }
            else
            {
                return path;
            }
        }
    }
}
