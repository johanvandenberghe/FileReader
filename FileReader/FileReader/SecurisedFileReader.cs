using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;

namespace FileReader
{
    public abstract class SecurisedFileReader : IFileReader
    {
        private readonly IPermission _permission;
        private IEnumerable<string> _unrestrictedFiles;

        public SecurisedFileReader(IPermission permission, IEnumerable<string> unrestrictedFiles)
        {
            _permission = permission;
            _unrestrictedFiles = unrestrictedFiles;
        }

        public void PermissionDemand(string path)
        {
            try
            {
                _permission.Demand();
            }
            catch (SecurityException e)
            {
                if (!_unrestrictedFiles.Contains(path))
                    throw new SecurityException();
            }
        }

        
        public abstract string ReadFile(string path);
    }
}
